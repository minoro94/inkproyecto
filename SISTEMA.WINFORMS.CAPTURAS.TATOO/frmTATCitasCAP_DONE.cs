using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;
using System.Collections;
using System.IO;
using System.Drawing.Imaging;
using System.Net.Mail;


namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_DONE : Form
    {
        public frmTATCitasCAP_DONE()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATCitas.strTATCitas str = new TATCitas.strTATCitas();
        public DataTable dtableFechasCita = new DataTable();
        public DataTable dtInventario = new DataTable();
        public DataTable dtImagentestato = new DataTable();
        Point posicionPrevia = new Point(-1, -1);
        public string DireccionFirma;
        public string Correo;
        string borrafirma;
        Random rnd = new Random();
        TATCitas TABLA = new TATCitas();
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region DIBUJAR
        private void ptbFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (posicionPrevia.X == -1)
            {
                posicionPrevia = new Point(e.X, e.Y);
            }
            Point PosicionActual = new Point(e.X, e.Y);
            Graphics Dibujo = this.ptbFirma.CreateGraphics();
            Dibujo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (e.Button == MouseButtons.Left)
            {
                Dibujo.DrawLine(new Pen(Color.Black,2), posicionPrevia, PosicionActual);
                btnAceptar.Enabled = true;
            }

            posicionPrevia = PosicionActual;
        }
        #endregion

        #region MOUSE CLICK
        private void ptbFirma_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ptbFirma.Refresh();
                btnAceptar.Enabled = false;
            }
        }
        #endregion

        #region CAPTURA DE PANTALLA
        private void CapturaPantalla()
        {
            Bitmap BmpScreen = new Bitmap(ptbFirma.Size.Width, ptbFirma.Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics ScreenShot = Graphics.FromImage(BmpScreen);
            ScreenShot.CopyFromScreen(ptbFirma.Location.X + this.Location.X + groupBox1.Location.X, ptbFirma.Location.Y + this.Location.Y + groupBox1.Location.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            string fileNom = String.Empty;
            saveFileDialog1.Filter = "Excel files (*.png)|*.png";
            saveFileDialog1.RestoreDirectory = true;
            fileNom = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\SISTEMA.WINFORMS.CAPTURAS.TATOO\Capturas\Imgfirma" + Convert.ToString(rnd.Next(10000)) + ".png");
            DireccionFirma = fileNom;
            
            BmpScreen.Save(fileNom, System.Drawing.Imaging.ImageFormat.Png);
            str.Firma = Herramientas.encodeImagen(DireccionFirma);

            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            CapturaPantalla();
            //bool Enviar = EnviarCorreo();
            bool Agregar = TABLA.DAO(ref str, 1, dtInventario, dtableFechasCita, dtImagentestato);
            
            if (Agregar)
            {
                MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
               // File.Delete(DireccionFirma);
                Close();
            }
            else
            {
                MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }

        }
        #endregion


        #region ENVIAR CORREO
        private bool EnviarCorreo()
        {
            //string file = "FinalFantasy.pdf";
            string ruta = (Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"..\SISTEMA.WINFORMS.CAPTURAS.TATOO\PDF\HistorialMedico.pdf"));


            MailMessage Mensaje = new MailMessage();
            Mensaje.To.Add(Correo);
            Mensaje.Subject = "PDF";
            Mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
            Mensaje.Body = "PROBANDO PDF";
            Mensaje.Attachments.Add(new Attachment(ruta));
            Mensaje.BodyEncoding = System.Text.Encoding.UTF8;
            Mensaje.IsBodyHtml = true;
            Mensaje.From = new System.Net.Mail.MailAddress("rleyvacastro@gmail.com");
            SmtpClient Cliente = new SmtpClient();
            Cliente.Credentials = new System.Net.NetworkCredential("rleyvacastro@gmail.com", "As5drq9zv7391,");
            Cliente.Port = 587;
            Cliente.EnableSsl = true;
            Cliente.Host = "smtp.gmail.com";

            try
            {
                Cliente.Send(Mensaje);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(this, "Ha Ocurrido Un Error Al Enviar Correo", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
        #endregion
    }
}

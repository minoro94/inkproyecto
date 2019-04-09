using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using SISTEMA.TATTOO;
using System.IO;


namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATFirmaCAP : Form
    {
        public frmTATFirmaCAP()
        {
            InitializeComponent();
            btnAceptar.Enabled = false;
        }

        #region OBJETOS
        Point posicionPrevia = new Point(-1,- 1);
        Random rnd = new Random();
        public string DireccionFirma;
        
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region DIBUJAR
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(posicionPrevia.X == -1)
            {
                posicionPrevia = new Point(e.X, e.Y);
            }
            Point PosicionActual = new Point(e.X, e.Y);
            Graphics Dibujo = this.ptbFirma.CreateGraphics();
            Dibujo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if(e.Button == MouseButtons.Left)
            {
                Dibujo.DrawLine(new Pen(Color.Black), posicionPrevia, PosicionActual);
                btnAceptar.Enabled = true;
            }
            
            posicionPrevia = PosicionActual;
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CapturaPantalla();
        }
        #endregion

        #region CAPTURA DE PANTALLA
        private void CapturaPantalla()
        {
            Bitmap BmpScreen = new Bitmap(ptbFirma.Size.Width, ptbFirma.Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics ScreenShot = Graphics.FromImage(BmpScreen);
            ScreenShot.CopyFromScreen(ptbFirma.Location.X + this.Location.X, ptbFirma.Location.Y + this.Location.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            string fileNom = String.Empty;
            saveFileDialog1.Filter = "Excel files (*.png)|*.png";
            saveFileDialog1.RestoreDirectory = true;
            fileNom = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\SISTEMA.WINFORMS.CAPTURAS.TATOO\Capturas\Img" + Convert.ToString(rnd.Next(10000)) + ".png");
            DireccionFirma = fileNom;
            BmpScreen.Save(fileNom, System.Drawing.Imaging.ImageFormat.Png);

            
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region LOAD
        private void frmTATFirmaCAP_Load(object sender, EventArgs e)
        {
            CargarFirma(DireccionFirma);
        }
        #endregion

        #region CARGAR FIRMA
        private void CargarFirma(string Firma)
        {
            if(Firma != "")
            {
                openFileDialog1.FileName = Firma;
                ptbFirma.Image = Image.FromFile(openFileDialog1.FileName);
            }
            else
            {

            }
        }
        #endregion

        #region MOUSE CLICK FIRMA
        private void ptbFirma_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                if (DireccionFirma != "")
                {
                    ptbFirma.Image.Dispose();
                    ptbFirma.Image = null;
                    File.Delete(DireccionFirma);
                    DireccionFirma = "";
                }
                else
                {
                    ptbFirma.Refresh();
                }
                btnAceptar.Enabled = false;
            }
            
        }
        #endregion
    }
}

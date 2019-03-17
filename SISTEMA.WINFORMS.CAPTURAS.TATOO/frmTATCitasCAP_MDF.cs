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
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_MDF : Form
    {
        public frmTATCitasCAP_MDF()
        {
            InitializeComponent();
        }


        #region OBJETOS
        Random rnd = new Random();

        Rectangle[] Rectangulos = new Rectangle[0];

        TATTamaños.strTATTamaños[] ARR_Tamaños;
        TATTamaños TABLA_Tamaños = new TATTamaños();
        ArrayList IDsTamaños = new ArrayList();

        TATEstadoCita.strTATEstadoCita[] ARR_EstadoCita;
        TATEstadoCita TABLA_EstadoCita = new TATEstadoCita();
        ArrayList IDsEstadoCita = new ArrayList();

        TATClientes.strTATClientes[] ARR_Clientes;
        TATClientes TABLA_Clientes = new TATClientes();
        TATClientes.strTATClientes strClientes = new TATClientes.strTATClientes();

        TATCitas.strTATCitas strCitas = new TATCitas.strTATCitas();
        TATCitas TABLA_Citas = new TATCitas();

        public int IDTamaño;
        public int IDEstadoCita;
        public int idCliente;
        public string USUARIO;
        public bool Sexo;
        public string imgTatuaje = "";
        public string imgZonaCuerpo;
        public string imgtato;
        public int idCita;
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

        #region FILL DATOS CLIENTES
        private void FillDatosClientes()
        {
            strClientes.idCliente = idCliente;
            TABLA_Clientes.Listar(ref ARR_Clientes, strClientes);
            foreach (TATClientes.strTATClientes Dato in ARR_Clientes)
            {
                strClientes.Sexo = Dato.Sexo;
            }
            Sexo = strClientes.Sexo;
        }
        #endregion

        #region FILL COMBO TAMAÑOS
        private void FillComboTamaños()
        {
            TABLA_Tamaños.Listar(ref ARR_Tamaños);

            try
            {
                foreach (TATTamaños.strTATTamaños Dato in ARR_Tamaños)
                {
                    cbxTamaño.Items.Add(Dato.Tamaño);
                    IDsTamaños.Add(Dato.idTamaño);
                }
                int pos = 0;

                foreach(object Dato in IDsTamaños)
                {
                    if(Convert.ToInt32(Dato) == IDTamaño)
                    {
                        break;
                    }
                    pos++;
                }
                cbxTamaño.SelectedIndex = pos;
                TABLA_Tamaños.Dispose();
            }
            catch
            {

            }
        }
        #endregion

        #region FILL COMBO ESTADO CITA
        private void FillComboEstadoCita()
        {
            TABLA_EstadoCita.Listar(ref ARR_EstadoCita);
            try
            {
                foreach (TATEstadoCita.strTATEstadoCita Dato in ARR_EstadoCita)
                {
                    cbxEstadoCita.Items.Add(Dato.NombreEstadoCita);
                    IDsEstadoCita.Add(Dato.idEstadoCita);
                }
                int pos = 0;
                foreach(object Dato in IDsEstadoCita)
                {
                    if(Convert.ToInt32(Dato) == IDEstadoCita)
                    {
                        break;
                    }
                    pos++;
                }
                cbxEstadoCita.SelectedIndex = pos;
                TABLA_EstadoCita.Dispose();
            }
            catch
            {

            }
        }
        #endregion

        #region LOAD
        private void frmTATCitasCAP_MDF_Load(object sender, EventArgs e)
        {
            FillComboEstadoCita();
            FillComboTamaños();
            FillDatosClientes();
            PanelInfoTatuaje_MouseDown(null,null);
        }
        #endregion

        #region BOTON LIMPIAR PERFIL
        private void btnLimpiarPerfil_Click(object sender, EventArgs e)
        {
            Rectangulos = new Rectangle[0];
            if (Sexo)
            {
                openFileDialog2.FileName = @"C:\repos\inkproyecto\SISTEMA.WINFORMS.CAPTURAS.TATOO\Resources\PerfilHombre.png";
                ptbPerfil.Image = Image.FromFile(openFileDialog2.FileName);
            }
            else
            {

                openFileDialog2.FileName = @"C:\repos\inkproyecto\SISTEMA.WINFORMS.CAPTURAS.TATOO\Resources\PerfilMujer.png";
                ptbPerfil.Image = Image.FromFile(openFileDialog2.FileName);
            }
        }
        #endregion

        #region DIBUJA
        private void Dibuja(int x, int y, bool Decision)
        {
            Rectangle[] Aux = new Rectangle[Rectangulos.Length + 1];
            int au = 0;
            if (Decision && x != 1000)
            {
                int Ejex = this.Location.X + gbInfoTatuajes.Location.X + ptbPerfil.Location.X + 4;
                int Ejey = this.Location.Y + gbInfoTatuajes.Location.Y + ptbPerfil.Location.Y + 4;

                Ejex = x - Ejex;
                Ejey = y - Ejey;

                Graphics ObjGrafico;
                ObjGrafico = ptbPerfil.CreateGraphics();
                Pen Pluma = new Pen(System.Drawing.Color.Red, 5);
                Rectangle MiRectangulo = new Rectangle(Ejex, Ejey, 5, 5);
                ObjGrafico.DrawEllipse(Pluma, MiRectangulo);

                for (int i = 0; i < Rectangulos.Length; i++)
                {
                    Aux[i] = Rectangulos[i];
                    au = i + 1;
                }
                Aux[au] = MiRectangulo;

                Rectangulos = new Rectangle[Aux.Length];
                for (int i = 0; i < Rectangulos.Length; i++)
                {
                    Rectangulos[i] = Aux[i];
                }
            }
            else if (x == 1000)
            {
                for (int i = 0; i < Rectangulos.Length; i++)
                {
                    Graphics ObjGrafico;
                    ObjGrafico = ptbPerfil.CreateGraphics();
                    Pen Pluma = new Pen(System.Drawing.Color.Red, 5);
                    Rectangle MiRectangulo = new Rectangle(Rectangulos[i].X, Rectangulos[i].Y, 5, 5);
                    ObjGrafico.DrawEllipse(Pluma, MiRectangulo);
                }
            }
            else
            {
                EliminarPunto();
            }
        }
        #endregion

        #region ELIMINA PUNTO
        private void EliminarPunto()
        {
            if (Rectangulos.Length == 0)
            {

            }
            else
            {
                Rectangle[] aux = new Rectangle[Rectangulos.Length - 1];
                for (int i = 0; i < aux.Length; i++)
                {
                    aux[i] = Rectangulos[i];
                    Graphics ObjGrafico;
                    ObjGrafico = ptbPerfil.CreateGraphics();
                    Pen Pluma = new Pen(System.Drawing.Color.Red, 5);
                    Rectangle MiRectangulo = new Rectangle(aux[i].X, aux[i].Y, 5, 5);
                    ObjGrafico.DrawEllipse(Pluma, MiRectangulo);
                }
                Rectangulos = new Rectangle[aux.Length];
                for (int i = 0; i < Rectangulos.Length; i++)
                {
                    Rectangulos[i] = aux[i];
                }
            }
        }
        #endregion

        #region MOUSE CLICK
        private void ptbPerfil_MouseClick(object sender, MouseEventArgs e)
        {
            int x = MousePosition.X;
            int y = MousePosition.Y;
            if (e.Button == MouseButtons.Right)
            {
                ptbPerfil.Refresh();
                Dibuja(x, y, false);
            }
            else
            {
                Dibuja(x, y, true);
            }
        }

        #endregion

        #region MOUSE DOWN PANEL INFO TATUAJE
        private void PanelInfoTatuaje_MouseDown(object sender, MouseEventArgs e)
        {
            if (gbInfoTatuajes.Visible)
            {
                gbInfoTatuajes.Visible = false;
                ptbAbajo.Visible = false;
                ptbDerecha.Visible = true;
                this.Size = new System.Drawing.Size(1333, 263);
                btnAceptar.Location = new Point(1135, 214);
                btnCancelar.Location = new Point(1231, 214);
                btnAceptar.Enabled = false;

                PanelBorderAbajo.Location = new Point(3, 259);
            }
            else
            {
                gbInfoTatuajes.Visible = true;
                ptbDerecha.Visible = false;
                ptbAbajo.Visible = true;
                this.Size = new System.Drawing.Size(1333, 695);
                btnAceptar.Location = new Point(1135, 650);
                btnCancelar.Location = new Point(1234, 650);
                btnAceptar.Enabled = true;

                PanelBorderAbajo.Location = new Point(3, 691);
                ptbPerfil.Refresh();
                Dibuja(1000, 0, true);
            }
        }
        #endregion

        #region CLOSE
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON ADJUNTAR IMAGEN
        private void btnAdjuntarImagen_Click(object sender, EventArgs e)
        {
            DialogResult x = openFileDialog1.ShowDialog();
            try
            {
                if (x == DialogResult.OK)
                {
                    ptbTatuaje.Image = Image.FromFile(openFileDialog1.FileName);
                    imgTatuaje = openFileDialog1.FileName;
                }
            }
            catch
            {
             MessageBox.Show("El Archivo Seleccionado No Es Un Tipo De Imagen");
            }
        }
        #endregion

        #region CAPTURA PANTALLA
        private void CapturaPantalla()
        {
            Bitmap BmpScreen = new Bitmap(ptbPerfil.Size.Width, ptbPerfil.Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics ScreenShot = Graphics.FromImage(BmpScreen);
            ScreenShot.CopyFromScreen(ptbPerfil.Location.X + this.Location.X + gbInfoTatuajes.Location.X, ptbPerfil.Location.Y + this.Location.Y + gbInfoTatuajes.Location.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            string fileNom = String.Empty;
            Clipboard.SetDataObject(ScreenShot);
            imgZonaCuerpo = Clipboard.GetText();
            
            saveFileDialog1.Filter = "Excel files (*.png)|*.png";
            saveFileDialog1.RestoreDirectory = true;
            fileNom = @"C:\repos\inkproyecto\SISTEMA.WINFORMS.CAPTURAS.TATOO\Capturas\Img" + Convert.ToString(rnd.Next(10000)) + ".png";
            imgZonaCuerpo = fileNom;
            BmpScreen.Save(fileNom, System.Drawing.Imaging.ImageFormat.Png);

            /*BinaryFormatter binFormatter = new BinaryFormatter();
            using (Image img = Clipboard.GetImage())
            using (MemoryStream memStream = new MemoryStream())
            {
                binFormatter.Serialize(memStream, img);
                byte[] bytes = memStream.ToArray();
                imgZonaCuerpo = Convert.ToBase64String(bytes);
            }*/
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(imgTatuaje == "")
            {
                imgTatuaje = "0";
            }
            if (txtAnticipo.Text.Trim() != "" && txtCosto.Text.Trim() != "" && imgTatuaje != "")
            {
                CapturaPantalla();
                strCitas.idCita = idCita;
                strCitas.idCliente = idCliente;
                strCitas.idEstadoCita = Convert.ToInt32(IDsEstadoCita[cbxEstadoCita.SelectedIndex]);
                strCitas.idTamaño = Convert.ToInt32(IDsTamaños[cbxTamaño.SelectedIndex]);
                strCitas.FechaCita = dtpFechaCita.Value;
                strCitas.FechaCita = new DateTime(dtpFechaCita.Value.Year, dtpFechaCita.Value.Month, dtpFechaCita.Value.Day, dtpFechaCita.Value.Hour, dtpFechaCita.Value.Minute, 0);
                strCitas.Costo = Convert.ToDouble(txtCosto.Text.Trim());
                strCitas.Anticipo = Convert.ToDouble(txtAnticipo.Text.Trim());
                strCitas.Descripcion = txtDescripcion.Text.Trim();
                strCitas.Firma = "Default";
                strCitas.USUARIO = USUARIO;


                try
                {
                    if(imgTatuaje == "0")
                    {
                        strCitas.ImagenTatto = imgtato;
                    }
                    else
                    {
                        String Imgtat = Herramientas.encodeImagen(imgTatuaje);
                        strCitas.ImagenTatto = Imgtat;
                    }
                    
                    String ImgZon = Herramientas.encodeImagen(imgZonaCuerpo);
                    strCitas.ZonaCuerpo = ImgZon;
                    //File.Delete(imgZonaCuerpo);
                }
                    catch (Exception)
                {
                    strCitas.ImagenTatto = null;
                }

                bool Agregado = TABLA_Citas.DAO(ref strCitas, 2);

                if (Agregado)
                {
                    MessageBox.Show(this, "Modificado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "Faltan Campos Por Completar", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

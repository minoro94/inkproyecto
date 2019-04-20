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


namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_INS2 : Form
    {
        public frmTATCitasCAP_INS2()
        {
            InitializeComponent();
        }

        
        #region OBJETOS
        public string USUARIO;
        public string NombreCliente;
        public string Telefono;
        public int idCliente;
        public string Firma = "";
        public string Correo;

        int PosicionImg = 0;
        string imgZonaCuerpo;

        List<String> imgList = new List<String>();
        string[] Imagenes = new string[0];
        Random rnd = new Random();

        Image[] Carrusel = new Image[0];
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

        #region DATA TABLES
        DataTable dtImagenesTatto = new DataTable();
        DataTable dtCitasInventario = new DataTable();
        DataTable dtSesionesCitas = new DataTable();
        #endregion

        #region WAFLES
        wfCitasInventario wfCitasInventario = new wfCitasInventario();
        wfSesionesCitas wfFechasCitas = new wfSesionesCitas();
        wfTATFirma wfFirma = new wfTATFirma();
        #endregion

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
                cbxTamaño.SelectedIndex = 0;
            }
            catch
            {
                cbxTamaño.Items.Add("NO HAY REGISTROS");
                cbxTamaño.SelectedIndex = 0;
            }

            TABLA_Tamaños.Dispose();
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
                cbxEstadoCita.SelectedIndex = 0;
            }
            catch
            {
                cbxEstadoCita.Items.Add("NO HAY REGISTROS");
                cbxEstadoCita.SelectedIndex = 0;
            }

            TABLA_EstadoCita.Dispose();
        }
        #endregion

        #region FILL DATOS CLIENTES
        private void FillDatosClientes()
        {
            strClientes.idCliente = idCliente;
            TABLA_Clientes.Listar(ref ARR_Clientes, strClientes);
            foreach (TATClientes.strTATClientes Dato in ARR_Clientes)
            {
                lblNombreCliente.Text = Dato.nombreCliente;
                lblTelefono.Text = Convert.ToString(Dato.Telefono);
                strClientes.Sexo = Dato.Sexo;
                Correo = Dato.Correo;
            }
        }
        #endregion

        #region CARGAR PERFIL
        private void CargarPerfil(bool Sexo)
        {
            if (Sexo)
            {
                //openFileDialog2.FileName = @"C:\Rep\SISTEMA.WINFORMS.CAPTURAS.TATOO\Resources\PerfilHombre.png";
                //ptbPerfil.Image = Image.FromFile(openFileDialog2.FileName);
                ptbPerfil.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.PerfilHombre;
            }
            else
            {

                //openFileDialog2.FileName = @"C:\Rep\SISTEMA.WINFORMS.CAPTURAS.TATOO\Resources\PerfilMujer.png";
                //ptbPerfil.Image = Image.FromFile(openFileDialog2.FileName);
                ptbPerfil.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.PerfilMujer;
            }
        }

        #endregion

        #region LOAD
        private void frmTATCitasCAP_INS2_Load(object sender, EventArgs e)
        {
            FillComboTamaños();
            FillComboEstadoCita();
            FillDatosClientes();
            CargarPerfil(strClientes.Sexo);
            ValidaIzDe();
            EnableButtons();
        }
        #endregion

        #region CLOSE
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region KEY PRESS
        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                Dibuja(1000, 0, true);
                return;
            }
        }

        private void txtAnticipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                Dibuja(1000, 0, true);
                return;
            }
        }

        #endregion

        #region DIBUJAR
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

        #region ELIMINAR PUNTO
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

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CARGAR IMAGEN
        private void btnAdjuntarImagen_Click(object sender, EventArgs e)
        {
            DialogResult Resultado = openFileDialog1.ShowDialog();
            try
            {
                if(Resultado == DialogResult.OK)
                {
                    ptbTatuaje.Image = Image.FromFile(openFileDialog1.FileName);
                    AgregarImagenArreglo(openFileDialog1.FileName);
                }
            }
            catch
            {

            }
        }
        #endregion

        #region CARRUSEL

        #region ENCONTRAR IMAGEN CARRUSEL
        private void CarruselImagen(int Posicion)
        {
            if(imgList.Count > 0)
            {
                for (int i = 0; i <= imgList.Count; i++)
                {
                    if (i == Posicion)
                    {
                        ptbTatuaje.Image = Image.FromFile(imgList[i]);
                    }
                }
            }
            

            ValidaIzDe();
            EnableButtons();
        }
        #endregion

        #region AGREGAR IMAGEN EN EL ARREGLO
        private void AgregarImagenArreglo(string img)
        {
            imgList.Add(img);
            if(imgList.Count == 1)
            {
                PosicionImg = 0;
            }
            else
            {
                PosicionImg = imgList.Count-1;
            }
            EnableButtons();
            ValidaIzDe();
           
        }
        #endregion

        #region PTB DERECHA
        private void ptbDerecha_Click(object sender, EventArgs e)
        {
            PosicionImg++;
            CarruselImagen(PosicionImg);
        }
        #endregion

        #region PTB IZQUIERDA
        private void ptbIzquierda_Click(object sender, EventArgs e)
        {
            PosicionImg--;
            CarruselImagen(PosicionImg);
        }
        #endregion

        #region VALIDAR DERECHA IZQUIERDA
        private void ValidaIzDe()
        {
            if(PosicionImg == 0)
            {
                ptbDerecha.Visible = false;
                ptbIzquierda.Visible = false;
            }
            if(PosicionImg == 0 && imgList.Count > 1)
            {
                ptbDerecha.Visible = true;
                ptbIzquierda.Visible = false;
            }
            if(PosicionImg > 0 && PosicionImg == imgList.Count-1)
            {
                ptbDerecha.Visible = false;
                ptbIzquierda.Visible = true;
            }
            if(PosicionImg > 0 && PosicionImg == imgList.Count-2)
            {
                ptbDerecha.Visible = true;
                ptbIzquierda.Visible = true;
            }
            
        }
        #endregion

        #endregion

        #region BOTON AGREGAR INSTRUMENTOS
        private void btnProductos_Click(object sender, EventArgs e)
        {
            DialogResult Res = wfCitasInventario.Agregar(ref dtCitasInventario);
            if(Res == DialogResult.OK)
            {
                
            }
        }
        #endregion

        #region BOTON AGREGAR FECHA CITAS
        private void btnFechaCita_Click(object sender, EventArgs e)
        {
            wfFechasCitas.Agregar(ref dtSesionesCitas);
            if(dtSesionesCitas.Rows.Count > 0)
            {
               lblMensajeFecha.Text = Convert.ToString(dtSesionesCitas.Rows[0].ItemArray[1]);
                lblMensajeFecha.ForeColor = Color.Black;
            }
        }
        #endregion

        #region BOTON FIRMA
        private void btnFirma_Click(object sender, EventArgs e)
        {
         //   wfFirma.Agregar(ref Firma);
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult Res;
            if (Obligatorios())
            {
                CapturaPantalla();
                strCitas.idCliente = idCliente;
                strCitas.idEstadoCita = Convert.ToInt32(IDsEstadoCita[cbxEstadoCita.SelectedIndex]);
                strCitas.idTamaño = Convert.ToInt32(IDsTamaños[cbxTamaño.SelectedIndex]);
                strCitas.Costo = Convert.ToDouble(txtCosto.Text.Trim());
                strCitas.Anticipo = Convert.ToDouble(txtAnticipo.Text.Trim());
                strCitas.Descripcion = txtDescripcion.Text.Trim();
                strCitas.USUARIO = USUARIO;
                DTImagenesTatto();
                EncodePeFI();

                // bool Agregado = TABLA_Citas.DAO(ref strCitas, 1, dtCitasInventario, dtSesionesCitas, dtImagenesTatto);
                Res = wfFirma.Agregar(ref strCitas, dtSesionesCitas, dtCitasInventario, dtImagenesTatto, Correo);
                if(Res == DialogResult.OK)
                {
                    this.Close();
                }
            }
            
        }

        #endregion

        #region LLENAR DTIMAGENTATTO
        private void DTImagenesTatto()
        {
            dtImagenesTatto.Columns.Add("idImagenTattoo", typeof(int));
            dtImagenesTatto.Columns.Add("ImagenTattoo", typeof(string));
            dtImagenesTatto.Columns.Add("ELIMINADO", typeof(bool));
            for (int i = 0; i < imgList.Count; i++)
            {
                String imgTAT = Herramientas.encodeImagen(imgList[i]);
                dtImagenesTatto.Rows.Add(0, imgTAT, 0);
            }
        }
        #endregion

        #region ENCODE PERFIL
        private void EncodePeFI()
        {
            String ImgZon = Herramientas.encodeImagen(imgZonaCuerpo);
            strCitas.ZonaCuerpo = ImgZon;
        }
        #endregion

        #region BOTON ELIMINAR IMAGEN TATUAJES
        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < imgList.Count; i++)
            {
                if(PosicionImg == i)
                {
                    imgList.Remove(imgList[i]);
                }
                if(imgList.Count == 0)
                {
                    ptbTatuaje.Image.Dispose();
                    ptbTatuaje.Image = null;
                }
            }
            PosicionImg = 0;
            CarruselImagen(PosicionImg);
        }
        #endregion

        #region ENABLE BUTTONS
        private void EnableButtons()
        {
            if(imgList.Count == 0)
            {
                btnEliminarImagen.Enabled = false;
            }
            else
            {
                btnEliminarImagen.Enabled = true;
            }
        }
        #endregion

        #region CAPTURA DE PANTALLA
        private void CapturaPantalla()
        {
            Bitmap BmpScreen = new Bitmap(ptbPerfil.Size.Width, ptbPerfil.Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics ScreenShot = Graphics.FromImage(BmpScreen);
            ScreenShot.CopyFromScreen(ptbPerfil.Location.X + this.Location.X + gbInfoTatuajes.Location.X, ptbPerfil.Location.Y + this.Location.Y + gbInfoTatuajes.Location.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            string fileNom = String.Empty;
            saveFileDialog1.Filter = "Excel files (*.png)|*.png";
            saveFileDialog1.RestoreDirectory = true;
            fileNom = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\SISTEMA.WINFORMS.CAPTURAS.TATOO\Capturas\Img" + Convert.ToString(rnd.Next(10000)) + ".png");
            imgZonaCuerpo = fileNom;
            BmpScreen.Save(fileNom, System.Drawing.Imaging.ImageFormat.Png);
        }
        #endregion

        #region CAMPOS OBLIGATORIOS
        private bool Obligatorios()
        {
            bool Minoro = true;
            if(dtSesionesCitas.Rows.Count == 0)
            {
                Minoro = false;
            }

            if(txtCosto.Text.Trim() == "")
            {
                obligatorioCosto.Visible = true;
                Minoro = false;
            }
            else
            {
                obligatorioCosto.Visible = false;
            }

            if(txtAnticipo.Text.Trim() == "")
            {
                obligastorioAnticipo.Visible = true;
                Minoro = false;
            }
            else
            {
                obligastorioAnticipo.Visible = false;
            }

            if(dtCitasInventario.Rows.Count == 0)
            {
                obligatorioInstrumentos.Visible = true;
                Minoro = false;
            }
            else
            {
                obligatorioInstrumentos.Visible = false;
            }

            if(Rectangulos.Length == 0)
            {
                obligatorioZona.Visible = true;
                Minoro = false;
            }
            else
            {
                obligatorioZona.Visible = false;
            }

            if(imgList.Count == 0)
            {
                obligatorioTatuaje.Visible = true;
                Minoro = false;
            }
            else
            {
                obligatorioTatuaje.Visible = false;
            }

            if(Minoro == false)
            {
                lblObligatorio.Visible = true;
            }
            else
            {
                lblObligatorio.Visible = false;
            }
            return Minoro;
        }
        #endregion

    }
}

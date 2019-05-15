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
using System.IO;
using System.Collections;
using System.Drawing.Imaging;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_MDF2 : Form
    {
        public frmTATCitasCAP_MDF2()
        {
            InitializeComponent();
        }


        #region OBJETOS
        public string USUARIO;
        public string NombreCliente;
        public string Telefono;
        public int idCliente;
        public string Firma = "";
        public int idCita;
        public int IDTamaño;
        public int IDEstadoCita;
        public bool Sexo;

        bool costo = false;
        bool anticipo = false;

        int PosicionImg = 0;
        string imgZonaCuerpo;

       // List<String> imgListBase64 = new List<String>();
       // List<String> imgListDireccion = new List<String>();
        List<String> imgListDefinitiva = new List<String>();
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

        TATImagenesTattoo.strTATImagenesTattoo[] ARR_ImagenesTattoo;
        TATImagenesTattoo.strTATImagenesTattoo strImagenesTattoo = new TATImagenesTattoo.strTATImagenesTattoo();
        TATImagenesTattoo TABLA_ImagenesTattoo = new TATImagenesTattoo();

        TATCitasInventario.strTATCitasInventario[] ARR_CitasInventario;
        TATCitasInventario.strTATCitasInventario strCitasInventario = new TATCitasInventario.strTATCitasInventario();
        TATCitasInventario TABLA_CitasInventario = new TATCitasInventario();

        TATSesionesCitas.strTATSesionesCitas[] ARR_SesionesCitas;
        TATSesionesCitas.strTATSesionesCitas strSesionesCitas = new TATSesionesCitas.strTATSesionesCitas();
        TATSesionesCitas TABLA_SesionesCitas = new TATSesionesCitas();

        #region WAFLES
        wfCitasInventario wfCitasInventario = new wfCitasInventario();
        wfSesionesCitas wfFechasCitas = new wfSesionesCitas();
        wfTATFirma wfFirma = new wfTATFirma();
        #endregion

        #region DATA TABLES
        DataTable dtImagenesTatto = new DataTable();
        DataTable dtCitasInventario = new DataTable();
        DataTable dtSesionesCitas = new DataTable();

        DataTable dtImagenesAUX = new DataTable();
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
                foreach(TATEstadoCita.strTATEstadoCita Dato in ARR_EstadoCita)
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
                cbxTamaño.Items.Add("NO HAY REGISTROS");
                cbxTamaño.SelectedIndex = 0;
            }
        }
        #endregion

        #region FILL DATOS CLIENTES
        private void FillDatosClientes()
        {
            strClientes.idCliente = idCliente;
            TABLA_Clientes.Listar(ref ARR_Clientes, strClientes);
            foreach(TATClientes.strTATClientes Dato in ARR_Clientes)
            {
                strClientes.Sexo = Dato.Sexo;
            }
            Sexo = strClientes.Sexo;
        }
        #endregion

        #region BOTON LIMPIAR PERFIL
        private void btnLimpiarPerfil_Click(object sender, EventArgs e)
        {
            Rectangulos = new Rectangle[0];
            if (Sexo)
            {
                ptbPerfil.Image.Dispose();
                ptbPerfil.Image = null;
                ptbPerfil.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.PerfilHombre;
            }
            else
            {
                ptbPerfil.Image.Dispose();
                ptbPerfil.Image = null;
                ptbPerfil.Image = global::SISTEMA.WINFORMS.CAPTURAS.TATOO.Properties.Resources.PerfilMujer;
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

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CLOSE
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region LOAD
        private void frmTATCitasCAP_MDF2_Load(object sender, EventArgs e)
        {
            InicializaImg();
            FillComboEstadoCita();
            FillComboTamaños();
            FillDatosClientes();
            FILLIMGLIST();
            LLenarDTAUX();
            FILLDTINVENTARIOCITAS();
            FILLDTSESIONESCITAS();
            ValidaIzDe();
            EnableButtons();
            CarruselImagen(0);
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

        #region FILL IMG LIST
        private void FILLIMGLIST()
        {
            TABLA_ImagenesTattoo.Listar(ref ARR_ImagenesTattoo, idCita);
            foreach(TATImagenesTattoo.strTATImagenesTattoo Dato in ARR_ImagenesTattoo)
            {
                if (!Dato.ELIMINADO)
                {
                    imgListDefinitiva.Add(Dato.ImagenTatto);
                    dtImagenesTatto.Rows.Add(Dato.idImagenTattoo, Dato.ImagenTatto, Dato.ELIMINADO);
                } 
            }
        }
        #endregion

        #region FILL DT INVENTARIO CITAS
        private void FILLDTINVENTARIOCITAS()
        {
            CrearDTCitasInventario();
            TABLA_CitasInventario.Listar(ref ARR_CitasInventario, idCita);
            foreach(TATCitasInventario.strTATCitasInventario Dato in ARR_CitasInventario)
            {
                dtCitasInventario.Rows.Add(Dato.idCitaInventario, Dato.idInventario, Dato.Cantidad, Dato.ELIMINADO);
            }
        }
        #endregion

        #region FILL DT SESIONES CITAS
        private void FILLDTSESIONESCITAS()
        {
            CrearDTSesionesCitas();
            TABLA_SesionesCitas.Listar(ref ARR_SesionesCitas, idCita);
            foreach(TATSesionesCitas.strTATSesionesCitas Dato in ARR_SesionesCitas)
            {
                dtSesionesCitas.Rows.Add(Dato.idSesionCita, Dato.FechaCita, Dato.ELIMINADO);
            }
            lblMensajeFecha.Text = dtSesionesCitas.Rows[0].ItemArray[1].ToString();
            lblMensajeFecha.ForeColor = Color.Black;
        }
        #endregion

        #region LLENAR DATA TABLE AUX DE IMAGENES
        private void LLenarDTAUX()
        {
            dtImagenesAUX.Clear();
            foreach (DataRow dr in dtImagenesTatto.Rows)
            {
                if(Convert.ToBoolean(dr["ELIMINADO"]) == false)
                {
                    dtImagenesAUX.Rows.Add(dr["idImagenTattoo"], dr["ImagenTattoo"], dr["ELIMINADO"]);
                }
            }
        }
        #endregion

        #region CARRUSEL

        #region ENCONTRAR IMAGEN CARRUSEL
        private void CarruselImagen(int Posicion)
        {
            int z = 0;
            foreach(DataRow dr in dtImagenesAUX.Rows)
            {
                if (z == Posicion && Convert.ToBoolean(dr["ELIMINADO"]) == false)
                {
                    ptbTatuaje.Image = Herramientas.decodeImagen(dr["ImagenTattoo"].ToString(), ".png");
                    break;
                }
                z++;
            }
            ValidaIzDe();
            EnableButtons();
        }
        #endregion

        #region AGREGAR IMAGEN EN EL ARREGLO
        private void AgregarImagenArreglo(string img)
        {
            //imgListDireccion.Add(img);
            //imgListDefinitiva.Add(img);
            String imgTat = Herramientas.encodeImagen(img);
            imgListDefinitiva.Add(imgTat);
            dtImagenesTatto.Rows.Add(0, imgTat, 0);
            LLenarDTAUX();
            if (imgListDefinitiva.Count == 1)
            {
                PosicionImg = 0;
            }
            else
            {
                PosicionImg = imgListDefinitiva.Count - 1;
            }
            EnableButtons();
            ValidaIzDe();
        }
        #endregion

        #region ENABLE BUTTONS
        private void EnableButtons()
        {
            if (imgListDefinitiva.Count == 0)
            {
                btnEliminarImagen.Enabled = false;
            }
            else
            {
                btnEliminarImagen.Enabled = true;
            }
        }
        #endregion

        #region PTBDERECHA
        private void ptbDerecha_Click(object sender, EventArgs e)
        {
            PosicionImg++;
            CarruselImagen(PosicionImg);
        }
        #endregion

        #region PTBIZQUIERDA
        private void ptbIzquierda_Click(object sender, EventArgs e)
        {
            PosicionImg--;
            CarruselImagen(PosicionImg);
        }
        #endregion

        #region VALIDAR DERECHA IZQUIERDA
        private void ValidaIzDe()
        {
            if (PosicionImg == 0)
            {
                ptbDerecha.Visible = false;
                ptbIzquierda.Visible = false;
            }
            if (PosicionImg == 0 && imgListDefinitiva.Count > 1)
            {
                ptbDerecha.Visible = true;
                ptbIzquierda.Visible = false;
            }
            if (PosicionImg > 0 && PosicionImg == imgListDefinitiva.Count - 1)
            {
                ptbDerecha.Visible = false;
                ptbIzquierda.Visible = true;
            }
            if (PosicionImg > 0 && PosicionImg == imgListDefinitiva.Count - 2)
            {
                ptbDerecha.Visible = true;
                ptbIzquierda.Visible = true;
            }
        }
        #endregion

        #endregion

        #region BOTON ADJUNTAR IMAGEN
        private void btnAdjuntarImagen_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region BOTON FIRMA
        private void btnFirma_Click(object sender, EventArgs e)
        {
            wfFirma.Modificar(ref Firma);
        }
        #endregion

        #region BOTON INSTRUMENTOS
        private void btnProductos_Click(object sender, EventArgs e)
        {
            wfCitasInventario.Modiificar(ref dtCitasInventario);
        }
        #endregion

        #region CREAR DT CITAS INVENTARIO
        private void CrearDTCitasInventario()
        {
            dtCitasInventario.Columns.Add("idCitaInventario", typeof(int));
            dtCitasInventario.Columns.Add("idInventario", typeof(int));
            dtCitasInventario.Columns.Add("Cantidad", typeof(int));
            dtCitasInventario.Columns.Add("ELIMINADO", typeof(bool));
        }
        #endregion

        #region CREAR DT SESIONES CITAS
        private void CrearDTSesionesCitas()
        {
            dtSesionesCitas.Columns.Add("idSesionCita", typeof(int));
            dtSesionesCitas.Columns.Add("FechaCita", typeof(DateTime));
            dtSesionesCitas.Columns.Add("ELIMINADO", typeof(bool));
        }
        #endregion

        #region BOTON ELIMINAR IMAGEN
        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < imgListDefinitiva.Count; i++)
            {
                if (PosicionImg == i)
                {
                    imgListDefinitiva.Remove(imgListDefinitiva[i]);
                }
                if (imgListDefinitiva.Count == 0)
                {
                    ptbTatuaje.Image.Dispose();
                    ptbTatuaje.Image = null;
                }
            }
            PosicionImg = 0;
            CarruselImagen(PosicionImg);
        }
        #endregion

        #region BOTON FECHA SESIONES
        private void btnFechaCita_Click(object sender, EventArgs e)
        {
            wfFechasCitas.Modificar(ref dtSesionesCitas);
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

        #region LLENAR DTIMAGENTATTO
        private void DTImagenesTatto()
        {
            
            foreach(TATImagenesTattoo.strTATImagenesTattoo Dato in ARR_ImagenesTattoo)
            {
                for (int i = 0; i < imgListDefinitiva.Count; i++)
                {

                    if(imgListDefinitiva[i] == Dato.ImagenTatto)
                    {
                        dtImagenesTatto.Rows.Add(Dato.idImagenTattoo, imgListDefinitiva[i], 0);
                    }
                    
                }
            }
            
        }
        #endregion

        #region INICIALIZA DT IMAGENEES
        private void InicializaImg()
        {
            dtImagenesTatto.Columns.Add("idImagenTattoo", typeof(int));
            dtImagenesTatto.Columns.Add("ImagenTattoo", typeof(string));
            dtImagenesTatto.Columns.Add("ELIMINADO", typeof(bool));

            dtImagenesAUX.Columns.Add("idImagenTattoo", typeof(int));
            dtImagenesAUX.Columns.Add("ImagenTattoo", typeof(string));
            dtImagenesAUX.Columns.Add("ELIMINADO", typeof(bool));
        }
        #endregion

        #region ENCODE PERFIL
        private void EncodePeFI()
        {
            String ImgZon = Herramientas.encodeImagen(imgZonaCuerpo);
            strCitas.ZonaCuerpo = ImgZon;
          //  File.Delete(imgZonaCuerpo);
        }
        #endregion

        private void btnAdjuntarImagen_Click_1(object sender, EventArgs e)
        {
            DialogResult Resultado = openFileDialog1.ShowDialog();
            try
            {
                if (Resultado == DialogResult.OK)
                {
                    ptbTatuaje.Image = Image.FromFile(openFileDialog1.FileName);
                    AgregarImagenArreglo(openFileDialog1.FileName);
                }
            }
            catch
            {

            }
        }

        private void btnEliminarImagen_Click_1(object sender, EventArgs e)
        {

            bool Cambio = false;
            for (int i = 0; i < dtImagenesTatto.Rows.Count; i++)
            {
                if (PosicionImg == i)
                {
                    foreach(DataRow dr in dtImagenesTatto.Rows)
                    {
                        int z = 0;
                        if (dr["ImagenTattoo"].Equals(imgListDefinitiva[i]) && Convert.ToInt32(dr["idImagenTattoo"]) != 0)
                        {
                            dr["ELIMINADO"] = true;
                            imgListDefinitiva.Remove(imgListDefinitiva[i]);
                            Cambio = true;
                            break;
                        }
                        else if(dr["ImagenTattoo"].Equals(imgListDefinitiva[i]) && Convert.ToInt32(dr["idImagenTattoo"]) == 0)
                        {
                            z = EncontrarPosicion(dr["ImagenTattoo"].ToString());
                            dtImagenesTatto.Rows.RemoveAt(z);
                            imgListDefinitiva.Remove(imgListDefinitiva[i]);
                            Cambio = true;
                            break;
                        }
                        z++;
                    }
                }
                if (!Cambio && PosicionImg == i)
                {
                    imgListDefinitiva.Remove(imgListDefinitiva[i]);
                }
                if (imgListDefinitiva.Count == 0)
                {
                    ptbTatuaje.Image.Dispose();
                    ptbTatuaje.Image = null;
                    LLenarDTAUX();
                    CarruselImagen(0);
                    return;
                }
            }
            LLenarDTAUX();
            PosicionImg = 0;
            CarruselImagen(PosicionImg);
        }

        #region ECONTRAPOSICION
        private int EncontrarPosicion(string imagen)
        {
            int i = 0;
            foreach(DataRow row in dtImagenesTatto.Rows)
            {
                if (row["ImagenTattoo"].Equals(imagen))
                {
                    break;
                }
                i++;
            }
            return i;
        }
        #endregion

        private void ptbIzquierda_Click_1(object sender, EventArgs e)
        {
            PosicionImg--;
            CarruselImagen(PosicionImg);
        }

        private void ptbDerecha_Click_1(object sender, EventArgs e)
        {
            PosicionImg++;
            CarruselImagen(PosicionImg);
        }

        #region MOUSE CLICK
        private void ptbPerfil_MouseClick_1(object sender, MouseEventArgs e)
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
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON FECHACITAS
        private void btnFechaCita_Click_1(object sender, EventArgs e)
        {
            wfFechasCitas.Modificar(ref dtSesionesCitas);
            for (int i = 0; i < dtSesionesCitas.Rows.Count; i++)
            {
                if(Convert.ToBoolean(dtSesionesCitas.Rows[i].ItemArray[2]) == true)
                {
                    lblMensajeFecha.Text = "Fecha no asignada*";
                    lblMensajeFecha.ForeColor = Color.Red;
                }
                else
                {
                    lblMensajeFecha.Text = dtSesionesCitas.Rows[i].ItemArray[1].ToString();
                    lblMensajeFecha.ForeColor = Color.Black;
                    break;
                }
            }
        }

        #endregion

        #region BOTON PRODUCTOS
        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            wfCitasInventario.Modiificar(ref dtCitasInventario);
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            if (Obligatorios())
            {
                CapturaPantalla();
                strCitas.idCliente = idCliente;
                strCitas.idEstadoCita = Convert.ToInt32(IDsEstadoCita[cbxEstadoCita.SelectedIndex]);
                strCitas.idTamaño = Convert.ToInt32(IDsTamaños[cbxTamaño.SelectedIndex]);
                strCitas.Costo = Convert.ToDouble(txtCosto.Text.Trim());
                strCitas.Anticipo = Convert.ToDouble(txtAnticipo.Text.Trim());
                strCitas.Descripcion = txtDescripcion.Text.Trim();
                strCitas.Firma = Firma;
                strCitas.USUARIO = USUARIO;
                strCitas.idCita = idCita;
                strCitas.EstadoCorreo = false;
                EncodePeFI();

                bool Agregado = TABLA_Citas.DAO(ref strCitas, 2, dtCitasInventario, dtSesionesCitas, dtImagenesTatto);

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
                MessageBox.Show(this, "Algunos Campos Se Encuentran Vacios", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region CAMPOS OBLIGATORIOS
        private bool Obligatorios()
        {
            bool Minoro = true;
            for (int i = 0; i < dtSesionesCitas.Rows.Count; i++)
            {
                if(Convert.ToBoolean(dtSesionesCitas.Rows[i].ItemArray[2]) == true)
                {
                    Minoro = false;
                }
            }
            

            if (txtCosto.Text.Trim() == "")
            {
                obligatorioCosto.Visible = true;
                Minoro = false;
            }
            else
            {
                obligatorioCosto.Visible = false;
            }

            if (txtAnticipo.Text.Trim() == "")
            {
                obligastorioAnticipo.Visible = true;
                Minoro = false;
            }
            else
            {
                obligastorioAnticipo.Visible = false;
            }

            for (int i = 0; i < dtCitasInventario.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dtCitasInventario.Rows[i].ItemArray[3]) == true)
                {
                    obligatorioInstrumentos.Visible = true;
                    Minoro = false;
                }
                else
                {
                    obligatorioInstrumentos.Visible = false;
                    break;
                }
            }
            

            if (imgListDefinitiva.Count == 0)
            {
                obligatorioTatuaje.Visible = true;
                Minoro = false;
            }
            else
            {
                obligatorioTatuaje.Visible = false;
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

            if (Minoro == false)
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

        private void btnLimpiarPerfil_Click_1(object sender, EventArgs e)
        {
            if (strClientes.Sexo)
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

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            if (txtCosto.Text != "")
            {
                txtAnticipo.Enabled = true;
            }
            else
            {
                txtAnticipo.Enabled = false;
            }
        }

        private void txtAnticipo_TextChanged(object sender, EventArgs e)
        {
            if (txtAnticipo.Text != "" && anticipo)
            {
                if (Convert.ToInt32(txtAnticipo.Text) > Convert.ToInt32(txtCosto.Text))
                {
                    txtAnticipo.Text = "";
                    MessageBox.Show("El anticipo no puede ser mayor al costo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                anticipo = true;
            }
        }
    }
}

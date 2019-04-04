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

        int PosicionImg = 0;
        string imgTatuaje;
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
            
            for (int i = 0; i <= imgList.Count; i++)
            {
                if(i == Posicion)
                {
                    ptbTatuaje.Image = Image.FromFile(imgList[i]);
                }
            }

            ValidaIzDe();
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
            wfCitasInventario.Agregar(ref dtCitasInventario);
        }
        #endregion

        private void btnFechaCita_Click(object sender, EventArgs e)
        {
            wfFechasCitas.Agregar(ref dtSesionesCitas);
        }
    }
}

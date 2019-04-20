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

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_MOS : Form
    {
        public frmTATCitasCAP_MOS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public int idCita;
        int PosicionImg = 0;
        List<String> imgListDefinitiva = new List<String>();
        TATImagenesTattoo TABLA_ImagenesTattoo = new TATImagenesTattoo();
        TATCitasInventario TABLA_CitasInventario = new TATCitasInventario();
        TATSesionesCitas TABLA_SesionesCitas = new TATSesionesCitas();
        TATImagenesTattoo.strTATImagenesTattoo[] ARR_ImagenesTattoo;
        TATCitasInventario.strTATCitasInventario[] ARR_CitasInventario;
        TATSesionesCitas.strTATSesionesCitas[] ARR_SesionesCitas;

        DataTable dtSesionesCitas = new DataTable();
        DataTable dtCitasInventario = new DataTable();
        wfCitasInventario wfCitasInventario = new wfCitasInventario();
        wfSesionesCitas wfSesionesCitas = new wfSesionesCitas();
        
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        #region FILL IMG LIST
        private void FILLIMGLIST()
        {
            TABLA_ImagenesTattoo.Listar(ref ARR_ImagenesTattoo, idCita);
            foreach (TATImagenesTattoo.strTATImagenesTattoo Dato in ARR_ImagenesTattoo)
            {
                imgListDefinitiva.Add(Dato.ImagenTatto);
            }
        }
        #endregion

        #region CARRUSEL

        #region ENCONTRAR IMAGEN CARRUSEL
        private void CarruselImagen(int Posicion)
        {
            if (imgListDefinitiva.Count > 0)
            {
                for (int i = 0; i <= imgListDefinitiva.Count; i++)
                {
                    if (i == Posicion)
                    {
                        ptbTatuaje.Image = Herramientas.decodeImagen(imgListDefinitiva[i], ".png");
                    }

                }
            }


            ValidaIzDe();

        }
        #endregion

        #region AGREGAR IMAGEN EN EL ARREGLO
        private void AgregarImagenArreglo(string img)
        {
            //imgListDireccion.Add(img);
            //imgListDefinitiva.Add(img);
            String imgTat = Herramientas.encodeImagen(img);
            imgListDefinitiva.Add(imgTat);
            if (imgListDefinitiva.Count == 1)
            {
                PosicionImg = 0;
            }
            else
            {
                PosicionImg = imgListDefinitiva.Count - 1;
            }

            ValidaIzDe();
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

        private void frmTATCitasCAP_MOS_Load(object sender, EventArgs e)
        {
            FILLDTSESIONESCITAS();
            FILLDTINVENTARIOCITAS();
            FILLIMGLIST();
            ValidaIzDe();
            CarruselImagen(0);
        }

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


        #region FILL DT INVENTARIO CITAS
        private void FILLDTINVENTARIOCITAS()
        {
            CrearDTCitasInventario();
            TABLA_CitasInventario.Listar(ref ARR_CitasInventario, idCita);
            foreach (TATCitasInventario.strTATCitasInventario Dato in ARR_CitasInventario)
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
            foreach (TATSesionesCitas.strTATSesionesCitas Dato in ARR_SesionesCitas)
            {
                dtSesionesCitas.Rows.Add(Dato.idSesionCita, Dato.FechaCita, Dato.ELIMINADO);
            }
            lblFechaCita.Text = dtSesionesCitas.Rows[0].ItemArray[1].ToString();
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

        private void btnProductos_Click(object sender, EventArgs e)
        {
            wfCitasInventario.Mostrar(ref dtCitasInventario);
        }

        private void btnFechaCita_Click(object sender, EventArgs e)
        {
            wfSesionesCitas.Mostrar(ref dtSesionesCitas);
        }
    }
}

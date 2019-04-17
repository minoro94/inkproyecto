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

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATHistorialMedicoRMV : Form
    {
        public frmTATHistorialMedicoRMV()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATClientes.strTATClientes str = new TATClientes.strTATClientes();
        #endregion

        #region CARGAR DATOS
        private void CargarDatos()
        {
            if (str.Hipertension)
            {
                lblHipertension.Text = "Si";
            }
            else
            {
                lblHipertension.Text = "No";
            }

            if (str.Diabetes)
            {
                lblDiabetes.Text = "Si";
            }
            else
            {
                lblDiabetes.Text = "No";
            }

            if (str.Hemofilia)
            {
                lblHemofilia.Text = "Si";
            }
            else
            {
                lblHemofilia.Text = "No";
            }
            if (str.Afecciones)
            {
                lblAfeccionesCardiacas.Text = "Si";
            }
            else
            {
                lblAfeccionesCardiacas.Text = "No";
            }

            if (str.AfeccionesRen)
            {
                lblAfeccionesRenales.Text = "Si";
            }
            else
            {
                lblAfeccionesRenales.Text = "No";
            }

            if (str.FiebreReum)
            {
                lblFiebreReu.Text = "Si";
            }
            else
            {
                lblFiebreReu.Text = "No";
            }

            if (str.Hepatitis)
            {
                lblHepatitis.Text = "Si";
            }
            else
            {
                lblHepatitis.Text = "No";
            }

            if (str.Tuberculosis)
            {
                lblTuberculosis.Text = "Si";
            }
            else
            {
                lblTuberculosis.Text = "No";
            }

            if (str.Sida)
            {
                lblSida.Text = "Si";
            }
            else
            {
                lblSida.Text = "No";
            }

            if (str.Cancer)
            {
                lblCancer.Text = "Si";
            }
            else
            {
                lblCancer.Text = "No";
            }

            if (str.Lupus)
            {
                lblLupus.Text = "Si";
            }
            else
            {
                lblLupus.Text = "No";
            }

            lblOtrasEnfermedades.Text = str.Otros;
            if (str.Embarazo)
            {
                lblEmbarazo.Text = "Si";
            }
            else
            {
                lblEmbarazo.Text = "No";
            }

            lblCuantosMeses.Text = str.Meses.ToString();
            lblAlergias.Text = str.Alergias;
            if (str.DificultadSangrado)
            {
                lblDificultadSangrado.Text = "Si";
            }
            else
            {
                lblDificultadSangrado.Text = "No";
            }

            if (str.OtrasIntervenciones)
            {
                lblIntervenciones.Text = "Si";
            }
            else
            {
                lblIntervenciones.Text = "No";
            }

            lblComplicacion.Text = str.ComplicacionesInterv;
            lblNombreCliente.Text = str.nombreCliente;

            ptbFirma.Image = Herramientas.decodeImagen(str.Firma, ".png");

        }
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

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region LOAD
        private void frmTATHistorialMedicoRMV_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        #endregion

        
    }
}

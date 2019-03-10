using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATTiposEmpleadosMDF : Form
    {
        public frmTATTiposEmpleadosMDF()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATTIpoEmpleados.strTATTipoEmpleados strTipoEmpleados = new TATTIpoEmpleados.strTATTipoEmpleados();
        TATTIpoEmpleados TABLA_TipoEmpleados = new TATTIpoEmpleados();
        TATTiposPermisos.strTATTiposPermisos[] ARRTipoPermisos;
        TATTiposPermisos TABLA_TipoPermisos = new TATTiposPermisos();
        ArrayList IdsTipoPermiso = new ArrayList();
        public int IDTipoPermisos = 0;
        public int IDTiposEmpleados;
        public string USUARIO = "";
        #endregion

        #region FILL COMBO TIPOPERMISO
        private void FillComboTipoPermiso()
        {
            TABLA_TipoPermisos.Listar(ref ARRTipoPermisos);

            foreach (TATTiposPermisos.strTATTiposPermisos dato in ARRTipoPermisos)
            {
                cbxTipoPermiso.Items.Add(dato.nombreTipoPermiso);
                IdsTipoPermiso.Add(dato.idTipoPermiso);
            }
            int pos = 0;
            foreach (object dato in IdsTipoPermiso)
            {
                if (Convert.ToInt32(dato) == IDTipoPermisos)
                {
                    break;
                }
                pos++;
            }
            cbxTipoPermiso.SelectedIndex = pos;
            TABLA_TipoPermisos.Dispose();

        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (txtTipoEmpleado.Text.Trim() == "")
            {
                btnAceptar.Enabled = false;
                Obligatorio.Visible = true;
            }
            else
            {
                btnAceptar.Enabled = true;
                Obligatorio.Visible = false;
            }
        }
        #endregion

        #region TEXT CHANGED
        private void txtTipoEmpleado_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATTiposEmpleadosMDF_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_TipoEmpleados.Dispose();
        }
        #endregion

        #region LOAD
        private void frmTATTiposEmpleadosMDF_Load(object sender, EventArgs e)
        {
            FillComboTipoPermiso();
            EnableButtons();
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            strTipoEmpleados.idTipoEmpleado = IDTiposEmpleados;
            strTipoEmpleados.idTipoPermiso = Convert.ToInt32(IdsTipoPermiso[cbxTipoPermiso.SelectedIndex]);
            strTipoEmpleados.nombreTipoEmpleado = txtTipoEmpleado.Text.Trim();
            strTipoEmpleados.Descripcion = txtDescripcion.Text.Trim();
            strTipoEmpleados.USUARIO = USUARIO;


            if (TABLA_TipoEmpleados.DAO(ref strTipoEmpleados, 2))
            {
                MessageBox.Show(this, "Datos modificados correctamente", "OPERACION CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this, "Error al modificar", "OPERACION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion
    }
}

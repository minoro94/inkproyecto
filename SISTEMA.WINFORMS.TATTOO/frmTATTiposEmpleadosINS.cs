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
    public partial class frmTATTiposEmpleadosINS : Form
    {
        public frmTATTiposEmpleadosINS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATTIpoEmpleados.strTATTipoEmpleados strTipoEmpleado = new TATTIpoEmpleados.strTATTipoEmpleados();
        TATTIpoEmpleados TABLA_TipoEmpleados = new TATTIpoEmpleados();
        public TATTiposPermisos.strTATTiposPermisos strTipoPermisos = new TATTiposPermisos.strTATTiposPermisos();
        TATTiposPermisos TABLA_TipoPermisos = new TATTiposPermisos();
        ArrayList IdsTipoPermiso = new ArrayList();
        TATTiposPermisos.strTATTiposPermisos[] ARRTiposPermisos;
        public string USUARIO;
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (txtTipoEmpleado.Text.Trim() == "")
            {
                btnAceptar.Enabled = false;
                btnAplicar.Enabled = false;
                Obligatorio.Visible = true;
            }
            else
            {
                btnAceptar.Enabled = true;
                btnAplicar.Enabled = true;
                Obligatorio.Visible = false;
            }
        }
        #endregion

        #region FILL COMBO TIPOPERMISO
        private void FillComboTipoPermiso()
        {
            strTipoPermisos.nombreTipoPermiso = "";
            TABLA_TipoPermisos.Listar(ref ARRTiposPermisos);

            foreach (TATTiposPermisos.strTATTiposPermisos dato in ARRTiposPermisos)
            {
                cbxTipoPermiso.Items.Add(dato.nombreTipoPermiso);
                IdsTipoPermiso.Add(dato.idTipoPermiso);
            }
            cbxTipoPermiso.SelectedIndex = 0;
            TABLA_TipoPermisos.Dispose();
        }
        #endregion

        #region LOAD
        private void frmTATTiposEmpleadosINS_Load(object sender, EventArgs e)
        {
            FillComboTipoPermiso();
            EnableButtons();
        }
        #endregion

        #region TEXT CHANGED
        private void txtTipoEmpleado_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region FORMCLOSING
        private void frmTATTiposEmpleadosINS_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_TipoEmpleados.Dispose();
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON APLICAR
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtTipoEmpleado.Text.Trim() != "")
            {
                strTipoEmpleado.nombreTipoEmpleado = txtTipoEmpleado.Text.Trim();
                strTipoEmpleado.idTipoPermiso = Convert.ToInt32(IdsTipoPermiso[cbxTipoPermiso.SelectedIndex]);
                strTipoEmpleado.Descripcion = txtDescripcion.Text.Trim();
                strTipoEmpleado.USUARIO = USUARIO;

                bool agregado = TABLA_TipoEmpleados.DAO(ref strTipoEmpleado, 1);

                if (agregado)
                {
                    MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                    txtTipoEmpleado.Clear();
                    cbxTipoPermiso.Items.Clear();
                    txtDescripcion.Clear();
                }
                else
                {
                    MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtTipoEmpleado.Text.Trim() != "")
            {
                strTipoEmpleado.idTipoPermiso = Convert.ToInt32(IdsTipoPermiso[cbxTipoPermiso.SelectedIndex]);
                strTipoEmpleado.nombreTipoEmpleado = txtTipoEmpleado.Text.Trim();
                strTipoEmpleado.Descripcion = txtDescripcion.Text.Trim();
                strTipoEmpleado.USUARIO = USUARIO;

                bool agregado = TABLA_TipoEmpleados.DAO(ref strTipoEmpleado, 1);

                if (agregado)
                {
                    MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        #endregion

        private void btnBuscarPermiso_Click(object sender, EventArgs e)
        {
            wfTATTiposPermisos WF = new wfTATTiposPermisos();
            WF.Buscar(ref strTipoPermisos);
            for (int i = 0; i < IdsTipoPermiso.Count; i++)
            {
                if (strTipoPermisos.idTipoPermiso == Convert.ToInt32(IdsTipoPermiso[i]))
                {
                    cbxTipoPermiso.SelectedIndex = i;
                }
            }
        }
    }
}

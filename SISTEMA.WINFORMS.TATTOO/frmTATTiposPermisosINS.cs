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
    public partial class frmTATTiposPermisosINS : Form
    {
        public frmTATTiposPermisosINS()
        {
            InitializeComponent();
            Obligatorio.Visible = false;
        }

        #region OBJETOS
        public TATTiposPermisos.strTATTiposPermisos str = new TATTiposPermisos.strTATTiposPermisos();
        TATTiposPermisos TABLA = new TATTiposPermisos();
        public string USUARIO = "";
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if(txtTipoPermiso.Text.Trim() == "")
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

        #region LOAD
        private void frmTATTiposPermisosINS_Load(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region TEXT CHANGED
        private void txtTipoPermiso_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATTiposPermisosINS_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA.Dispose();
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
            if (txtTipoPermiso.Text.Trim() != "")
            {
                str.nombreTipoPermiso = txtTipoPermiso.Text.Trim();
                str.Descripcion = txtDescripcion.Text.Trim();
                str.activo = chkActivo.Checked;
                str.USUARIO = USUARIO;

                bool agregado = TABLA.DAO(ref str, 1);

                if (agregado)
                {
                    MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                    txtTipoPermiso.Clear();
                    txtDescripcion.Clear();
                    chkActivo.Checked = false;
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
            if (txtTipoPermiso.Text.Trim() != "")
            {
                str.nombreTipoPermiso = txtTipoPermiso.Text.Trim();
                str.Descripcion = txtDescripcion.Text.Trim();
                str.activo = chkActivo.Checked;
                str.USUARIO = USUARIO;
                bool agregado = TABLA.DAO(ref str, 1);

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class frmTATTIposPermisosMDF : Form
    {
        public frmTATTIposPermisosMDF()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATTiposPermisos.strTATTiposPermisos str = new TATTiposPermisos.strTATTiposPermisos();
        TATTiposPermisos TABLA = new TATTiposPermisos();
        public int id;
        public string USUARIO = "";
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (txtTipoPermiso.Text.Trim() == "")
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

        #region LOAD
        private void frmTATTIposPermisosMDF_Load(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region TEXTCHANGED
        private void txtTipoPermiso_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATTIposPermisosMDF_FormClosing(object sender, FormClosingEventArgs e)
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

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtTipoPermiso.Text.Trim() != "")
            {
                str.idTipoPermiso = id;
                str.nombreTipoPermiso = txtTipoPermiso.Text.Trim();
                str.Descripcion = txtDescripcion.Text.Trim();
                str.activo = chkActivo.Checked;
                str.USUARIO = USUARIO;

                bool agregado = TABLA.DAO(ref str, 2);

                if (agregado)
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
        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

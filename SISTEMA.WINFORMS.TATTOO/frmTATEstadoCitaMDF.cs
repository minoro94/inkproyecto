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
    public partial class frmTATEstadoCitaMDF : Form
    {
        public frmTATEstadoCitaMDF()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATEstadoCita.strTATEstadoCita str = new TATEstadoCita.strTATEstadoCita();
        TATEstadoCita TABLA = new TATEstadoCita();
        public int id;
        public string USUARIO;
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if(txtNombreEstadoCita.Text.Trim() =="" || txtDescripcion.Text.Trim() == "")
            {
                btnAceptar.Enabled = false;
                lblMnesaje1.Visible = true;
                txtMensaje2.Visible = true;
            }
            else
            {
                btnAceptar.Enabled = true;
                lblMnesaje1.Visible = false;
                txtMensaje2.Visible = false;
            }
        }
        #endregion

        #region LOAD
        private void frmTATEstadoCitaMDF_Load(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region TEXT CHANGED
        private void txtNombreEstadoCita_TextChanged(object sender, EventArgs e)
        {
            if(txtNombreEstadoCita.Text.Trim() != "")
            {
                Obligatorio1.Visible = false;
            }
            else
            {
                Obligatorio1.Visible = true;
            }
            EnableButtons();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            if(txtDescripcion.Text.Trim() != "")
            {
                Obligatorio2.Visible = false;
            }
            else
            {
                Obligatorio2.Visible = true;
            }
        }
        #endregion

        #region FORM CLOSING
        private void frmTATEstadoCitaMDF_FormClosing(object sender, FormClosingEventArgs e)
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

        #region CLOSE
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str.idEstadoCita = id;
            str.NombreEstadoCita = txtNombreEstadoCita.Text.Trim();
            str.Descripcion = txtDescripcion.Text.Trim();
            str.USUARIO = USUARIO;

            bool Agregado = TABLA.DAO(ref str, 2);
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
    }
}

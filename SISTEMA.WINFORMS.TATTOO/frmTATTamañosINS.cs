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
    public partial class frmTATTamañosINS : Form
    {
        public frmTATTamañosINS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATTamaños.strTATTamaños str = new TATTamaños.strTATTamaños();
        TATTamaños TABLA = new TATTamaños();
        public string USUARIO = "";
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if(txtTamaño.Text.Trim() == "")
            {
                btnAceptar.Enabled = false;
                btnAplicar.Enabled = false;
                Obligatorio1.Visible = true;
                lblMnesaje1.Visible = true;
                txtMensaje2.Visible = true;
            }
            else
            {
                btnAceptar.Enabled = true;
                btnAplicar.Enabled = true;
                Obligatorio1.Visible = false;
                lblMnesaje1.Visible = false;
                txtMensaje2.Visible = false;
            }
        }
        #endregion

        #region LOAD
        private void frmTATTamañosINS_Load(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region TEXT CHANGED
        private void txtTamaño_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATTamañosINS_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA.Dispose();
        }
        #endregion

        #region CLOSE
        private void pictureBox1_Click(object sender, EventArgs e)
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
            if (txtTamaño.Text.Trim() != "")
            {
                str.Tamaño = txtTamaño.Text.Trim();
                str.Detalle = txtDetalle.Text.Trim();
                str.USUARIO = USUARIO;

                bool Agregado = TABLA.DAO(ref str, 1);

                if (Agregado)
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

        #region BOTON APLICAR
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (txtTamaño.Text.Trim() != "")
            {
                str.Tamaño = txtTamaño.Text.Trim();
                str.Detalle = txtDetalle.Text.Trim();
                str.USUARIO = USUARIO;

                bool Agregado = TABLA.DAO(ref str, 1);

                if (Agregado)
                {
                    MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                    txtTamaño.Clear();
                    txtDetalle.Clear();
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
    }
}

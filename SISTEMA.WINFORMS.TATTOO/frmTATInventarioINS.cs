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

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATInventarioINS : Form
    {
        public frmTATInventarioINS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATInventario.strTATInventario str = new TATInventario.strTATInventario();
        TATInventario TABLA = new TATInventario();
        public string USUARIO = "";
        public int idUsuario;
        #endregion

        #region CAMPOS OBLIGATORIOS
        private bool Campos()
        {
            if (txtNombreProducto.Text.Trim() == "")
            {
                Obligatorio.Visible = true;
                txtMensaje2.Visible = true;
                lblMnesaje1.Visible = true;
                return false;
            }
            else
            {
                Obligatorio.Visible = false;
                txtMensaje2.Visible = false;
                lblMnesaje1.Visible = false;
                return true;
            }
            
        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (Campos())
            {
                btnAceptar.Enabled = true;
                btnAplicar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
                btnAplicar.Enabled = false;
            }
        }
        #endregion

        #region TEXT CHANGED
        private void txtNombreProducto_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region LOAD
        private void frmTATInventarioINS_Load(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATInventarioINS_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA.Dispose();
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

        #region BOTON APLICAR
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            str.NombreProducto = txtNombreProducto.Text.Trim();
            str.Cantidad = Convert.ToInt32(nudCantidad.Value);
            str.Nota = txtNota.Text.Trim();
            str.USUARIO = USUARIO;
            str.idUsuario = idUsuario;

            bool Agregado = TABLA.DAO(ref str, 1);
            if (Agregado)
            {
                MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.Yes;
                txtNombreProducto.Clear();
                nudCantidad.Value = 0;
                txtNota.Clear();
            }
            else
            {
                MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str.NombreProducto = txtNombreProducto.Text.Trim();
            str.Cantidad = Convert.ToInt32(nudCantidad.Value);
            str.Nota = txtNota.Text.Trim();
            str.USUARIO = USUARIO;
            str.idUsuario = idUsuario;

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
        #endregion
    }
}

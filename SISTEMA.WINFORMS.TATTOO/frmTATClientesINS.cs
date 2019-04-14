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
    public partial class frmTATClientesINS : Form
    {
        public frmTATClientesINS()
        {
            InitializeComponent();
            rdbHombre.Checked = true; 
        }

        #region OBJETOS
        public TATClientes.strTATClientes str = new TATClientes.strTATClientes();
        TATClientes TABLA = new TATClientes();
        public string USUARIO = "";
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            bool A =  true;
            if (!Campos(A))
            {
                btnAceptar.Enabled = false;
                btnAplicar.Enabled = false;
                
            }
            else
            {
                btnAceptar.Enabled = true;
                btnAplicar.Enabled = true;
                
            }
        }
        #endregion

        #region CAMPOS OBLIGATORIOS
        private bool Campos(bool Minoro)
        {
            Minoro = true;
            if(txtNombreCliente.Text.Trim() == "")
            {
                Obligatorio.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio.Visible = false; ;
            }
            if(txtTelefono.Text.Trim() == "")
            {
                Obligatorio2.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio2.Visible = false;
            }
            if(txtCorreo.Text.Trim() == "")
            {
                Obligatorio3.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio3.Visible = false;
            }
            if(txtINE.Text.Trim() == "")
            {
                Obligatorio4.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio4.Visible = false;
            }
            if(txtEdad.Text.Trim() == "")
            {
                Obligatorio5.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio5.Visible = false;
            }
            if(txtDomicilio.Text.Trim() == "")
            {
                Obligatorio6.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio6.Visible = false;
            }
            if(txtMunicipio.Text.Trim() == "")
            {
                Obligatorio7.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio7.Visible = false;
            }
            if(txtCodigoPostal.Text.Trim() == "")
            {
                Obligatorio8.Visible = true;
                Minoro = false;
            }
            else
            {
                Obligatorio8.Visible = false;
            }
            if (Minoro)
            {
                lblMnesaje1.Visible = false;
                txtMensaje2.Visible = false;
            }
            else
            {
                lblMnesaje1.Visible = true;
                txtMensaje2.Visible = true;
            }
            return Minoro;
        }
        #endregion

        #region TEXT CHANGED
        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void txtINE_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
   
        private void txtDomicilio_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void txtMunicipio_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void txtCodigoPostal_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        private void txtHistorialMedico_TextChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region LOAD
        private void frmTATClientesINS_Load(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATClientesINS_FormClosing(object sender, FormClosingEventArgs e)
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
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON APLICAR
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            bool A = true;
            if (Campos(A))
            {
                str.nombreCliente = txtNombreCliente.Text.Trim();
                str.Telefono = txtTelefono.Text.Trim();
                str.Correo = txtCorreo.Text.Trim();
                str.Identificacion = txtINE.Text.Trim();
                str.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                str.Domicilio = txtDomicilio.Text.Trim();
                str.Municipio = txtMunicipio.Text.Trim();
                str.CodigoPostal = txtCodigoPostal.Text.Trim();
                str.USUARIO = USUARIO;
                if(rdbHombre.Checked == true)
                {
                    str.Sexo = true;
                }
                else
                {
                    str.Sexo = false;
                }

                bool Agregado = TABLA.DAO(ref str, 1);
                if (Agregado)
                {
                    MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                    txtNombreCliente.Clear();
                    txtTelefono.Clear();
                    txtCorreo.Clear();
                    txtINE.Clear();
                    txtEdad.Clear();
                    txtDomicilio.Clear();
                    txtMunicipio.Clear();
                    txtCodigoPostal.Clear();
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
            bool A = true;
            if (Campos(A))
            {
                str.nombreCliente = txtNombreCliente.Text.Trim();
                str.Telefono = txtTelefono.Text.Trim();
                str.Correo = txtCorreo.Text.Trim();
                str.Identificacion = txtINE.Text.Trim();
                str.Edad = Convert.ToInt32(txtEdad.Text.Trim());
                str.Domicilio = txtDomicilio.Text.Trim();
                str.Municipio = txtMunicipio.Text.Trim();
                str.CodigoPostal = txtCodigoPostal.Text.Trim();
                str.USUARIO = USUARIO;
                if (rdbHombre.Checked == true)
                {
                    str.Sexo = true;
                }
                else
                {
                    str.Sexo = false;
                }

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

        #region KEY PRESS
        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        
        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        #endregion
    }
}

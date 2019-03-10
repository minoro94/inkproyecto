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
    public partial class frmTATEmpleadosINS : Form
    {
        public frmTATEmpleadosINS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATEmpleados.strTATEmpleados strEmpleados = new TATEmpleados.strTATEmpleados();
        TATEmpleados TABLA_Empleados = new TATEmpleados();

        TATTIpoEmpleados.strTATTipoEmpleados strTiposEmpleados = new TATTIpoEmpleados.strTATTipoEmpleados();
        TATTIpoEmpleados TABLA_TiposEmpleados = new TATTIpoEmpleados();
        ArrayList IDsTiposEmpleados = new ArrayList();
        TATTIpoEmpleados.strTATTipoEmpleados[] ARRTiposEmpleados;

        public string USUARIO = "";

        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (txtNombreEmpleado.Text.Trim() == "" || txtDireccion.Text.Trim() == "")
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

        #region FILL COMBO TIPO EMPLEADO
        private void FillComboTipoEmpleado()
        {
            TABLA_TiposEmpleados.Listar(ref ARRTiposEmpleados);

            try
            {
                foreach(TATTIpoEmpleados.strTATTipoEmpleados Dato in ARRTiposEmpleados)
                {
                    cbxTipoEmpleado.Items.Add(Dato.nombreTipoEmpleado);
                    IDsTiposEmpleados.Add(Dato.idTipoEmpleado);
                }
                cbxTipoEmpleado.SelectedIndex = 0;
                TABLA_TiposEmpleados.Dispose();
            }
            catch
            {

            }
        }

        #endregion

        #region BOTON APLICAR
        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if(txtNombreEmpleado.Text.Trim() != "" && txtDireccion.Text.Trim() != "")
            {
                strEmpleados.nombreEmpleado = txtNombreEmpleado.Text.Trim();
                strEmpleados.idTipoEmpleado = Convert.ToInt32(IDsTiposEmpleados[cbxTipoEmpleado.SelectedIndex]);
                strEmpleados.Direccion = txtDireccion.Text.Trim();
                strEmpleados.Telefono = txtTelefono.Text.Trim();
                strEmpleados.numSeguro = txtNumSeg.Text.Trim();
                strEmpleados.USUARIO = USUARIO;

                bool agregado = TABLA_Empleados.DAO(ref strEmpleados, 1);

                if (agregado)
                {
                    MessageBox.Show(this, "Agregado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.Yes;
                    txtNombreEmpleado.Clear();
                    cbxTipoEmpleado.Items.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    txtNumSeg.Clear();
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
            if (txtNombreEmpleado.Text.Trim() != "" && txtDireccion.Text.Trim() != "")
            {
                strEmpleados.nombreEmpleado = txtNombreEmpleado.Text.Trim();
                strEmpleados.idTipoEmpleado = Convert.ToInt32(IDsTiposEmpleados[cbxTipoEmpleado.SelectedIndex]);
                strEmpleados.Direccion = txtDireccion.Text.Trim();
                strEmpleados.Telefono = txtTelefono.Text.Trim();
                strEmpleados.numSeguro = txtNumSeg.Text.Trim();
                strEmpleados.USUARIO = USUARIO;

                bool agregado = TABLA_Empleados.DAO(ref strEmpleados, 1);

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

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region OBLIGATORIO NOMBRE
        private void txtNombreEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreEmpleado.Text.Trim() != "")
            {
                Obligatorio.Visible = false;
            }
            else
            {
                Obligatorio.Visible = true;
            }
            EnableButtons();
        }

        #endregion

        #region OBLIGATORIO DIRECCION
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (txtDireccion.Text.Trim() != "")
            {
                Obligatorio2.Visible = false;
            }
            else
            {
                Obligatorio2.Visible = true;
            }
            EnableButtons();
        }
        #endregion

        #region LOAD
        private void frmTATEmpleadosINS_Load(object sender, EventArgs e)
        {
            FillComboTipoEmpleado();
            EnableButtons();
        }

        #endregion

        #region FORM CLOSING
        private void frmTATEmpleadosINS_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_Empleados.Dispose();
        }
        #endregion

        #region KEYPRESS TELEFONO
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region KEYPRESS NUM SEGURO
        private void txtNumSeg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsNumber(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras y números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            char[] NoPermitir = { 'é', 'ý', 'ú', 'í', 'ó', 'á', 'ë', 'ÿ', 'ü', 'ï', 'ö', 'ä', 'ê', 'û', 'î', 'ô', 'â', 'Ä', 'Ë', 'Ï', 'Ö', 'Ü', 'Á', 'É', 'Í', 'Ó', 'Ú', 'Ý' };
            if (NoPermitir.Contains(e.KeyChar))
            {
                MessageBox.Show("Carácter no permitido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region KEYPRESS NOMBRE
        private void txtNombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        #endregion

        #region BUSCAR
        private void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            wfTATTiposEmpleados WF = new wfTATTiposEmpleados();
            WF.Buscar(ref strTiposEmpleados);
            for (int i = 0; i < IDsTiposEmpleados.Count; i++)
            {
                if (strTiposEmpleados.idTipoEmpleado == Convert.ToInt32(IDsTiposEmpleados[i]))
                {
                    cbxTipoEmpleado.SelectedIndex = i;
                }
            }
        }
        #endregion

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

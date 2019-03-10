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
    public partial class frmTATEmpleadosRMV : Form
    {
        public frmTATEmpleadosRMV()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATEmpleados.strTATEmpleados strEmpleados = new TATEmpleados.strTATEmpleados();
        TATEmpleados TABLA_Empleados = new TATEmpleados();
        public int ID;
        public string USUARIO = "";
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            strEmpleados.idEmpleado = ID;
            strEmpleados.USUARIO = USUARIO;
            if (TABLA_Empleados.DAO(ref strEmpleados, 3))
            {
                MessageBox.Show(this, "El registro ah sido eliminado correctamente", "OPERACION CORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, "No se ah podido eliminar", "OPERACION INCORRECTA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

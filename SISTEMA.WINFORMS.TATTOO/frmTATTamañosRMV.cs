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
    public partial class frmTATTamañosRMV : Form
    {
        public frmTATTamañosRMV()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATTamaños.strTATTamaños str = new TATTamaños.strTATTamaños();
        TATTamaños TABLA = new TATTamaños();
        public int id;
        public string USUARIO;
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str.idTamaño = id;
            str.USUARIO = USUARIO;
            if(TABLA.DAO(ref str, 3))
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
    }
}

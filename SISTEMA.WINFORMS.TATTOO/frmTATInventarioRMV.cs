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
    public partial class frmTATInventarioRMV : Form
    {
        public frmTATInventarioRMV()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATInventario.strTATInventario str = new TATInventario.strTATInventario();
        TATInventario TABLA = new TATInventario();
        public int id;
        public string USUARIO = "";
        public int idUsuario;
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str.idInventario = id;
            str.idUsuario = idUsuario;
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
    }
}

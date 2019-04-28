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
    public partial class frmTATClientesMOS : Form
    {
        public frmTATClientesMOS()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATClientes.strTATClientes str = new TATClientes.strTATClientes();
        wfTATHistorialMedico wf = new wfTATHistorialMedico();
        #endregion

        private void btnHistorialMedico_Click(object sender, EventArgs e)
        {
            wf.Mostrar(ref str);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

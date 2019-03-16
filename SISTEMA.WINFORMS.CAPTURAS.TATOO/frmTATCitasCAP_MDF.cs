using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_MDF : Form
    {
        public frmTATCitasCAP_MDF()
        {
            InitializeComponent();
        }

        public int IDTamaño;
        public int IDEstadoCita;
        public string USUARIO;

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA.WINFORMS.CAPTURAS.TATTOO
{
    public partial class frmTATCitasCAT_INS : Form
    {
        public frmTATCitasCAT_INS()
        {
            InitializeComponent();
            ptbAbajo.Visible = true;
            ptbDerecha.Visible = false;
        }

        private void PanelInfoTatuaje_MouseDown(object sender, MouseEventArgs e)
        {
            if(gbInfoTatuajes.Visible)
            {
                gbInfoTatuajes.Visible = false;
                ptbAbajo.Visible = false;
                ptbDerecha.Visible = true;
            }
            else
            {
                gbInfoTatuajes.Visible = true;
                ptbDerecha.Visible = false;
                ptbAbajo.Visible = true;
            }
        }
    }
}

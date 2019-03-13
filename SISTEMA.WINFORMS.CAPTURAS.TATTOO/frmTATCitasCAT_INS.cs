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
                this.Size = new System.Drawing.Size(1333, 263);
                btnAceptar.Location = new Point(1135, 214);
                btnAplicar.Location = new Point(1039, 214);
                btnCancelar.Location = new Point(1231, 214);
                PanelBorderAbajo.Location = new Point(3, 259);
            }
            else
            {
                gbInfoTatuajes.Visible = true;
                ptbDerecha.Visible = false;
                ptbAbajo.Visible = true;
                this.Size = new System.Drawing.Size(1333, 695);
                btnAceptar.Location = new Point(1039, 650);
                btnAplicar.Location = new Point(1135, 650);
                btnCancelar.Location = new Point(1234, 650);
                PanelBorderAbajo.Location = new Point(3, 691);
            }
        }
    }
}

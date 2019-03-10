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

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATCitasINS : Form
    {
        public frmTATCitasINS()
        {

            InitializeComponent();
            ptbAbajo.Visible = true;
            ptbDerecha.Visible = false;
        }

        Rectangle [] ARREGLO;
        int i = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        

        

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
                btnAceptar.Location = new Point(1135, 214);
                btnAplicar.Location = new Point(1039, 214);
                btnCancelar.Location = new Point(1231, 214);
                this.Size = new System.Drawing.Size(1333, 263);
                ptbAbajo.Visible = false;
                ptbDerecha.Visible = true;
                PanelAbajo.Location = new Point(3, 259);
            }
            else
            {
                panel1.Visible = true;
                btnAceptar.Location = new Point(1039, 650);
                btnAplicar.Location = new Point(1135, 650);
                btnCancelar.Location = new Point(1234, 650);
                this.Size = new System.Drawing.Size(1333, 695);
                ptbDerecha.Visible = false;
                ptbAbajo.Visible = true;
                PanelAbajo.Location = new Point(3, 691);
            }
        }

        #region DIBUJAR
        private void dibuja(int x, int y)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = pictureBox2.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Red, 5);
            Rectangle myRectangle = new Rectangle(x - 758, y - 450, 5, 5);
            graphicsObj.DrawEllipse(myPen, myRectangle);
            ARREGLO[i] = myRectangle;
            i++;
        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            
        }

        public void EliminaPunto()
        {
            ARREGLO = new Rectangle[ARREGLO.Length - 1]; 
            for (int i = 0; i < ARREGLO.Length; i++)
            {

            }
        }


        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                pictureBox2.Refresh();
            }
            else
            {
                int x = MousePosition.X;
                int y = MousePosition.Y;
                dibuja(x, y);
            }
        }
    }
}

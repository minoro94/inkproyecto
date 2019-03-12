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
        int i = 1;
        Rectangle[] ARREGLO;
        

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
        private void dibuja(int x, int y, bool decision)
        {
            ARREGLO = new Rectangle[i];
            if (decision)
            {
                int a = panel1.Location.Y + pictureBox2.Location.Y + this.Location.Y + 4;
                int b = panel1.Location.X + pictureBox2.Location.X + this.Location.X + 4;
                int X = x - b;
                int Y = y - a;
                System.Drawing.Graphics graphicsObj;
                graphicsObj = pictureBox2.CreateGraphics();
                Pen myPen = new Pen(System.Drawing.Color.Red, 5);
                Rectangle myRectangle = new Rectangle(X, Y, 5, 5);
                graphicsObj.DrawEllipse(myPen, myRectangle);
                for (int i = 0; i < ARREGLO.Length; i++)
                {
                    
                    if(ARREGLO[0].Y == 0 && ARREGLO[0].X == 0 && X != ARREGLO[i].X && ARREGLO[i].Y != Y)
                    {
                        ARREGLO[i] = myRectangle;
                    }
                    
                }
                i++;
            }
            else
            {
                EliminaPunto();
            }
            
            
        }
        #endregion

       

        public void EliminaPunto()
        {
            ARREGLO = new Rectangle[ARREGLO.Length - 1]; 
            for (int i = 0; i < ARREGLO.Length; i++)
            {
                Rectangle myRectangle = new Rectangle(ARREGLO[i].X, ARREGLO[i].Y, 5, 5);
            }
            i--;
        }


        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            int x = MousePosition.X;
            int y = MousePosition.Y;
            if (e.Button == MouseButtons.Right)
            {
                pictureBox2.Refresh();
                dibuja(x, y, false);
            }
            else
            {
                
                dibuja(x, y, true);
            }
        }
    }
}

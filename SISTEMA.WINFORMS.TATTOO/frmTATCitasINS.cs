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

        Rectangle[] ARREGLO = new Rectangle[0];
        

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
                pictureBox2.Refresh();
                dibuja(1000,0,true);
            }
        }

        #region DIBUJAR
        private void dibuja(int x, int y, bool decision)
        {
            Rectangle[] Aux = new Rectangle[ARREGLO.Length + 1];
            int au = 0;
            if (decision && x != 1000)
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
                    Aux[i] = ARREGLO[i];
                    au = i+1;
                }
                Aux[au] = myRectangle;

                ARREGLO = new Rectangle[Aux.Length];
                for (int i = 0; i < ARREGLO.Length; i++)
                {
                    ARREGLO[i] = Aux[i];
                }

                
            }
            else if (x == 1000)
            {
                for (int i = 0; i < ARREGLO.Length; i++)
                {
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = pictureBox2.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 5);
                    Rectangle myRectangle = new Rectangle(ARREGLO[i].X, ARREGLO[i].Y, 5, 5);
                    graphicsObj.DrawEllipse(myPen, myRectangle);
                }
            }
            else
            {
                EliminaPunto();
            }
            
            
            
        }
        #endregion

       

        public void EliminaPunto()
        {
            if(ARREGLO.Length == 0)
            {

            }
            else
            {
                Rectangle[] aux = new Rectangle[ARREGLO.Length - 1];
                for (int i = 0; i < aux.Length; i++)
                {
                    aux[i] = ARREGLO[i];
                    System.Drawing.Graphics graphicsObj;
                    graphicsObj = pictureBox2.CreateGraphics();
                    Pen myPen = new Pen(System.Drawing.Color.Red, 5);
                    Rectangle myRectangle = new Rectangle(aux[i].X, aux[i].Y, 5, 5);
                    graphicsObj.DrawEllipse(myPen, myRectangle);

                }
                ARREGLO = new Rectangle[aux.Length];
                for (int i = 0; i < ARREGLO.Length; i++)
                {
                    ARREGLO[i] = aux[i];
                }
            }
            
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string img = openFileDialog1.FileName;
                    pictureBox1.Image = Image.FromFile(img);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("El Archivo Seleccionado No Es Un Tipo De Imagen");
            }
        }
    }
}

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
    public partial class frmTATFirmaCAP : Form
    {
        public frmTATFirmaCAP()
        {
            InitializeComponent();
        }

        #region OBJETOS
        Point posicionPrevia = new Point(-1,- 1);
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
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

        #region DIBUJAR
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(posicionPrevia.X == -1)
            {
                posicionPrevia = new Point(e.X, e.Y);
            }
            Point PosicionActual = new Point(e.X, e.Y);
            Graphics Dibujo = pictureBox1.CreateGraphics();
            Dibujo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if(e.Button == MouseButtons.Left)
            {
                Dibujo.DrawLine(new Pen(Color.Black), posicionPrevia, PosicionActual);
            }
            else if(e.Button == MouseButtons.Right)
            {
                pictureBox1.Refresh();
            }
            posicionPrevia = PosicionActual;
        }
        #endregion
    }
}

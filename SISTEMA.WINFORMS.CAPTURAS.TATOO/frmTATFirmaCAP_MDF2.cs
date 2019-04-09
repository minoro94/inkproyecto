using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using SISTEMA.TATTOO;
using System.IO;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATFirmaCAP_MDF2 : Form
    {
        public frmTATFirmaCAP_MDF2()
        {
            InitializeComponent();
        }

        #region OBJETOS
        
        public string DireccionFirma;

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

        

        

        #region CARGAR FIRMA
        private void CargarFirma(string Firma)
        {
            if (Firma != "")
            {
                //openFileDialog1.FileName = Firma;
               // ptbFirma.Image = Image.FromFile(openFileDialog1.FileName);
                ptbFirma.Image = Herramientas.decodeImagen(DireccionFirma, ".png");
            }
            else
            {

            }
        }
        #endregion

        private void frmTATFirmaCAP_MDF2_Load(object sender, EventArgs e)
        {
            CargarFirma(DireccionFirma);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

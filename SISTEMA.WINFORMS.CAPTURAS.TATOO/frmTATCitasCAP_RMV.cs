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

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_RMV : Form
    {
        public frmTATCitasCAP_RMV()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public int idCita;
        public string USUARIO;

        TATCitas TABLA_Citas = new TATCitas();
        TATCitas.strTATCitas str = new TATCitas.strTATCitas();
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str.idCita = idCita;
            str.USUARIO = USUARIO;
            str.FechaCita = Convert.ToDateTime(lblFechaCita.Text);
            if(TABLA_Citas.DAO(ref str, 3))
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

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region MOUSE DOWN
        private void PanelInfoTatuaje_MouseDown(object sender, MouseEventArgs e)
        {
            if (gbInfoTatuajes.Visible)
            {
                gbInfoTatuajes.Visible = false;
                ptbAbajo.Visible = false;
                ptbDerecha.Visible = true;
                this.Size = new System.Drawing.Size(1333, 263);
                btnAceptar.Location = new Point(1135, 214);
                btnCancelar.Location = new Point(1231, 214);
                btnAceptar.Enabled = false;

                PanelBorderAbajo.Location = new Point(3, 259);
            }
            else
            {
                gbInfoTatuajes.Visible = true;
                ptbDerecha.Visible = false;
                ptbAbajo.Visible = true;
                this.Size = new System.Drawing.Size(1333, 695);
                btnAceptar.Location = new Point(1135, 650);
                btnCancelar.Location = new Point(1234, 650);
                btnAceptar.Enabled = true;

                PanelBorderAbajo.Location = new Point(3, 691);
                ptbPerfil.Refresh();
            }
        }
        #endregion

        #region LOAD
        private void frmTATCitasCAP_RMV_Load(object sender, EventArgs e)
        {
            PanelInfoTatuaje_MouseDown(null, null);
        }
        #endregion
    }
}

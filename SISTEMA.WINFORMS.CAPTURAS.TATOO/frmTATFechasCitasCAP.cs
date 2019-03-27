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
using System.Collections;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATFechasCitasCAP : Form
    {
        public frmTATFechasCitasCAP()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public DataTable dTable = new DataTable();
        #endregion

        #region ENABLE BUTTONS
        private void EnableButton()
        {
            if(lstLista.SelectedItems.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
            if(lstLista.Items.Count > 0)
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }
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

        #region LOAD
        private void frmTATFechasCitasCAP_Load(object sender, EventArgs e)
        {
            EnableButton();
        }
        #endregion

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            lstLista.Items.RemoveAt(lstLista.SelectedIndices[0]);
            EnableButton();
        }
        #endregion

        #region LISTA SELECTED INDEX CHANGED
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButton();
        }
        #endregion

        #region BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            ListViewItem L;
            L = new ListViewItem();
            L.Tag = dtpFechaCita;
            L.Text = dtpFechaCita.Value.ToString();
            lstLista.Items.Add(L);
            EnableButton();
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dTable.Columns.Add("FechaCita", typeof(DateTime));
            for (int i = 0; i < lstLista.Items.Count; i++)
            {
                dTable.Rows.Add(Convert.ToDateTime(lstLista.Items[i].SubItems[0].Text));
            }
        }
        #endregion
    }
}

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
    public partial class frmTATFechasCitasCAP_MDF2 : Form
    {
        public frmTATFechasCitasCAP_MDF2()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public DataTable dTable = new DataTable();
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

        #region ENABLE BUTTONS
        private void EnableButton()
        {
            if (lstLista.SelectedItems.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
            if (lstLista.Items.Count > 0)
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
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

        #region REFRESHLIST
        private void RefreshList()
        {
            ListViewItem L;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                L = new ListViewItem();
                L.Tag = dTable;
                L.Text = Convert.ToString(dTable.Rows[i].ItemArray[1]);
                lstLista.Items.Add(L);
            }
            EnableButton();
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dTable.Clear();
            for (int i = 0; i < lstLista.Items.Count; i++)
            {
                dTable.Rows.Add(0, Convert.ToDateTime(lstLista.Items[i].SubItems[0].Text), 0);
            }

            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region CREAR DT
        private void CrearDT()
        {
            if (dTable.Columns.Count > 0)
            {


            }
            else
            {
                dTable.Columns.Add("idSesionCita", typeof(int));
                dTable.Columns.Add("FechaCita", typeof(DateTime));
                dTable.Columns.Add("ELIMINADO", typeof(bool));
            }
        }
        #endregion

        #region LOAD
        private void frmTATFechasCitasCAP_MDF2_Load(object sender, EventArgs e)
        {
            CrearDT();
            RefreshList();
            EnableButton();
        }
        #endregion
    }
}

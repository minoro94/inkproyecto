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
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATClientesFND : Form
    {
        public frmTATClientesFND()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATClientes.strTATClientes[] ARR;
        TATClientes TABLA = new TATClientes();
        public TATClientes.strTATClientes str = new TATClientes.strTATClientes();
        wfTATClientes WF = new wfTATClientes();
        #endregion

        #region REFRESHLIST
        public void RefreshList()
        {
            str.nombreCliente = txtBuscar.Text.Trim();
            lstLista.Items.Clear();
            TABLA.Listar(ref ARR, str);
            ListViewItem L;

            foreach(TATClientes.strTATClientes Dato in ARR)
            {
                L = new ListViewItem();
                L.Text = Dato.nombreCliente;
                L.Tag = Dato;
                lstLista.Items.Add(L);
            }
        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            btnAceptar.Enabled = (lstLista.SelectedItems.Count != 0);
        }
        #endregion

        #region LOAD
        private void frmTATClientesFND_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATClientesFND_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA.Dispose();
        }
        #endregion

        #region SELECTED INDEX CHANGED
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region TEXT CHANGED
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON BUSCAR
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str = (TATClientes.strTATClientes)lstLista.SelectedItems[0].Tag;
            this.DialogResult = DialogResult.OK;
        }
    }
}

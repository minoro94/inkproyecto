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
    public partial class frmTATTiposEmpleadosFND : Form
    {
        public frmTATTiposEmpleadosFND()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATTIpoEmpleados.strTATTipoEmpleados[] ARR;
        TATTIpoEmpleados TABLA = new TATTIpoEmpleados();
        public TATTIpoEmpleados.strTATTipoEmpleados str = new TATTIpoEmpleados.strTATTipoEmpleados();
        wfTATTiposEmpleados WF = new wfTATTiposEmpleados();

        TATTiposPermisos.strTATTiposPermisos[] ARRTipoPermiso;
        TATTiposPermisos TABLA_TipoPermisos = new TATTiposPermisos();
        TATTiposPermisos.strTATTiposPermisos strPermisos = new TATTiposPermisos.strTATTiposPermisos();
        ArrayList IDsTipoPermiso = new ArrayList();
        #endregion

        #region REFRESHLIST
        public void RefreshList()
        {
            lstLista.Items.Clear();
            TABLA.Listar(ref ARR, txtBuscar.Text.Trim());
            ListViewItem L;

            foreach (TATTIpoEmpleados.strTATTipoEmpleados dato in ARR)
            {
                L = new ListViewItem();
                L.Text = dato.nombreTipoEmpleado.ToString();
                L.SubItems.Add(dato.nombreTipoPermiso);
                
                L.Tag = dato;
                lstLista.Items.Add(L);
            }
            EnableButtons();
        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            btnAceptar.Enabled = (lstLista.SelectedItems.Count != 0);
        }
        #endregion

        #region LOAD
        private void frmTATTiposEmpleadosFND_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATTiposEmpleadosFND_FormClosing(object sender, FormClosingEventArgs e)
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
        private void btnBuscarTipoEmpleado_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str = (TATTIpoEmpleados.strTATTipoEmpleados)lstLista.SelectedItems[0].Tag;
            this.DialogResult = DialogResult.OK;
        }
    }
}

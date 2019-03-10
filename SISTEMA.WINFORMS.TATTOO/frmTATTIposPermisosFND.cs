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

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATTIposPermisosFND : Form
    {
        public frmTATTIposPermisosFND()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public TATTiposPermisos.strTATTiposPermisos str = new TATTiposPermisos.strTATTiposPermisos();
        TATTiposPermisos TABLA = new TATTiposPermisos();
        #endregion

        #region REFRESH LIST
        public void RefreshList()
        {
            lstLista.Items.Clear();
            TATTiposPermisos.strTATTiposPermisos[] ARR = null;
            str.nombreTipoPermiso = txtBuscar.Text.Trim();
            bool Resulto = TABLA.Listar(ref ARR, str);
            int i = 0;
            if (Resulto == true)
            {
                ListViewItem L;
                foreach (TATTiposPermisos.strTATTiposPermisos Dato in ARR)
                {
                    L = new ListViewItem();
                    L.Tag = Dato;
                    L.Text = Dato.nombreTipoPermiso;
                    L.SubItems.Add(Dato.Descripcion);
                    if (Dato.activo == true)
                    {
                        L.SubItems.Add("Si");
                    }
                    else
                    {
                        L.SubItems.Add("No");
                    }
                    lstLista.Items.Add(L);
                    i++;

                }
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

        #region LOAD
        private void frmTATTIposPermisosFND_Load(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region FORM CLOSING
        private void frmTATTIposPermisosFND_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA.Dispose();
        }
        #endregion

        #region BUSCAR
        private void btnBuscarTipoEmpleado_Click(object sender, EventArgs e)
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

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            str = (TATTiposPermisos.strTATTiposPermisos)lstLista.SelectedItems[0].Tag;
            this.DialogResult = DialogResult.OK;
        }
        #endregion
    }
}

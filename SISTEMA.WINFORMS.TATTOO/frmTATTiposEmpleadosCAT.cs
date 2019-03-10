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
using System.Runtime.InteropServices;
using System.Collections;

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATTiposEmpleadosCAT : Form
    {
        public frmTATTiposEmpleadosCAT()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATTIpoEmpleados.strTATTipoEmpleados[] ARRTiposEmpleados;
        TATTIpoEmpleados TABLA_TipoEMpleados = new TATTIpoEmpleados();
        TATTIpoEmpleados.strTATTipoEmpleados strTipoEmpleados = new TATTIpoEmpleados.strTATTipoEmpleados();
        wfTATTiposEmpleados WF = new wfTATTiposEmpleados();

        TATTiposPermisos.strTATTiposPermisos[] ARRTiposPermisos;
        TATTiposPermisos TABLA_TiposPermisos = new TATTiposPermisos();
        TATTiposPermisos.strTATTiposPermisos strTiposPermisos = new TATTiposPermisos.strTATTiposPermisos();
        ArrayList IdsTiposPermisos = new ArrayList();

        public string USUARIO = "";
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        #endregion

        #region REFRESH LIST
        public void RefreshList()
        {
            lstLista.Items.Clear();
            TABLA_TipoEMpleados.Listar(ref ARRTiposEmpleados, txtTipoEmpleados.Text.Trim());
            ListViewItem L;

            foreach (TATTIpoEmpleados.strTATTipoEmpleados dato in ARRTiposEmpleados)
            {
                L = new ListViewItem();
                L.Text = dato.nombreTipoEmpleado.ToString();
                L.SubItems.Add(dato.nombreTipoPermiso);
                L.SubItems.Add(dato.Descripcion);
                L.Tag = dato;
                lstLista.Items.Add(L);
            }
            EnableButtons();
        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (lstLista.SelectedItems.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }
        #endregion

        #region LOAD
        private void frmTATTiposEmpleadosCAT_Load(object sender, EventArgs e)
        {
            RefreshList();
            EnableButtons();
        }
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region BOTON SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region TEXTCHANGED
        private void txtTipoEmpleados_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region SLEECTED INDEX CHANGER
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region MOUSE DOWN
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region FORM CLOSING
        private void frmTATTiposEmpleadosCAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_TipoEMpleados.Dispose();
        }
        #endregion

        #region KEY UP
        private void txtTipoEmpleados_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshList();
            }
        }
        #endregion

        #region DOUBLE CLICK
        private void lstLista_DoubleClick(object sender, EventArgs e)
        {
            strTipoEmpleados = (TATTIpoEmpleados.strTATTipoEmpleados)lstLista.SelectedItems[0].Tag;
            if(WF.Modificar(ref strTipoEmpleados, USUARIO) == DialogResult.OK)
            {
                RefreshList();
            }
        }
        #endregion

        #region AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = WF.Agregar(ref USUARIO);
            if(Resultado == System.Windows.Forms.DialogResult.OK)
            {
                RefreshList();
            }
            if(Resultado == System.Windows.Forms.DialogResult.Yes)
            {
                RefreshList();
                btnAgregar_Click(null, null);
            }
        }
        #endregion

        #region BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            strTipoEmpleados = (TATTIpoEmpleados.strTATTipoEmpleados)lstLista.SelectedItems[0].Tag;
            if (WF.Modificar(ref strTipoEmpleados, USUARIO) == DialogResult.OK)
            {
                RefreshList();
            }
        }
        #endregion

        #region BOTON REMOVER
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            strTipoEmpleados = (TATTIpoEmpleados.strTATTipoEmpleados)lstLista.SelectedItems[0].Tag;
            if (WF.Remover(ref strTipoEmpleados, USUARIO) == DialogResult.OK)
            {
                RefreshList();
            }
        }
        #endregion
    }
}

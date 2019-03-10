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
using SISTEMA.WINFORMS.TATTOO;
using System.Runtime.InteropServices;

namespace SISTEMA.MAINMENU
{
    public partial class frmTATUsuariosCAT : Form
    {
        public frmTATUsuariosCAT()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATUsuarios.strTATUsuarios[] ARR;
        TATUsuarios TABLA = new TATUsuarios();
        public TATUsuarios.strTATUsuarios strUsuario = new TATUsuarios.strTATUsuarios();
        wfTATUsuarios WF = new wfTATUsuarios();

        TATEmpleados.strTATEmpleados[] ARREmpleados;
        TATEmpleados Tabla_Empleados = new TATEmpleados();
        TATEmpleados.strTATEmpleados strEmpleado = new TATEmpleados.strTATEmpleados();
        ArrayList IDsEmpleados = new ArrayList();

        public string USUARIO;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public FORMA_PADRE formaP = null;
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if(lstLista.SelectedItems.Count == 0)
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

        #region REFRESH LIST
        public void RefreshList()
        {
            lstLista.Items.Clear();
            TABLA.Listar(ref ARR, txtFiiltro.Text.Trim());
            ListViewItem L;

            foreach(TATUsuarios.strTATUsuarios Dato in ARR)
            {
                L = new ListViewItem();
                L.Text = Dato.nombreUsuario.ToString();
                L.SubItems.Add(Dato.nombreEmpleado);
                L.Tag = Dato;
                lstLista.Items.Add(L);
            }
            EnableButtons();
        }


        #endregion

        #region BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region LOAD
        private void frmTATUsuariosCAT_Load(object sender, EventArgs e)
        {
            RefreshList();
            EnableButtons();
        }
        #endregion

        #region BOTON SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = WF.Agregar();
            if(Resultado == DialogResult.OK)
            {
                RefreshList();
            }
            if(Resultado == DialogResult.Yes)
            {
                RefreshList();
                btnAgregar_Click(null, null);
            }
        }
        #endregion

        #region BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            strUsuario = (TATUsuarios.strTATUsuarios)lstLista.SelectedItems[0].Tag;
            if(WF.Modificar(ref strUsuario) == DialogResult.OK)
            {
                RefreshList();
                formaP.RefreshPermisos();
            }
        }
        #endregion

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            strUsuario = (TATUsuarios.strTATUsuarios)lstLista.SelectedItems[0].Tag;
            if(WF.Remover(ref strUsuario.idUsuario) == DialogResult.OK)
            {
                RefreshList();
            }
        }

        #endregion

        #region SELECTED INDEX CHANGED
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }

        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region MOUSE DOWN
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region FORM CLOSING
        private void frmTATUsuariosCAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            formaP.RefreshPermisos();
            TABLA.Dispose();
        }
        #endregion

        #region KEY UP
        private void txtFiiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                RefreshList();
            }
        }
        #endregion

        #region DOUBLE CLICK
        private void lstLista_DoubleClick(object sender, EventArgs e)
        {
            strUsuario = (TATUsuarios.strTATUsuarios)lstLista.SelectedItems[0].Tag;
            if(WF.Modificar(ref strUsuario) == DialogResult.OK)
            {
                RefreshList();
                formaP.RefreshPermisos();
            }
        }
        #endregion
    }
}

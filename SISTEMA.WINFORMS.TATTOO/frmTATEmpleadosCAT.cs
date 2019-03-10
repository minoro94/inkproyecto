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
using System.Runtime.InteropServices;

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATEmpleadosCAT : Form
    {
        public frmTATEmpleadosCAT()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATEmpleados.strTATEmpleados[] ARR_Empleados;
        TATEmpleados TABLA_Empleados = new TATEmpleados();
        TATEmpleados.strTATEmpleados strEmpleados = new TATEmpleados.strTATEmpleados();
        wfTATEmpleados WF = new wfTATEmpleados();

        TATTIpoEmpleados.strTATTipoEmpleados[] ARRTiposEmpleados;
        TATTIpoEmpleados TABLA_TiposEmpleados = new TATTIpoEmpleados();
        TATTIpoEmpleados.strTATTipoEmpleados strTiposEmpleados = new TATTIpoEmpleados.strTATTipoEmpleados();
        ArrayList IDsTiposEmpleados = new ArrayList();
        public string USUARIO = "";


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
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

        #region REFRESH LIST
        public void RefreshList()
        {
            lstLista.Items.Clear();
            TABLA_Empleados.Listar(ref ARR_Empleados, txtFiltro.Text.Trim());
            ListViewItem L;
            foreach(TATEmpleados.strTATEmpleados Dato in ARR_Empleados)
            {
                L = new ListViewItem();
                L.Text = Dato.nombreEmpleado.ToString();
                L.SubItems.Add(Dato.nombreTipoEmpleado);
                L.SubItems.Add(Dato.Telefono);
                L.Tag = Dato;
                lstLista.Items.Add(L);
            }
            EnableButtons();
        }
        #endregion

        #region BOTON BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        #endregion

        #region BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = WF.Agregar(ref USUARIO);

            if (Resultado == System.Windows.Forms.DialogResult.OK)
            {
                RefreshList();
            }
            if (Resultado == System.Windows.Forms.DialogResult.Yes)
            {
                RefreshList();
                btnAgregar_Click(null, null);
            }
        }
        #endregion

        #region BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            strEmpleados = (TATEmpleados.strTATEmpleados)lstLista.SelectedItems[0].Tag;
            if(WF.Modificar(ref strEmpleados, USUARIO) == DialogResult.OK)
            {
                RefreshList();
            }
        }
        #endregion

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            strEmpleados = (TATEmpleados.strTATEmpleados)lstLista.SelectedItems[0].Tag;
            if(WF.Remover(ref strEmpleados, USUARIO) == DialogResult.OK)
            {
                RefreshList();
            } 
        }
        #endregion

        #region BOTON SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region LOAD
        private void frmTATEmpleadosCAT_Load(object sender, EventArgs e)
        {
            RefreshList();
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
        private void frmTATEmpleadosCAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_Empleados.Dispose();
        }
        #endregion

        #region DOUBLE CLICK
        private void lstLista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            strEmpleados = (TATEmpleados.strTATEmpleados)lstLista.SelectedItems[0].Tag;
            if(WF.Modificar(ref strEmpleados, USUARIO) == DialogResult.OK)
            {
                RefreshList();
            }
        }
        #endregion
    }
}

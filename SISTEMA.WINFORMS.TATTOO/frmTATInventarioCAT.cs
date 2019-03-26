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

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATInventarioCAT : Form
    {
        public frmTATInventarioCAT()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATInventario.strTATInventario strInventario = new TATInventario.strTATInventario();
        TATInventario TABLA_Inventario = new TATInventario();
        wfTATInventario WF = new wfTATInventario();
        public string USUARIO = "";
        public int idUsuario;
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
            TATInventario.strTATInventario[] ARR = null;
            strInventario.NombreProducto = txtFiiltro.Text.Trim();
            bool Resulto = TABLA_Inventario.Listar(ref ARR, strInventario);
            
            if (Resulto)
            {
                ListViewItem L;
                foreach(TATInventario.strTATInventario Dato in ARR)
                {
                    L = new ListViewItem();
                    L.Tag = Dato;
                    L.Text = Dato.NombreProducto;
                    L.SubItems.Add(Dato.Cantidad.ToString());
                    lstLista.Items.Add(L);
                }
            }
            EnableButtons();
        }
        #endregion

        #region LOAD
        private void frmTATInventarioCAT_Load(object sender, EventArgs e)
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

        #region BOTON BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region SELECTED INDEX
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void frmTATInventarioCAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_Inventario.Dispose();
        }
        #endregion

        #region KEY UP
        private void txtFiiltro_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RefreshList();
            }
        }
        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = WF.Agregar(ref USUARIO, idUsuario);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;

            if (lstLista.SelectedItems.Count >= 1)
            {
                strInventario = (TATInventario.strTATInventario)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Modificar(ref strInventario, USUARIO);
                if (Resultado == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshList();
                }
                else
                {

                }

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;

            if (lstLista.SelectedItems.Count >= 1)
            {
                strInventario = (TATInventario.strTATInventario)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Remover(ref strInventario, USUARIO);
                if (Resultado == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshList();
                }
                else
                {
                    RefreshList();
                }
            }
        }
    }
}

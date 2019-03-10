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
    public partial class frmTATTamañosCAT : Form
    {
        public frmTATTamañosCAT()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATTamaños.strTATTamaños str = new TATTamaños.strTATTamaños();
        TATTamaños TABLA_Tamaños = new TATTamaños();
        wfTATTamaños WF = new wfTATTamaños();


        public string USUARIO = "";
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
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
            TATTamaños.strTATTamaños[] ARR = null;
            str.Tamaño = txtTamaño.Text.Trim();
            bool Resulto = TABLA_Tamaños.Listar(ref ARR, str);
            int i = 0;
            if(Resulto == true)
            {
                ListViewItem L;
                foreach(TATTamaños.strTATTamaños Dato in ARR)
                {
                    L = new ListViewItem();
                    L.Tag = Dato;
                    L.Text = Dato.Tamaño;
                    L.SubItems.Add(Dato.Detalle);
                    lstLista.Items.Add(L);
                    i++;
                }
            }
            EnableButtons();
        }
        #endregion

        #region LOAD
        private void frmTATTamañosCAT_Load(object sender, EventArgs e)
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

        #region TEXTCHANGED
        private void txtTamaño_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void frmTATTamañosCAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_Tamaños.Dispose();
        }

        #endregion

        #region DOUBLE CLICK
        private void lstLista_DoubleClick(object sender, EventArgs e)
        {
            DialogResult Resultado;
            if(lstLista.SelectedItems.Count >= 1)
            {
                str = (TATTamaños.strTATTamaños)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Modificar(ref str, USUARIO);
                if(Resultado == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshList();
                }
                else
                {
                    lstLista.SelectedItems.Clear();
                }
            }
        }
        #endregion

        #region BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = WF.Agregar(ref USUARIO);
            if(Resultado == System.Windows.Forms.DialogResult.OK)
            {
                RefreshList();
            }
            else
            {
                lstLista.SelectedItems.Clear();
            }
            if(Resultado == System.Windows.Forms.DialogResult.Yes)
            {
                RefreshList();
                btnAgregar_Click(null, null);
            }
            else
            {
                lstLista.SelectedItems.Clear();
            }
        }
        #endregion

        #region BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;

            if(lstLista.SelectedItems.Count >= 1)
            {
                str = (TATTamaños.strTATTamaños)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Modificar(ref str, USUARIO);
                if(Resultado == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshList();
                }
                else
                {
                    lstLista.SelectedItems.Clear();
                }
            }
        }
        #endregion

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;

            if(lstLista.SelectedItems.Count >= 1)
            {
                str = (TATTamaños.strTATTamaños)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Remover(ref str, USUARIO);
                if(Resultado == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshList();
                }
                else
                {
                    lstLista.SelectedItems.Clear();
                }
            }
        }
        #endregion

    }
}

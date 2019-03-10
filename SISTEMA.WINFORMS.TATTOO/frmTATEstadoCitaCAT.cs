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
    public partial class frmTATEstadoCitaCAT : Form
    {
        public frmTATEstadoCitaCAT()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATEstadoCita.strTATEstadoCita str = new TATEstadoCita.strTATEstadoCita();
        TATEstadoCita TABLA_EstadoCitas = new TATEstadoCita();
        wfTATEstadoCita WF = new wfTATEstadoCita();
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
            TATEstadoCita.strTATEstadoCita[] ARR = null;
            str.NombreEstadoCita = txtNombreEstadoCita.Text.Trim();
            bool Resulto = TABLA_EstadoCitas.Listar(ref ARR, str);
            if (Resulto)
            {
                ListViewItem L;
                foreach(TATEstadoCita.strTATEstadoCita Dato in ARR)
                {
                    L = new ListViewItem();
                    L.Tag = Dato;
                    L.Text = Dato.NombreEstadoCita;
                    L.SubItems.Add(Dato.Descripcion);
                    lstLista.Items.Add(L);
                }
            }

            EnableButtons();
        }
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

        #region LOAD
        private void frmTATEstadoCitaCAT_Load(object sender, EventArgs e)
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

        #region TEXT CHANGED
        private void txtNombreEstadoCita_TextChanged(object sender, EventArgs e)
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
        private void frmTATEstadoCitaCAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_EstadoCitas.Dispose();
        }
        #endregion

        #region DOUBLE CLICK
        private void lstLista_DoubleClick(object sender, EventArgs e)
        {
            DialogResult Resultado;
            if(lstLista.SelectedItems.Count >= 1)
            {
                str = (TATEstadoCita.strTATEstadoCita)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Modificar(ref str, USUARIO);
                if(Resultado == DialogResult.OK)
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

        #region BOTON AGREGRAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = WF.Agregar(ref USUARIO);
            if(Resultado == DialogResult.OK)
            {
                RefreshList();
            }
            else
            {
                lstLista.SelectedItems.Clear();
            }
            if(Resultado == DialogResult.Yes)
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
                str = (TATEstadoCita.strTATEstadoCita)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Modificar(ref str, USUARIO);
                if(Resultado == DialogResult.OK)
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
                str = (TATEstadoCita.strTATEstadoCita)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Remover(ref str, USUARIO);
                if(Resultado == DialogResult.OK)
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

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

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasCAP_CAT : Form
    {
        public frmTATCitasCAP_CAT()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATCitas.strTATCitas strCitas = new TATCitas.strTATCitas();
        TATCitas TABLA_Citas = new TATCitas();
        wfTATCitas WF = new wfTATCitas();

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
                btnMostrar.Enabled = false;
            }
            else
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnMostrar.Enabled = true;
            }
        }
        #endregion

        #region REFRESH LIST
        public void RefreshList()
        {
            lstLista.Items.Clear();
            TATCitas.strTATCitas[] ARR = null;
            strCitas.nombreCliente = txtFiiltro.Text.Trim();


            DateTime finicio = dtpInicio.Value;
            DateTime fFin = dtpFin.Value;
            bool Resulto = TABLA_Citas.Listar(ref ARR, finicio, fFin, strCitas);
            int i = 0;
            if (Resulto == true)
            {
                ListViewItem L;
                foreach (TATCitas.strTATCitas Dato in ARR)
                {
                    L = new ListViewItem();
                    L.Tag = Dato;
                    L.Text = Dato.nombreCliente;
                    L.SubItems.Add(Dato.NombreEstadoCita);
                    L.SubItems.Add(Convert.ToString(Dato.FechaCita));
                    lstLista.Items.Add(L);
                    i++;
                }
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

        #region LOAD
        private void frmTATCitasCAP_CAT_Load(object sender, EventArgs e)
        {
            dtpInicio.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
            dtpFin.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7);
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

        #region SELECTED INDEX
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region TEXT CHANGED
        private void txtFiiltro_TextChanged(object sender, EventArgs e)
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
        #endregion

        #region FORM CLOSING
        private void frmTATCitasCAP_CAT_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_Citas.Dispose();
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

        #region DOUBLE CLICK
        private void lstLista_DoubleClick(object sender, EventArgs e)
        {
            DialogResult Resultado;
            if (lstLista.SelectedItems.Count >= 1)
            {
                strCitas = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Modificar(ref strCitas, USUARIO);
                if (Resultado == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshList();
                }
            }
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
            DialogResult Resultado;

            if (lstLista.SelectedItems.Count >= 1)
            {
                strCitas = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Modificar(ref strCitas, USUARIO);
                if (Resultado == System.Windows.Forms.DialogResult.OK)
                {
                    RefreshList();
                }
                else
                {

                }

            }
        }
        #endregion

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;

            if (lstLista.SelectedItems.Count >= 1)
            {
                strCitas = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Remover(ref strCitas, USUARIO);
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

        #endregion

        #region BOTON MOSTRAR
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;

            if(lstLista.SelectedItems.Count >= 1)
            {
                strCitas = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
                Resultado = WF.Mostrar(ref strCitas, USUARIO);
                if(Resultado == DialogResult.OK)
                {
                    RefreshList();
                }
                else
                {
                    RefreshList();
                }
            }
        }
        #endregion
    }
}

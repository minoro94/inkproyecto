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
namespace SISTEMA.WINFORMS.CAPTURAS.TATTOO
{
    public partial class frmTATCitasCAT_CAP : Form
    {
        public frmTATCitasCAT_CAP()
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
            TATCitas.strTATCitas[] ARR = null;
            strCitas.nombreCliente = txtFiiltro.Text.Trim();
            bool Resulto = TABLA_Citas.Listar(ref ARR, strCitas);
            int i = 0;
            if()
        }
        #endregion
    }
}

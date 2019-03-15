using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using SISTEMA.TATTOO;
using System.IO;
using System.Diagnostics;
using SISTEMA.WINFORMS.TATTOO;
using SISTEMA.WINFORMS.CAPTURAS.TATOO;


namespace SISTEMA.MAINMENU
{
    public partial class FORMA_PADRE : Form
    {

        #region INICIALIZAR
        
        public FORMA_PADRE()
        {
            InitializeComponent();
        }
        #endregion

        #region METODO REFRESH
        public void RefreshPermisos()
        {
            Tabla_Usuarios.DAO(ref strUsuario, 5);
            strPermisosTablas.idUsuario = strUsuario.idUsuario;
            Tabla_PermisosTablas.Listar(ref ARRPermisoTablas, strPermisosTablas);
        }
        #endregion

        #region OBJETOS
        public bool VersionVieja = false;

        TATUsuarios Tabla_Usuarios = new TATUsuarios();
        TATPermisosTablas Tabla_PermisosTablas = new TATPermisosTablas();
        TATPermisosTablas.strTATPermisosTablas strPermisosTablas = new TATPermisosTablas.strTATPermisosTablas();
        TATUsuarios.strTATUsuarios strUsuario = new TATUsuarios.strTATUsuarios();
        TATPermisosTablas.strTATPermisosTablas[] ARRPermisoTablas = null;

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;
        #endregion

        #region METODO AGREGAR HIJOS
        public void AgregarHijos(ref string nombreTabla, Form formHijo)
        {
            bool existe = false;
            bool permiso = false;
            if(ARRPermisoTablas == null)
            {
                return;
            }
            for (int i = 0; i < ARRPermisoTablas.Length; i++)
            {
                if (ARRPermisoTablas[i].NombreTabla.Equals(nombreTabla) && ARRPermisoTablas[i].Permiso == true)
                {
                    permiso = true;
                }

                if (permiso == true)
                {
                    for (int j = 0; j < Panel.Controls.Count; j++)
                    {
                        if (Panel.Controls[j].Name == formHijo.Name)
                        {
                            existe = true;
                            formHijo.DesktopLocation = new Point((Panel.Width - formHijo.Width) / 2, (Panel.Height - formHijo.Height) / 2);
                            Panel.Controls[j].BringToFront();
                            formHijo.Focus();
                        }
                    }
                    if (existe == false)
                    {
                        formHijo.TopLevel = false;
                        this.Panel.Controls.Add(formHijo);
                        this.Panel.Tag = formHijo;
                        formHijo.DesktopLocation = new Point((Panel.Width - formHijo.Width) / 2, (Panel.Height - formHijo.Height) / 2);
                        formHijo.Show();
                        formHijo.BringToFront();
                        formHijo.Focus();
                        break;
                    }
                }
            }
            if (permiso == false)
            {
                MessageBox.Show("Acceso Denegado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        #region RELOJ Y FECHA
        private void Reloj_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
            label2.Text = DateTime.Now.ToShortDateString();
            label3.Text = DateTime.Now.ToString("dddd");
        }
        #endregion

        #region SALIR
        private void Salir_Click(object sender, EventArgs e)
        {
            Panel.Dispose();
            Application.Exit();
        }
        #endregion

        #region EMPLEADOS
        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATEmpleadosCAT FORMA = new frmTATEmpleadosCAT();
            FORMA.USUARIO = strUsuario.nombreUsuario;
            string nombreTabla = "Empleados";
            AgregarHijos(ref nombreTabla, FORMA);
        }
        #endregion

        #region USUARIOS
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATUsuariosCAT Forma = new frmTATUsuariosCAT();
            string nombreTabla = "Usuarios";
            AgregarHijos(ref nombreTabla, Forma);
            Forma.formaP = this;
        }
        #endregion

        #region CITAS
        private void Citas_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region TAMAÑOS
        private void tamañosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATTamañosCAT frm = new frmTATTamañosCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            frm.ShowDialog();
        }
        #endregion

        #region LOAD
        private void FORMA_PADRE_Load_1(object sender, EventArgs e)
        {
            frmTATLogin Forma = new frmTATLogin();
            Forma.ShowDialog();
            strUsuario = Forma.strUsuario;
            ARRPermisoTablas = Forma.ARRPermisosTablas;
            

            if (ARRPermisoTablas != null)
            {
                this.Enabled = true;

            }
           
        }
        #endregion

        #region CLIENTES
        private void Clientes_Click(object sender, EventArgs e)
        {
            frmTATClientesCAT frm = new frmTATClientesCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            frm.ShowDialog();
        }
        #endregion

        #region TIPOS PERMISOS
        private void tipoDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATTiposPermisosCAT frm = new frmTATTiposPermisosCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            frm.ShowDialog();
        }
        #endregion

        #region TIPOS EMPLEADOS
        private void tiposDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATTiposEmpleadosCAT frm = new frmTATTiposEmpleadosCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            frm.ShowDialog();
        }
        #endregion

        #region NOTEPAD
        private void blocDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }
        #endregion

        #region CALCULADORA
        private void calculcadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("calc.exe");
        }
        #endregion

        #region LOGOUT
        private void LogOut_Click(object sender, EventArgs e)
        {
            Panel.Controls.Clear();
            this.FORMA_PADRE_Load_1(null, null);
        }
        #endregion

        #region ESTADOS CITAS
        private void estadosCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATEstadoCitaCAT frm = new frmTATEstadoCitaCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            frm.ShowDialog();
        }
        #endregion

        #region CITAS
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTATCitasCAP_CAT frm = new frmTATCitasCAP_CAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            frm.ShowDialog();

        }
        #endregion
    }
}

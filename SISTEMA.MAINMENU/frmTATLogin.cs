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
using SISTEMA.TATTOO;

namespace SISTEMA.MAINMENU
{
    public partial class frmTATLogin : Form
    {
        public frmTATLogin()
        {
            InitializeComponent();
        }

        #region OBJETOS
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public TATUsuarios.strTATUsuarios strUsuario = new TATUsuarios.strTATUsuarios();
        TATPermisosTablas.strTATPermisosTablas strTATPermisosTablas = new TATPermisosTablas.strTATPermisosTablas();
        public TATPermisosTablas.strTATPermisosTablas[] ARRPermisosTablas = null;
        TATUsuarios TABLA_Usuarios = new TATUsuarios();
        TATPermisosTablas TABLA_PermisosTablas = new TATPermisosTablas();
        bool Res = false;
        #endregion

        #region USUARIO LEAVE
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }
        #endregion

        #region USUARIO ENTER
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.FromArgb(64, 64, 64);
            }
        }
        #endregion

        #region CONTRASEÑA ENTER
        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if(txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.FromArgb(64, 64, 64);
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        #endregion

        #region CONTRASEÑA LEAVE
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if(txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.FromArgb(64, 64, 64);
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
        #endregion

        #region CLOSE
        private void ptbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region MOUSE DOWN FORMA
        private void frmTATLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region KEY PRESS USUARIO
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar == (int)Keys.Enter)
            {
                txtContraseña.Focus();
                return;
            }

            if(!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsNumber(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras y números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
            char[] NoPermitir = { 'é', 'ý', 'ú', 'í', 'ó', 'á', 'ë', 'ÿ', 'ü', 'ï', 'ö', 'ä', 'ê', 'û', 'î', 'ô', 'â', 'Ä', 'Ë', 'Ï', 'Ö', 'Ü', 'Á', 'É', 'Í', 'Ó', 'Ú', 'Ý' };
            if (NoPermitir.Contains(e.KeyChar))
            {
                MessageBox.Show("Carácter no permitido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        #endregion

        #region BOTON ACCEDER
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text.Trim() != "" && txtContraseña.Text.Trim() != "") && (txtUsuario.Text.Trim() != "Usuario" && txtContraseña.Text.Trim() != "Contraseña"))
            {
                strUsuario.nombreUsuario = txtUsuario.Text.Trim();
                strUsuario.Contraseña = txtContraseña.Text.Trim();
                Res = TABLA_Usuarios.DAO(ref strUsuario, 5);

                if (strUsuario.nombreEmpleado != null)
                {
                    strTATPermisosTablas.idUsuario = strUsuario.idUsuario;
                    TABLA_PermisosTablas.Listar(ref ARRPermisosTablas, strTATPermisosTablas);
                    
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            else
            {
                MessageBox.Show("Se necesita usuario y contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion

        #region KEY PRESS CONTRASEÑA
        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnAcceder_Click(null, null);
            }
        }


        #endregion

        #region MOUSE DOWN PIC BOX
        private void picBox_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

    }
}

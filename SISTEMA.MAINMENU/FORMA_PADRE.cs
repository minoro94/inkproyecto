﻿using System;
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
using System.Net.Mail;
using System.IO;
using System.Data.SqlClient;


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

        DataTable dtFechasCitas = new DataTable();
        DataTable dtInventario = new DataTable();
        DataTable dtImagenes = new DataTable();
        TATCitas.strTATCitas strCitas = new TATCitas.strTATCitas();
        TATCitas TABLA_Citas = new TATCitas();

        bool Instancia = false;
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
            string nombreTabla = "Tamaños";
            AgregarHijos(ref nombreTabla, frm);
        }
        #endregion

        #region LOAD
        private void FORMA_PADRE_Load_1(object sender, EventArgs e)
        {
            if (!Instancia)
            {
                Instanciar();
            }
            
            Disparador.Enabled = false;
            frmTATLogin Forma = new frmTATLogin();
            Forma.ShowDialog();
            
            strUsuario = Forma.strUsuario;
            ARRPermisoTablas = Forma.ARRPermisosTablas;
            ConexionBD DB = new ConexionBD();
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;

            DB.COM1.CommandText = "Select count(*) from dbo.configuracionUsuarioNTC where idUsuario=@idUsuario";
            SqlParameter SQP = new SqlParameter("@idUsuario", strUsuario.idUsuario);
            SQP.SqlDbType = SqlDbType.Int;
            DB.COM1.Parameters.Add(SQP);
            Cuantos = (int)DB.COM1.ExecuteScalar();
            if (Cuantos != 0)
            {
                DB.COM1.CommandText = "Select count(*) from dbo.visCitasPorFecha where CAST(FechaRegistro AS DATE) = CAST(@Fecha AS DATE) and ELIMINADO = 0 AND Aprobado = 0";
                SQP = new SqlParameter("@Fecha", DateTime.Now);
                SQP.SqlDbType = SqlDbType.DateTime;
                DB.COM1.Parameters.Add(SQP);
                Cuantos = (int)DB.COM1.ExecuteScalar();
            }
            


            if (ARRPermisoTablas != null)
            {
                this.Enabled = true;
                Disparador.Enabled = true;
                EnvioCorreo.Enabled = true;
                EliminarCapturas();

            }

            if (Cuantos != 0)
            {
                frmTATCitasPendientes frm = new frmTATCitasPendientes();
                string nombreTabla = "Citas Pendientes";
                AgregarHijos(ref nombreTabla, frm);
            }

        }
        #endregion

        #region CLIENTES
        private void Clientes_Click(object sender, EventArgs e)
        {
            frmTATClientesCAT frm = new frmTATClientesCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            string nombreTabla = "Clientes";
            AgregarHijos(ref nombreTabla, frm);
        }
        #endregion

        #region TIPOS PERMISOS
        private void tipoDePermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATTiposPermisosCAT frm = new frmTATTiposPermisosCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            string nombreTabla = "Tipos de Permisos"; ;
            AgregarHijos(ref nombreTabla, frm);
        }
        #endregion

        #region TIPOS EMPLEADOS
        private void tiposDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATTiposEmpleadosCAT frm = new frmTATTiposEmpleadosCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            string nombreTabla = "Tipos de Empleados";
            AgregarHijos(ref nombreTabla, frm);
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
            Disparador.Enabled = false;
            this.FORMA_PADRE_Load_1(null, null);
        }
        #endregion

        #region ESTADOS CITAS
        private void estadosCitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATEstadoCitaCAT frm = new frmTATEstadoCitaCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            string nombreTabla = "EstadoCita";
            AgregarHijos(ref nombreTabla, frm);
        }
        #endregion

        #region CITAS
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmTATCitasCAP_CAT frm = new frmTATCitasCAP_CAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            string nombreTabla = "Citas";
            AgregarHijos(ref nombreTabla, frm);
            

        }
        #endregion

        #region INVENTARIO
        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTATInventarioCAT frm = new frmTATInventarioCAT();
            frm.USUARIO = strUsuario.nombreUsuario;
            frm.idUsuario = strUsuario.idUsuario;
            string nombreTabla = "Inventario";
            AgregarHijos(ref nombreTabla, frm);
        }
        #endregion

        #region DISPARADOR
        private void Disparador_Tick(object sender, EventArgs e)
        {
            Disparador.Interval = 50000;
            TATCitas.strTATCitas[] ARR = null;
            string Nombre = "";
            string Telefono = "";
            string Fecha = "";
            bool resulto = TABLA_Citas.Listar(ref ARR, DateTime.Now.AddDays(1), strCitas);
            if (resulto)
            {
                foreach(TATCitas.strTATCitas Dato in ARR)
                {
                    Nombre = Dato.nombreCliente;
                    Telefono = Dato.Telefono;
                    Fecha = Dato.FechaCita.ToString("dddd-d-MMMM-yyyy-hh:mm tt");

                }
            }
            if(Nombre != "")
            {
                
                MessageBox.Show(this, "EL DIA DE MAÑANA TIENE CITA CON: \n" + Nombre.ToUpper() + "\nEL DIA " + Fecha.ToUpper() + "\nFAVOR DE COMUNICARSE AL NUMERO:\n" + Telefono.ToUpper() + " PARA CONFIRMA CITA", "CITAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        #endregion

        private void EnvioCorreo_Tick(object sender, EventArgs e)
        {
            EnvioCorreo.Interval = 1800000;
            DialogResult R;
            TATCitas.strTATCitas[] ARR = null;
            bool Resulto = TABLA_Citas.Listar(ref ARR, DateTime.Now.AddDays(-2),DateTime.Now.AddDays(7), strCitas);
            if (Resulto)
            {
                foreach(TATCitas.strTATCitas Dato in ARR)
                {
                    if(!Dato.EstadoCorreo && Dato.idEstadoCita == 3 && Dato.ELIMINADO == false)
                    {
                        R = EnviarCorreo(Dato.Correo);
                        if(R == DialogResult.OK)
                        {
                            strCitas = Dato;
                            strCitas.EstadoCorreo = true;
                            
                            TABLA_Citas.DAO(ref strCitas, 2, dtInventario, dtFechasCitas, dtImagenes);
                        }
                    }
                }
            }
        }

        #region ENVIAR CORREO
        private DialogResult EnviarCorreo(string Correo)
        {
            //string file = "FinalFantasy.pdf";
            string ruta = (Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"..\SISTEMA.WINFORMS.CAPTURAS.TATOO\PDF\HistorialMedico.pdf"));
            MailMessage Mensaje = new MailMessage();
            Mensaje.To.Add(Correo);
            Mensaje.Subject = "Como cuidar tu tatto inksaciable";
            Mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
            Mensaje.Body = "El pdf anexado viene informacion importante para cuidar la sanacion de tu tattoo.";
            Mensaje.Attachments.Add(new Attachment(ruta));
            Mensaje.BodyEncoding = System.Text.Encoding.UTF8;
            Mensaje.IsBodyHtml = true;
            Mensaje.From = new System.Net.Mail.MailAddress("inksaciable@gmail.com");
            SmtpClient Cliente = new SmtpClient();
            Cliente.Credentials = new System.Net.NetworkCredential("inksaciable@gmail.com", "6421078481");
            Cliente.Port = 587;
            Cliente.EnableSsl = true;
            Cliente.Host = "smtp.gmail.com";
            try
            {
                Cliente.Send(Mensaje);
                MessageBox.Show(this, "Correo Enviado Exitosamente a: " + Correo, "Envio Existoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.OK;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Ha Ocurrido Un Error Al Enviar Correo", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.Cancel;
            }

        }
        #endregion

        #region INSTANCIAR DATATABLE
        private void Instanciar()
        {
            dtFechasCitas.Columns.Add("idSesionCita", typeof(int));
            dtFechasCitas.Columns.Add("FechaCita", typeof(DateTime));
            dtFechasCitas.Columns.Add("ELIMINADO", typeof(bool));

            dtInventario.Columns.Add("idCitaInventario", typeof(int));
            dtInventario.Columns.Add("idInventario", typeof(int));
            dtInventario.Columns.Add("Cantidad", typeof(int));
            dtInventario.Columns.Add("ELIMINADO", typeof(bool));

            dtImagenes.Columns.Add("idImagenTattoo", typeof(int));
            dtImagenes.Columns.Add("ImagenTattoo", typeof(string));
            dtImagenes.Columns.Add("ELIMINADO", typeof(bool));

            Instancia = true;
        }
        #endregion

        #region ELIMINAR ARCHIVOS CAPTURAS
        private void EliminarCapturas()
        {
            String tempFolder = @"..\..\..\SISTEMA.WINFORMS.CAPTURAS.TATOO\Capturas";
            foreach (var item in Directory.GetFiles(tempFolder, "*.*"))
            {
                File.SetAttributes(item, FileAttributes.Normal);
                File.Delete(item);
            }
        }
        #endregion

        private void CitasPendientes_Click(object sender, EventArgs e)
        {
            frmTATCitasPendientes frm = new frmTATCitasPendientes();
            string nombreTabla = "Citas Pendientes";
            AgregarHijos(ref nombreTabla, frm);
        }
    }
}

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
using System.Net.Mail;
using System.IO;
using System.Threading;

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

       // frmTATEnviando frmEnviando = new frmTATEnviando();

        public string USUARIO = "";
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        DataTable dtInventario = new DataTable();
        DataTable dtFechasCitas = new DataTable();
        DataTable dtImagenes = new DataTable();

        
 
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            if (lstLista.SelectedItems.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnMostrar.Enabled = false;
                btnFinalizado.Enabled = false;
            }
            else
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnMostrar.Enabled = true;
                strCitas = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
                if(strCitas.idEstadoCita != 3)
                {
                    btnFinalizado.Enabled = true;
                }
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
                    L.SubItems.Add(Dato.FechaCita.ToString("dddd-d-MMMM-yyyy-hh:mm tt"));
                    L.SubItems.Add(Convert.ToString(Dato.NumeroSesion));
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
            Instanciar();
            dtpInicio.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
            dtpFin.Value = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7);
            dtpFin.Value = new DateTime(dtpFin.Value.Year, dtpFin.Value.Month, dtpFin.Value.Day, 23, 59, 0);
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
                    RefreshList();
                }

            }
        }
        #endregion

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult R;
            strCitas = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
           R =  MessageBox.Show(this, "¿Desea eliminar la cita?", "Eliminar cita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(R == DialogResult.Yes)
            {
                bool Elimina = TABLA_Citas.DAO(ref strCitas, 3, dtInventario, dtFechasCitas, dtImagenes);
                if (Elimina)
                {
                    RefreshList();
                }
                else
                {

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
        }
        #endregion

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnFinalizado_Click(object sender, EventArgs e)
        {
            DialogResult R;
            DialogResult C;
            DialogResult A;
            strCitas = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
            if(strCitas.idEstadoCita != 3)
            {
                strCitas.idEstadoCita = 3;
                R = MessageBox.Show(this, "¿Desea finalizar la cita?", "Finalizar cita", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (R == DialogResult.Yes)
                {
                    ptbEnviando.Visible = true;
                    lblEnviando.Visible = true;
                    Thread.Sleep(3000);
                    bool Cambia = TABLA_Citas.DAO(ref strCitas, 2, dtInventario, dtFechasCitas, dtImagenes);
                    if (Cambia)
                    {
                        C = EnviarCorreo(strCitas.Correo);
                        if(C == DialogResult.OK)
                        {
                            strCitas.EstadoCorreo = true;
                            Cambia = TABLA_Citas.DAO(ref strCitas, 2, dtInventario, dtFechasCitas, dtImagenes);
                        }
                        RefreshList();

                    }
                }
            }
        }

        

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }

        #region ENVIAR CORREO
        private DialogResult EnviarCorreo(string Correo)
        {
            //string file = "FinalFantasy.pdf";
            
            string ruta = (Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"..\SISTEMA.WINFORMS.CAPTURAS.TATOO\PDF\cuidados para el tatuaje.pdf"));
            MailMessage Mensaje = new MailMessage();
            Mensaje.To.Add(Correo);
            Mensaje.Subject = "Como cuidar tu tattoo inksaciable";
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
                ptbEnviando.Visible = false;
                lblEnviando.Visible = false;
                MessageBox.Show(this, "Correo Enviado Exitosamente a: " + Correo, "Envio Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.OK;
            }
            catch (Exception e)
            {
                ptbEnviando.Visible = false;
                lblEnviando.Visible = false;
                MessageBox.Show(this, "Ha Ocurrido Un Error Al Enviar Correo", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.Cancel;
            }

        }
        #endregion


    }
}

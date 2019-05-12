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

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATEnviando : Form
    {
        public frmTATEnviando()
        {
            InitializeComponent();
        }

        #region OBJETOS
        public string CORREO;
        #endregion


        #region ENVIAR CORREO
        private DialogResult EnviarCorreo(string Correo)
        {


            
            //string file = "FinalFantasy.pdf";
            string ruta = (Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"..\SISTEMA.WINFORMS.CAPTURAS.TATOO\PDF\HistorialMedico.pdf"));
            MailMessage Mensaje = new MailMessage();
            Mensaje.To.Add(Correo);
            Mensaje.Subject = "PDF";
            Mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
            Mensaje.Body = "PROBANDO PDF";
            Mensaje.Attachments.Add(new Attachment(ruta));
            Mensaje.BodyEncoding = System.Text.Encoding.UTF8;
            Mensaje.IsBodyHtml = true;
            Mensaje.From = new System.Net.Mail.MailAddress("rleyvacastro@gmail.com");
            SmtpClient Cliente = new SmtpClient();
            Cliente.Credentials = new System.Net.NetworkCredential("rleyvacastro@gmail.com", "As5drq9zv7391,");
            Cliente.Port = 587;
            Cliente.EnableSsl = true;
            Cliente.Host = "smtp.gmail.com";
            try
            {
                Cliente.Send(Mensaje);
                //EnviandoCorreo.Enabled = false;
                MessageBox.Show(this, "Correo Enviado Exitosamente a: " + Correo, "Envio Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.OK;
            }
            catch (Exception e)
            {

                MessageBox.Show(this, "Ha Ocurrido Un Error Al Enviar Correo", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DialogResult.Cancel;
            }

        }
        #endregion

        private void Enviar_Tick(object sender, EventArgs e)
        {
            EnviarCorreo(CORREO);
        }
    }
}

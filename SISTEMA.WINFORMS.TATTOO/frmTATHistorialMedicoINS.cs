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
using System.IO;
using System.Drawing.Imaging;


namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATHistorialMedicoINS : Form
    {
        public frmTATHistorialMedicoINS()
        {
            InitializeComponent();
        }

        

        #region OBJETOS
        public TATClientes.strTATClientes strClientes = new TATClientes.strTATClientes();
        Point posicionPrevia = new Point(-1, -1);
        public string DireccionFirma = "";
        Random rnd = new Random();
        bool ObligatorioFirma;
        #endregion

        #region CHKS
        private void chkHipertensionSi_Click(object sender, EventArgs e)
        {
            chkHipertensionSi.Checked = true;
            chkHipertensionNo.Checked = false;
            Obligatorio();
        }

        private void chkHipertensionNo_Click(object sender, EventArgs e)
        {
            chkHipertensionNo.Checked = true;
            chkHipertensionSi.Checked = false;
            Obligatorio();

        }

        private void chkDiabetesSi_Click(object sender, EventArgs e)
        {
            chkDiabetesSi.Checked = true;
            chkDiabetesNo.Checked = false;
            Obligatorio();
        }

        private void chkDiabetesNo_Click(object sender, EventArgs e)
        {
            chkDiabetesNo.Checked = true;
            chkDiabetesSi.Checked = false;
            Obligatorio();
        }

        private void chkHemofiliaSi_Click(object sender, EventArgs e)
        {
            chkHemofiliaSi.Checked = true;
            chkHemofiliaNo.Checked = false;
            Obligatorio();
        }

        private void chkHemofiliaNo_Click(object sender, EventArgs e)
        {
            chkHemofiliaNo.Checked = true;
            chkHemofiliaSi.Checked = false;
            Obligatorio();
        }

        private void chkAfeccionesCarSi_Click(object sender, EventArgs e)
        {
            chkAfeccionesCarSi.Checked = true;
            chkAfeccionesCarNo.Checked = false;
            Obligatorio();
        }

        private void chkAfeccionesCarNo_Click(object sender, EventArgs e)
        {
            chkAfeccionesCarNo.Checked = true;
            chkAfeccionesCarSi.Checked = false;
            Obligatorio();
        }

        private void chkAfeccionesRenSi_Click(object sender, EventArgs e)
        {
            chkAfeccionesRenSi.Checked = true;
            chkAfeccionesRenNo.Checked = false;
            Obligatorio();
        }

        private void chkAfeccionesRenNo_Click(object sender, EventArgs e)
        {
            chkAfeccionesRenNo.Checked = true;
            chkAfeccionesRenSi.Checked = false;
            Obligatorio();
        }

        private void chkFiebreReumSi_Click(object sender, EventArgs e)
        {
            chkFiebreReumSi.Checked = true;
            chkFiebreReumNo.Checked = false;
            Obligatorio();
        }

        private void chkFiebreReumNo_Click(object sender, EventArgs e)
        {
            chkFiebreReumNo.Checked = true;
            chkFiebreReumSi.Checked = false;
            Obligatorio();
        }

        private void chkHepatitisSi_Click(object sender, EventArgs e)
        {
            chkHepatitisSi.Checked = true;
            chkHepatitisNo.Checked = false;
            Obligatorio();
        }

        private void chkHepatitisNo_Click(object sender, EventArgs e)
        {
            chkHepatitisNo.Checked = true;
            chkHepatitisSi.Checked = false;
            Obligatorio();
        }

        private void chkTuberculosisSI_Click(object sender, EventArgs e)
        {
            chkTuberculosisSI.Checked = true;
            chkTuberculosisNo.Checked = false;
            Obligatorio();
        }

        private void chkTuberculosisNo_Click(object sender, EventArgs e)
        {
            chkTuberculosisNo.Checked = true;
            chkTuberculosisSI.Checked = false;
            Obligatorio();
        }

        private void chkSidaSi_Click(object sender, EventArgs e)
        {
            chkSidaSi.Checked = true;
            chkSidaNo.Checked = false;
            Obligatorio();
        }

        private void chkSidaNo_Click(object sender, EventArgs e)
        {
            chkSidaNo.Checked = true;
            chkSidaSi.Checked = false;
            Obligatorio();
        }

        private void chkCancerSi_Click(object sender, EventArgs e)
        {
            chkCancerSi.Checked = true;
            chkCancerNo.Checked = false;
            Obligatorio();
        }

        private void chkCancerNo_Click(object sender, EventArgs e)
        {
            chkCancerNo.Checked = true;
            chkCancerSi.Checked = false;
            Obligatorio();
        }

        private void chkLupusSi_Click(object sender, EventArgs e)
        {
            chkLupusSi.Checked = true;
            chkLupusNo.Checked = false;
            Obligatorio();
        }

        private void chkLupusNo_Click(object sender, EventArgs e)
        {
            chkLupusNo.Checked = true;
            chkLupusSi.Checked = false;
            Obligatorio();
        }

        private void chkEmbarazoSi_Click(object sender, EventArgs e)
        {
            chkEmbarazoSi.Checked = true;
            chkEmbarazoNo.Checked = false;
            Obligatorio();
        }

        private void chkEmbarazoNo_Click(object sender, EventArgs e)
        {
            chkEmbarazoNo.Checked = true;
            chkEmbarazoSi.Checked = false;
            Obligatorio();
        }

        private void chkDificultadSangradoSi_Click(object sender, EventArgs e)
        {
            chkDificultadSangradoSi.Checked = true;
            chkDificultadSangradoNo.Checked = false;
            Obligatorio();
        }

        private void chkDificultadSangradoNo_Click(object sender, EventArgs e)
        {
            chkDificultadSangradoNo.Checked = true;
            chkDificultadSangradoSi.Checked = false;
            Obligatorio();
        }

        private void chkIntervencionesSi_Click(object sender, EventArgs e)
        {
            chkIntervencionesSi.Checked = true;
            chkIntervencionesNo.Checked = false;
            Obligatorio();
        }

        private void chkIntervencionesNo_Click(object sender, EventArgs e)
        {
            chkIntervencionesNo.Checked = true;
            chkIntervencionesSi.Checked = false;
            Obligatorio();
        }
        #endregion

        #region MOUSE MOVE DERECHO
        private void ptbFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (posicionPrevia.X == -1)
            {
                posicionPrevia = new Point(e.X, e.Y);
            }
            Point PosicionActual = new Point(e.X, e.Y);
            Graphics Dibujo = this.ptbFirma.CreateGraphics();
            Dibujo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (e.Button == MouseButtons.Left)
            {
                Dibujo.DrawLine(new Pen(Color.Black), posicionPrevia, PosicionActual);
                ObligatorioFirma = true;
            }
            
            Obligatorio();
            posicionPrevia = PosicionActual;
        }
        #endregion

        #region MOUSE CLICK IZQUIERDO
        private void ptbFirma_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (DireccionFirma != "")
                {
                    ptbFirma.Image.Dispose();
                    ptbFirma.Image = null;
                    File.Delete(DireccionFirma);
                    DireccionFirma = "";
                    ObligatorioFirma = false;
                    Obligatorio();
                }
                else
                {
                    ObligatorioFirma = false;
                    Obligatorio();
                    ptbFirma.Refresh();
                }
            }
        }
        #endregion

        #region CAMPOS OBLIGATORIOS
        private bool Obligatorio()
        {
            bool Min = true;
            if(!chkHipertensionSi.Checked && !chkHipertensionNo.Checked)
            {
                Min = false;
            }
            if(!chkDiabetesSi.Checked && !chkDiabetesNo.Checked)
            {
                Min = false;
            }
            if(!chkHemofiliaSi.Checked && !chkHemofiliaNo.Checked)
            {
                Min = false;
            }
            if(!chkAfeccionesCarSi.Checked && !chkAfeccionesCarNo.Checked)
            {
                Min = false;
            }
            if(!chkAfeccionesRenSi.Checked && !chkAfeccionesRenNo.Checked)
            {
                Min = false;
            }
            if(!chkFiebreReumSi.Checked && !chkFiebreReumNo.Checked)
            {
                Min = false;
            }
            if(!chkHepatitisSi.Checked && !chkHepatitisNo.Checked)
            {
                Min = false;
            }
            if(!chkTuberculosisSI.Checked && !chkTuberculosisNo.Checked)
            {
                Min = false;
            }
            if(!chkSidaSi.Checked && !chkSidaNo.Checked)
            {
                Min = false;
            }
            if(!chkCancerSi.Checked && !chkCancerNo.Checked)
            {
                Min = false;
            }
            if(!chkLupusSi.Checked && !chkLupusNo.Checked)
            {
                Min = false;
            }
            if(!chkEmbarazoSi.Checked && !chkEmbarazoNo.Checked)
            {
                Min = false;
            }
            if(!chkDificultadSangradoSi.Checked && !chkDificultadSangradoNo.Checked)
            {
                Min = false;
            }
            if(!chkIntervencionesSi.Checked && !chkIntervencionesNo.Checked)
            {
                Min = false;
            }
            if(txtOtrasEnfermedades.Text.Trim() == "")
            {
                Min = false;
            }
            /*if(nudMeses.Value == 0)
            {
                Min = false;
            }*/
            if(txtAlergias.Text.Trim() == "")
            {
                Min = false;
            }

            if (!ObligatorioFirma)
            {
                Min = false;
            }
            if (Min)
            {
                EnableButtons(Min);
            }

            return Min;
        }
        #endregion

        #region ENABLE BUTTONS
        private void EnableButtons(bool min)
        {
            if(min)
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Obligatorio())
            {
                CapturaDatos();
                CapturaPantalla();
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion

        #region CAPUTA PANTALLA
        private void CapturaPantalla()
        {
            Bitmap BmpScreen = new Bitmap(ptbFirma.Size.Width, ptbFirma.Size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics ScreenShot = Graphics.FromImage(BmpScreen);
            ScreenShot.CopyFromScreen(ptbFirma.Location.X + this.Location.X + gbFirma.Location.X, ptbFirma.Location.Y + this.Location.Y + gbFirma.Location.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            string fileNom = String.Empty;
            saveFileDialog1.Filter = "Excel files (*.png)|*.png";
            saveFileDialog1.RestoreDirectory = true;
            fileNom = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\SISTEMA.WINFORMS.CAPTURAS.TATOO\Capturas\Img" + Convert.ToString(rnd.Next(10000)) + ".png");
            DireccionFirma = fileNom;
            strClientes.Firma = DireccionFirma;
            BmpScreen.Save(fileNom, System.Drawing.Imaging.ImageFormat.Png);
        }
        #endregion

        #region LOAD
        private void frmTATHistorialMedicoINS_Load(object sender, EventArgs e)
        {
            //CargarFirma(DireccionFirma);
            //CargarDatos();
            EnableButtons(false);
            
        }
        #endregion

        #region CARGAR FIRMA
        private void CargarFirma(string Firma)
        {
            if (Firma != "")
            {
                openFileDialog1.FileName = Firma;
                ptbFirma.Image = Image.FromFile(openFileDialog1.FileName);
            }
            else
            {

            }
        }
        #endregion

        #region CARGAR DATOS
        private void CargarDatos()
        {
            if (strClientes.Hipertension)
            {
                chkHipertensionSi.Checked = true;
            }
            else if (!strClientes.Hipertension)
            {
                chkHipertensionNo.Checked = true;
            }

            if (strClientes.Diabetes)
            {
                chkDiabetesSi.Checked = true;
            }
            else if (!strClientes.Diabetes)
            {
                chkDiabetesNo.Checked = true;
            }

            if (strClientes.Hemofilia)
            {
                chkHemofiliaSi.Checked = true;
            }
            else if (!strClientes.Hemofilia)
            {
                chkHemofiliaNo.Checked = true;
            }

            if (strClientes.Afecciones)
            {
                chkAfeccionesCarSi.Checked = true;
            }
            else if (!strClientes.Afecciones)
            {
                chkAfeccionesCarNo.Checked = true;
            }

            if (strClientes.AfeccionesRen)
            {
                chkAfeccionesRenSi.Checked = true;
            }
            else if (!strClientes.AfeccionesRen)
            {
                chkAfeccionesRenNo.Checked = true;
            }

            if (strClientes.FiebreReum)
            {
                chkFiebreReumSi.Checked = true;
            }
            else if (!strClientes.FiebreReum)
            {
                chkFiebreReumNo.Checked = true;
            }

            if (strClientes.Hepatitis)
            {
                chkHepatitisSi.Checked = true;
            }
            else if (!strClientes.Hepatitis)
            {
                chkHepatitisNo.Checked = true;
            }

            if (strClientes.Tuberculosis)
            {
                chkTuberculosisSI.Checked = true;
            }
            else if (!strClientes.Tuberculosis)
            {
                chkTuberculosisNo.Checked = true;
            }

            if (strClientes.Sida)
            {
                chkSidaSi.Checked = true;
            }
            else if (!strClientes.Sida)
            {
                chkSidaNo.Checked = true;
            }

            if (strClientes.Cancer)
            {
                chkCancerSi.Checked = true;
            }
            else if (!strClientes.Cancer)
            {
                chkCancerNo.Checked = true;
            }

            if (strClientes.Lupus)
            {
                chkLupusSi.Checked = true;
            }
            else if (!strClientes.Lupus)
            {
                chkLupusNo.Checked = true;
            }

            if(strClientes.Otros != "")
            {
                txtOtrasEnfermedades.Text = strClientes.Otros;
            }

            if (strClientes.Embarazo)
            {
                chkEmbarazoSi.Checked = true;
            }
            else if (!strClientes.Embarazo)
            {
                chkEmbarazoNo.Checked = true;
            }

            if(strClientes.Alergias != "")
            {
                txtAlergias.Text = strClientes.Alergias;
            }

            if (strClientes.DificultadSangrado)
            {
                chkDificultadSangradoSi.Checked = true;
            }
            else if (!strClientes.DificultadSangrado)
            {
                chkDificultadSangradoNo.Checked = true;
            }

            if (strClientes.OtrasIntervenciones)
            {
                chkIntervencionesSi.Checked = true;
            }
            else if (!strClientes.OtrasIntervenciones)
            {
                chkIntervencionesNo.Checked = true;
            }

            if(strClientes.ComplicacionesInterv != "")
            {
                txtTuvoComplicacion.Text = strClientes.ComplicacionesInterv;
            }

            //txtCuantosMeses.Text = strClientes.Meses.ToString();
        }
        #endregion

        #region CAPTURAR DATOS
        private void CapturaDatos()
        {
            if (chkHipertensionSi.Checked)
            {
                strClientes.Hipertension = true;
            }
            else
            {
                strClientes.Hipertension = false;
            }

            if (chkDiabetesSi.Checked)
            {
                strClientes.Diabetes = true;
            }
            else
            {
                strClientes.Diabetes = false;
            }

            if (chkHemofiliaSi.Checked)
            {
                strClientes.Hemofilia = true;
            }
            else
            {
                strClientes.Hemofilia = false;
            }

            if (chkAfeccionesCarSi.Checked)
            {
                strClientes.Afecciones = true;
            }
            else
            {
                strClientes.Afecciones = false;
            }

            if (chkAfeccionesRenSi.Checked)
            {
                strClientes.AfeccionesRen = true;
            }
            else
            {
                strClientes.AfeccionesRen = false;
            }

            if (chkFiebreReumSi.Checked)
            {
                strClientes.FiebreReum = true;
            }
            else
            {
                strClientes.FiebreReum = false;
            }

            if (chkHepatitisSi.Checked)
            {
                strClientes.Hepatitis = true;
            }
            else
            {
                strClientes.Hepatitis = false;
            }

            if (chkTuberculosisSI.Checked)
            {
                strClientes.Tuberculosis = true;
            }
            else
            {
                strClientes.Tuberculosis = false;
            }

            if (chkSidaSi.Checked)
            {
                strClientes.Sida = true;
            }
            else
            {
                strClientes.Sida = false;
            }

            if (chkCancerSi.Checked)
            {
                strClientes.Cancer = true;
            }
            else
            {
                strClientes.Cancer = false;
            }

            if (chkLupusSi.Checked)
            {
                strClientes.Lupus = true;
            }
            else
            {
                strClientes.Lupus = false;
            }

            if (chkEmbarazoSi.Checked)
            {
                strClientes.Embarazo = true;
            }
            else
            {
                strClientes.Embarazo = false;
            }

            if (chkDificultadSangradoSi.Checked)
            {
                strClientes.DificultadSangrado = true;
            }
            else
            {
                strClientes.DificultadSangrado = false;
            }

            if (chkIntervencionesSi.Checked)
            {
                strClientes.OtrasIntervenciones = true;
            }
            else
            {
                strClientes.OtrasIntervenciones = false;
            }

            
            strClientes.Otros = txtOtrasEnfermedades.Text.Trim();
            strClientes.Meses = Convert.ToInt32(nudMeses.Value);
            strClientes.ComplicacionesInterv = txtTuvoComplicacion.Text.Trim();
            strClientes.Alergias = txtAlergias.Text.Trim();
        }
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void txtOtrasEnfermedades_TextChanged(object sender, EventArgs e)
        {
            Obligatorio();
        }

        private void txtAlergias_TextChanged(object sender, EventArgs e)
        {
            Obligatorio();
        }

        private void txtCuantosMeses_TextChanged(object sender, EventArgs e)
        {
            Obligatorio();
        }

        private void txtTuvoComplicacion_TextChanged(object sender, EventArgs e)
        {
            Obligatorio();
        }

    }
}

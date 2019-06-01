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

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATCitasPendientes : Form
    {
        #region Constructor
        public frmTATCitasPendientes()
        {
            InitializeComponent();
        }
        #endregion

        #region Objetos
        TATCitas TABLA_Citas = new TATCitas();
        TATCitas.strTATCitas str;
        #region Datatables
        DataTable dtInventario = new DataTable();
        DataTable dtFechasCitas = new DataTable();
        DataTable dtImagenes = new DataTable();
        #endregion
        #endregion

        #region Metodos
        #region Habilitar botones
        private void EnableButtons()
        {
            btnAprobar.Enabled = (lstLista.SelectedItems.Count != 0);
            btnAprobarTodos.Enabled = (lstLista.Items.Count != 0);
        }
        #endregion

        #region RefreshList
        private void RefreshList()
        {
            lstLista.Items.Clear();
            TATCitas.strTATCitas[] ARR = null;
            DateTime finicio;
            if (chkUsarFecha.Checked)
            {
                finicio = dtpInicio.Value;
            }
            else
            {
                finicio = DateTime.Now;
            }
            
            bool Resulto = TABLA_Citas.Listar(ref ARR, finicio);
            int i = 0;
            if (Resulto == true)
            {
                ListViewItem L;
                foreach (TATCitas.strTATCitas Dato in ARR)
                {
                    L = new ListViewItem();
                    L.Tag = Dato;
                    L.Text = Dato.nombreCliente;
                    L.SubItems.Add(Dato.FechaRegistro.ToString("dddd-d-MMMM-yyyy-hh:mm tt"));
                    L.SubItems.Add(Dato.Anticipo.ToString());
                    L.SubItems.Add(Dato.NombreEmpleado);
                    lstLista.Items.Add(L);
                    i++;
                }
            }

            EnableButtons();
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
        #endregion

        #region Eventos
        #region Botones
        #region Cerrar
        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Aprobar todos
        private void BtnAprobarTodos_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Seguro que deseas aprobar todas las citas?", "Atencion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (chkUsarFecha.Checked)
                {
                    str.FechaRegistro = dtpInicio.Value;
                }
                else
                {
                    str.FechaRegistro = DateTime.Now;
                }
                bool done = TABLA_Citas.DAO(ref str, 6, dtInventario, dtFechasCitas, dtImagenes);
                if (done)
                {
                    MessageBox.Show(this, "Aprobados Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }

            }
            RefreshList();
            EnableButtons();
        }
        #endregion

        #region Aprobar
        private void BtnAprobar_Click(object sender, EventArgs e)
        {
            str = (TATCitas.strTATCitas)lstLista.SelectedItems[0].Tag;
            bool done = TABLA_Citas.DAO(ref str, 5, dtInventario, dtFechasCitas, dtImagenes);
            if (done)
            {
                MessageBox.Show(this, "Aprobado Correctamente", "Operacion Correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(this, "Ha Ocurrido Un Error", "Operacion Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            RefreshList();
            EnableButtons();
        }
        #endregion

        #region Salir
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #endregion

        #region Carga de la forma
        private void FrmTATCitasPendientes_Load(object sender, EventArgs e)
        {
            RefreshList();
            Instanciar();
            dtpInicio.Enabled = chkUsarFecha.Checked;
        }
        #endregion

        #region Cambio en el elemento seleccionado en la lista
        private void LstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion

        #region Checkbox de usar fecha
        private void ChkUsarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = chkUsarFecha.Checked;
        }
        #endregion

        #region cabio en datetime picker
        private void DtpInicio_ValueChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion
        #endregion
    }
}

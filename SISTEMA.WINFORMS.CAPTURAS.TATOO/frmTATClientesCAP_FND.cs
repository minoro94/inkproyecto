using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using SISTEMA.TATTOO;
using SISTEMA.WINFORMS.TATTOO;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATClientesCAP_FND : Form
    {
        public frmTATClientesCAP_FND()
        {
            InitializeComponent();
            
        }

        #region OBJETOS
        TATClientes.strTATClientes strClientes = new TATClientes.strTATClientes();
        TATClientes TABLA_Clientes = new TATClientes();
        ArrayList IDsClientes = new ArrayList();
        TATClientes.strTATClientes[] ARR_Clientes;
        public string USUARIO;
        wfTATClientes WF = new wfTATClientes();
        #endregion

        #region FILL COMBO CLIENTES
        private void FillComboClientes()
        {
            TABLA_Clientes.Listar(ref ARR_Clientes);
            cbxClientes.Items.Clear();
            IDsClientes.Clear();
            try
            {
                foreach (TATClientes.strTATClientes Dato in ARR_Clientes)
                {
                    cbxClientes.Items.Add(Dato.nombreCliente);
                    IDsClientes.Add(Dato.idCliente);
                }
                cbxClientes.SelectedIndex = 0;
                TABLA_Clientes.Dispose();
            }
            catch
            {

            }
        }
        #endregion

        #region BUSCAR
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            wfTATClientes WF = new wfTATClientes();
            WF.Buscar(ref strClientes);
            for (int i = 0; i < IDsClientes.Count; i++)
            {
                if (strClientes.idCliente == Convert.ToInt32(IDsClientes[i]))
                {
                    cbxClientes.SelectedIndex = i;
                }
            }
        }
        #endregion

        #region BOTON AGREGAR
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = WF.Agregar(ref USUARIO);
            FillComboClientes();
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmTATCitasCAP_INS frm = new frmTATCitasCAP_INS();
            strClientes.idCliente = Convert.ToInt32(IDsClientes[cbxClientes.SelectedIndex]);
            frm.idCliente = strClientes.idCliente;
            
            frm.USUARIO = USUARIO;

            this.Close();
            frm.ShowDialog();
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CLOSE
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region LOAD
        private void frmTATClientesCAP_FND_Load(object sender, EventArgs e)
        {
            FillComboClientes();
        }
        #endregion
    }
}

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

namespace SISTEMA.WINFORMS.TATTOO
{
    public partial class frmTATEmpleadosFND : Form
    {
        public frmTATEmpleadosFND()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATEmpleados.strTATEmpleados[] ARREmpleados;
        TATEmpleados TABLA_Empleados = new TATEmpleados();
        public TATEmpleados.strTATEmpleados strEmpleados = new TATEmpleados.strTATEmpleados();
        wfTATEmpleados WF = new wfTATEmpleados();

        TATTIpoEmpleados.strTATTipoEmpleados[] ARRTiposEmpleados;
        TATTIpoEmpleados TABLA_TiposEmpleados = new TATTIpoEmpleados();
        TATTIpoEmpleados.strTATTipoEmpleados strTiposEmpleados = new TATTIpoEmpleados.strTATTipoEmpleados();
        ArrayList IDsTiposEmpleados = new ArrayList();
        #endregion

        #region FILL COMBO TIPO PERMISO
        private void FillComboTipoEmpleado()
        {
            strTiposEmpleados.nombreTipoEmpleado = "";
            TABLA_TiposEmpleados.Listar(ref ARRTiposEmpleados);
            cbxTipoEmpleado.Items.Add("SIN FILTRO");
            IDsTiposEmpleados.Add(0);
            foreach (TATTIpoEmpleados.strTATTipoEmpleados dato in ARRTiposEmpleados)
            {
                cbxTipoEmpleado.Items.Add(dato.nombreTipoEmpleado);
                IDsTiposEmpleados.Add(dato.idTipoEmpleado);
            }
            cbxTipoEmpleado.SelectedIndex = 0;
            TABLA_TiposEmpleados.Dispose();
        }
        #endregion

        #region ENABLE BUTTONS
        public void EnableButtons()
        {
            btnAceptar.Enabled = (lstLista.SelectedItems.Count != 0);
        }
        #endregion

        #region REFRESH LIST
        public void RefreshList()
        {
            lstLista.Items.Clear();
            strEmpleados.nombreEmpleado = txtBuscar.Text.Trim();
            strEmpleados.idTipoEmpleado = (int)IDsTiposEmpleados[cbxTipoEmpleado.SelectedIndex];
            TABLA_Empleados.Listar(ref ARREmpleados, strEmpleados.nombreEmpleado);
            ListViewItem L;

            foreach (TATEmpleados.strTATEmpleados dato in ARREmpleados)
            {
                L = new ListViewItem();
                L.Text = dato.nombreEmpleado.ToString();
                L.SubItems.Add(dato.nombreTipoEmpleado);
                L.Tag = dato;
                lstLista.Items.Add(L);
            }
            EnableButtons();
        }
        #endregion

        #region BOTON BUSCAR TIPO EMPLEADO
        private void btnBuscarTipoEmpleado_Click(object sender, EventArgs e)
        {
            wfTATTiposEmpleados WF = new wfTATTiposEmpleados();
            WF.Buscar(ref strTiposEmpleados);
            for (int i = 0; i < IDsTiposEmpleados.Count; i++)
            {
                if (strTiposEmpleados.idTipoEmpleado == Convert.ToInt32(IDsTiposEmpleados[i]))
                {
                    cbxTipoEmpleado.SelectedIndex = i;
                }
            }
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            strEmpleados = (TATEmpleados.strTATEmpleados)lstLista.SelectedItems[0].Tag;
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region BOTON BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        #endregion

        #region TEXT CHANGED
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            RefreshList();
        }
        #endregion

        #region LOAD
        private void frmTATEmpleadosFND_Load(object sender, EventArgs e)
        {
            FillComboTipoEmpleado();
            RefreshList();
        }

        #endregion

        #region FORM CLOSING
        private void frmTATEmpleadosFND_FormClosing(object sender, FormClosingEventArgs e)
        {
            TABLA_Empleados.Dispose();
        }
        #endregion

        #region LISTA SELECTED IDNEX CHANGED
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons();
        }
        #endregion
    }
}

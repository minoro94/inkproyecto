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
using System.Collections;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATInventarioCAP : Form
    {
        public frmTATInventarioCAP()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATInventario TABLA = new TATInventario();
        TATInventario.strTATInventario[] ARR_Inventario;
        ArrayList IDsInventario = new ArrayList();

        
        public DataTable dTable = new DataTable();
        #endregion

        #region ENABLE BUTONS
        private void EnableButton()
        {
            if(lstLista.SelectedItems.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }

            if(lstLista.Items.Count > 0)
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }
        }
        #endregion

        #region FILL COMBO INVENTARIO
        private void FillComboInventario()
        {
            TABLA.Listar(ref ARR_Inventario);
            
            try
            {
                foreach(TATInventario.strTATInventario Dato in ARR_Inventario)
                {
                    cbxProducto.Items.Add(Dato.NombreProducto);
                    IDsInventario.Add(Dato.idInventario);
                }
                cbxProducto.SelectedIndex = 0;
                TABLA.Dispose();
            }
            catch
            {

            }
        }
        #endregion

        #region BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ListViewItem L;
            foreach(TATInventario.strTATInventario Dato in ARR_Inventario)
            {
                for (int i = 0; i < lstLista.Items.Count; i++)
                {
                    if (lstLista.Items[i].SubItems[0].Text == cbxProducto.SelectedItem.ToString())
                    {
                        if(lstLista.Items[i].SubItems[1].Text == nudCantidad.Value.ToString())
                        {
                            return;
                        }
                        else
                        {
                            lstLista.Items[i].SubItems[1].Text = nudCantidad.Value.ToString();
                            return;
                        }
                        
                    }
                }
                    if (Dato.NombreProducto == cbxProducto.SelectedItem.ToString())
                    {
                        L = new ListViewItem();
                        L.Tag = Dato;
                        L.Text = Dato.NombreProducto;
                        L.SubItems.Add(Convert.ToString(nudCantidad.Value));
                        lstLista.Items.Add(L);
                    }

                EnableButton();
                
            }
        }
        #endregion

        #region LOAD
        private void frmTATInventarioCAP_Load(object sender, EventArgs e)
        {
            EnableButton();
            FillComboInventario();
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

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            lstLista.Items.RemoveAt(lstLista.SelectedIndices[0]);
            EnableButton();
        }
        #endregion

        #region LISTA SELECTED INDEX CHANGED
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButton();
        }
        #endregion

        #region BOTON ACEPTAR
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            
            dTable.Columns.Add("idInventario", typeof(int));
            dTable.Columns.Add("Cantidad", typeof(int));
            
            foreach(TATInventario.strTATInventario Dato in ARR_Inventario)
            {
                for (int i = 0; i < lstLista.Items.Count; i++)
                {
                    if(Dato.NombreProducto == lstLista.Items[i].SubItems[0].Text)
                    {
                        dTable.Rows.Add(Dato.idInventario, Convert.ToInt32(lstLista.Items[i].SubItems[1].Text));
                    }
                }
                    
                
            }

        }
        #endregion
    }
}

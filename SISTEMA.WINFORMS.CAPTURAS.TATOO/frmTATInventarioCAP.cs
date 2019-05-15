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

        #region REFRESH LIST
        private void RefreshList()
        {
            ListViewItem L;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                L = new ListViewItem();
                L.Tag = dTable;
                foreach(TATInventario.strTATInventario Dato in ARR_Inventario)
                {
                    if(Convert.ToInt32(dTable.Rows[i].ItemArray[1]) == Dato.idInventario)
                    {
                        L.Text = Dato.NombreProducto;
                    }
                }
                //L.Text = dTable.Rows[i].ItemArray[1].ToString();
                L.SubItems.Add(Convert.ToString(dTable.Rows[i].ItemArray[2]));
                lstLista.Items.Add(L);
            }
            EnableButton();
        }
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

            /*if(lstLista.Items.Count > 0)
            {
                btnAceptar.Enabled = true;
            }
            else
            {
                btnAceptar.Enabled = false;
            }*/
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
            CrearDT();
            EnableButton();
            FillComboInventario();
            RefreshList();
            nudCantidad_KeyUp(null, null);
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
            if(lstLista.Items.Count == 0)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
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
            dTable.Clear();
            foreach(TATInventario.strTATInventario Dato in ARR_Inventario)
            {
                for (int i = 0; i < lstLista.Items.Count; i++)
                {
                    if(Dato.NombreProducto == lstLista.Items[i].SubItems[0].Text)
                    {
                        dTable.Rows.Add(0,Dato.idInventario, Convert.ToInt32(lstLista.Items[i].SubItems[1].Text),0);
                    }
                }
                    
                
            }

            if(lstLista.Items.Count == 0)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            
            Close();

        }
        #endregion

        #region CREAR DT
        private void CrearDT()
        {
            if(dTable.Columns.Count > 0)
            {
                
            }
            else
            {
                dTable.Columns.Add("idCitaInventario", typeof(int));
                dTable.Columns.Add("idInventario", typeof(int));
                dTable.Columns.Add("Cantidad", typeof(int));
                dTable.Columns.Add("ELIMINADO", typeof(bool));
            }
            
        }
        #endregion

        

        

        private void nudCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (nudCantidad.Value == 0)
            {
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;
            }
        }

        #region NUD CANTIDAD VALUE CHANGED
        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (nudCantidad.Value == 0)
            {
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;
            }
        }
        #endregion
    }
}

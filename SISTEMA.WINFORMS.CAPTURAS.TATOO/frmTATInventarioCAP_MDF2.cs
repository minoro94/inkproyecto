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
    public partial class frmTATInventarioCAP_MDF2 : Form
    {
        public frmTATInventarioCAP_MDF2()
        {
            InitializeComponent();
        }

        #region OBJETOS
        TATInventario TABLA = new TATInventario();
        TATInventario.strTATInventario[] ARR_Inventario;
        ArrayList IDsInventario = new ArrayList();
        public DataTable dTable = new DataTable();
        DataTable daux = new DataTable();
        #endregion

        #region REFRESHLIST
        /*Este RefreshList carga todos los datos de la DataTable Recibida y los muestra en una ListView la cual solo muestra la que el
         campo ELIMINADO = 0:
         Nombre del Producto
         Cantidad
         */
        private void RefreshList()
        {
            ListViewItem L;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                L = new ListViewItem();
                L.Tag = dTable;
                foreach (TATInventario.strTATInventario Dato in ARR_Inventario)
                {
                    if (Convert.ToInt32(dTable.Rows[i].ItemArray[1]) == Dato.idInventario && Convert.ToBoolean(dTable.Rows[i].ItemArray[3]) == false)
                    {
                        L.Text = Dato.NombreProducto;
                        L.SubItems.Add(Convert.ToString(dTable.Rows[i].ItemArray[2]));
                        lstLista.Items.Add(L);
                    }
                }
            }
            EnableButton();
        }
        #endregion

        #region CREAR DATA TABLE
        /*Este metodo llena la DataTable 'dTable' si esta recibe una DataTable vacia la cual es totalmente imposible para esta forma pero es una
         manera de evitar algun tipo de error al cargar los datos*/
        private void CrearDT()
        {
            if (dTable.Columns.Count > 0)
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

        #region ENABLE BUTONS
        /*Este metodo se utiliza para validar si la lista contiene elementos y habilita el boton Aceptar y validad que algo 
         en la lista este seleccionado para habilitar el boton Eliminar*/
        private void EnableButton()
        {
            if (lstLista.SelectedItems.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }

            if (lstLista.Items.Count > 0)
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
        /*Este metodo llena el Combo Box con el nombre de los productos de la tabla INVENTARIO
         y en un ArrayList almacena las ID*/
        private void FillComboInventario()
        {
            TABLA.Listar(ref ARR_Inventario);

            try
            {
                foreach (TATInventario.strTATInventario Dato in ARR_Inventario)
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
        /*Este boton contiene un metodo el cual agrega lo seleccionado del combo box y su cantidad a la DATA TABLE con sus respectivas
         validaciones*/
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
                int id = 0;
                ListViewItem L;
                foreach (TATInventario.strTATInventario Dato in ARR_Inventario)
                {
                    for (int i = 0; i < lstLista.Items.Count; i++)
                    {
                        if (lstLista.Items[i].SubItems[0].Text == cbxProducto.SelectedItem.ToString())
                        {

                            if (lstLista.Items[i].SubItems[1].Text == nudCantidad.Value.ToString())
                            {
                            EnableButton();
                                return;
                            }
                            if(Dato.NombreProducto == lstLista.Items[i].SubItems[0].Text)
                            {
                                lstLista.Items[i].SubItems[1].Text = nudCantidad.Value.ToString();
                                id = Dato.idInventario;
                                foreach(DataRow dat in dTable.Rows)
                                {
                                    if (id.Equals(dat["idInventario"]))
                                    {
                                        dat["Cantidad"] = nudCantidad.Value;
                                    EnableButton();
                                        return;
                                    }
                                }
                            EnableButton();
                                return;
                            }

                        }
                    }
                    if (Dato.NombreProducto == cbxProducto.SelectedItem.ToString())
                    {
                        if (Existe(Dato.idInventario, Dato.NombreProducto))
                        {
                            L = new ListViewItem();
                            L.Tag = Dato;
                            L.Text = Dato.NombreProducto;
                            L.SubItems.Add(Convert.ToString(nudCantidad.Value));
                            dTable.Rows.Add(0, Dato.idInventario, nudCantidad.Value, 0);
                            lstLista.Items.Add(L);
                        EnableButton();
                            return;
                        }
                        else
                        {
                        EnableButton();
                            return;
                        }
                    }


                    EnableButton();
                 
                }

        }
        #endregion

        #region EXISTE
        /*Este metodo se ejecuta cuando se agrega un elemento de la lista, este verifica si se encuentra en la DATATABLE pero este fue eliminado virtualmente
         , ELIMINADO = 1, si de existir este lo agregar a la lista y cambia ELIMINADO = 0 y retornar un FALSE, de no existir en la lista retorna un TRUE*/
        private bool Existe(int id, string nombreProducto)
        {
            ListViewItem L;
            foreach(DataRow dr in dTable.Rows)
            {
                if(Convert.ToInt32(dr["idInventario"]) == id)
                {
                    L = new ListViewItem();
                    //L.Tag = Dato;
                    L.Text = nombreProducto;
                    L.SubItems.Add(Convert.ToString(nudCantidad.Value));
                    dr["ELIMINADO"] = false;
                    dr["Cantidad"] = nudCantidad.Value;
                    lstLista.Items.Add(L);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region BOTON ELIMINAR
            /*Este boton contiene un metodo que lo unico que hace es cambiar el valor a 1 en el campo ELIMINADO
             del objeto del inventario seleccionado pero no lo remueve de la DATATABLE con fines de SQL y lo remueve de la ListView*/
            private void btnEliminar_Click(object sender, EventArgs e)
            {
                int id = 0;
                string producto = "";
                foreach (DataRow Dato in dTable.Rows)
                {
                    for (int i = 0; i < lstLista.Items.Count; i++)
                    {
                        foreach (TATInventario.strTATInventario ID in ARR_Inventario)
                        {
                            if (ID.NombreProducto == lstLista.Items[lstLista.SelectedIndices[0]].SubItems[0].Text)
                            {
                                id = ID.idInventario;
                                producto = ID.NombreProducto;
                            break;
                            }
                        }
                        if (id != 0)
                        {
                        foreach(DataRow r in dTable.Rows)
                        {
                            if(id == Convert.ToInt32(Dato["idInventario"]))
                            {
                                lstLista.Items.RemoveAt(lstLista.SelectedIndices[0]);
                                Dato["ELIMINADO"] = true;
                                return;
                            }
                        }
                        
                        }
                    }
                }
            } 
            #endregion

        #region LISTA SELECTED INDEX CHANGED
        private void lstLista_SelectedIndexChanged(object sender, EventArgs e)
        {
             EnableButton();
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

        #region BOTON ACEPTAR
        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region LOAD
        private void frmTATInventarioCAP_MDF2_Load_1(object sender, EventArgs e)
        {
            CrearDT();
            EnableButton();
            FillComboInventario();
            RefreshList();
            nudCantidad_KeyUp_1(null, null);
        }
        #endregion

        #region CLOSE
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region KEY UP
        private void nudCantidad_KeyUp_1(object sender, KeyEventArgs e)
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

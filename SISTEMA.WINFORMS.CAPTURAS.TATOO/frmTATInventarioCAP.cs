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

        strInven[] ARR = null;
        public DataTable dTable = new DataTable();
        #endregion

        #region ESTRUCTURA PRIVADA
        private struct strInven
        {
            public string NombreProducto;
            public int Cantidad;
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
            lstLista.Items.Clear();
            ARR = new strInven[ARR.Length + 1];
            for (int i = 0; i < ARR.Length; i++)
            {
                if(ARR == null)
                {
                    ARR[i].NombreProducto = cbxProducto.SelectedItem.ToString();
                    ARR[i].Cantidad = Convert.ToInt32(nudCantidad.Value);
                }
                else
                {
                    ARR[i].NombreProducto = ARR[i].NombreProducto;
                    ARR[i].Cantidad = ARR[i].Cantidad;
                }
                
            }
            ListViewItem L;
            foreach(strInven Dato in ARR)
            {
                L = new ListViewItem();
                L.Tag = Dato;
                L.Text = Dato.NombreProducto;
                L.SubItems.Add(Convert.ToString(Dato.Cantidad));
                lstLista.Items.Add(L);
            }
        }
        #endregion
    }
}

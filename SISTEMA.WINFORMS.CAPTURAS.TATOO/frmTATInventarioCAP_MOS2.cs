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
    public partial class frmTATInventarioCAP_MOS2 : Form
    {
        public frmTATInventarioCAP_MOS2()
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

        #region CREAR DATA TABLE
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

        #region REFRESHLIST
        private void RefreshList()
        {
            ListViewItem L;
            for (int i = 0; i < dTable.Rows.Count; i++)
            {
                L = new ListViewItem();
                L.Tag = dTable;
                TABLA.Listar(ref ARR_Inventario);
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

        }
        #endregion

        private void frmTATInventarioCAP_MOS2_Load(object sender, EventArgs e)
        {
            CrearDT();
            RefreshList();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

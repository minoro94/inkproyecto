using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public partial class frmTATFechasCitasCAP_MOS2 : Form
    {
        public frmTATFechasCitasCAP_MOS2()
        {
            InitializeComponent();
        }

        public DataTable dTable = new DataTable();
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTATFechasCitasCAP_MOS2_Load(object sender, EventArgs e)
        {
            CrearDT();
            RefreshList();
        }

        #region CREAR DATA TABLE
        /*Este metodo se ejecuta al entrar el evento LOAD como medida de seguridad
         por si el DATATABLE recibido no contiene nada (NULL), si este viene vacio
         se crean las columnas necesarias*/
        private void CrearDT()
        {
            if (dTable.Columns.Count > 0)
            {


            }
            else
            {
                dTable.Columns.Add("idSesionCita", typeof(int));
                dTable.Columns.Add("FechaCita", typeof(DateTime));
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
                if (Convert.ToBoolean(dTable.Rows[i].ItemArray[2]) == false)
                {
                    L.Text = Convert.ToString(dTable.Rows[i].ItemArray[1]);
                    lstLista.Items.Add(L);
                }
            }

        }
        #endregion
    }
}

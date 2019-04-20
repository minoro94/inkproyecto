using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;
using System.Collections;
using System.Data;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public class wfCitasInventario
    {
        #region AGREGAR
        public DialogResult Agregar(ref DataTable dtInvnetario)
        {
                frmTATInventarioCAP frm = new frmTATInventarioCAP();
                frm.dTable = dtInvnetario;
                return frm.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modiificar(ref DataTable dtInventario)
        {
            frmTATInventarioCAP_MDF2 frm = new frmTATInventarioCAP_MDF2();
            frm.dTable = dtInventario;
            return frm.ShowDialog();
        }
        #endregion

        #region MOSTRAR
        public DialogResult Mostrar(ref DataTable dtInventario)
        {
            frmTATInventarioCAP_MOS2 frm = new frmTATInventarioCAP_MOS2();
            frm.dTable = dtInventario;
            return frm.ShowDialog();
        }
        #endregion
    }
}

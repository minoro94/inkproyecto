using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISTEMA.TATTOO;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public class wfSesionesCitas
    {
        #region AGREGAR
        public DialogResult Agregar(ref DataTable dtFechaCitas)
        {
            frmTATFechasCitasCAP frm = new frmTATFechasCitasCAP();
            frm.dTable = dtFechaCitas;
            return frm.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref DataTable dtFechaCitas)
        {
            frmTATFechasCitasCAP_MDF2 frm = new frmTATFechasCitasCAP_MDF2();
            frm.dTable = dtFechaCitas;
            return frm.ShowDialog();
        }
        #endregion

        #region MOSTRAR
        public DialogResult Mostrar(ref DataTable dtFechaCitas)
        {
            frmTATFechasCitasCAP_MOS2 frm = new frmTATFechasCitasCAP_MOS2();
            frm.dTable = dtFechaCitas;
            return frm.ShowDialog();
        }
        #endregion
    }
}

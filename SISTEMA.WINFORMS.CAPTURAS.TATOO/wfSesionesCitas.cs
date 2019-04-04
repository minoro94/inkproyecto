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
    }
}

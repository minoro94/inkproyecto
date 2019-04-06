using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISTEMA.TATTOO;
using System.Windows.Forms;
using SISTEMA.TATTOO;
using System.Data;


namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public class wfTATFirma
    {
        

        #region AGREGAR
        public string Agregar(ref string firma)
        {
            frmTATFirmaCAP frm = new frmTATFirmaCAP();
            frm.DireccionFirma = firma;
            frm.ShowDialog();
            firma = frm.DireccionFirma;
            return frm.DireccionFirma;
        }
        #endregion
    }
}

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
        public DialogResult Agregar(ref TATCitas.strTATCitas str, DataTable fechacitas, DataTable inventa, DataTable imag, string Correo)
        {
            frmTATCitasCAP_DONE frm = new frmTATCitasCAP_DONE();
            frm.str = str;
            frm.dtableFechasCita = fechacitas;
            frm.dtInventario = inventa;
            frm.dtImagentestato = imag;
            frm.Correo = Correo;
            return frm.ShowDialog();
            
        }
        #endregion

        #region MODIFICAR
        public string Modificar(ref string firma)
        {
            frmTATFirmaCAP_MDF2 frm = new frmTATFirmaCAP_MDF2();
            frm.DireccionFirma = firma;
            frm.ShowDialog();
            return frm.DireccionFirma;
        }
        #endregion
    }
}

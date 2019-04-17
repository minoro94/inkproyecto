using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public class wfTATHistorialMedico
    {
        #region AGREGAR
        public DialogResult Agregar(ref TATClientes.strTATClientes strTATClientes)
        {
            frmTATHistorialMedicoINS frm = new frmTATHistorialMedicoINS();
            frm.strClientes = strTATClientes;
            frm.lblNombreCliente.Text = strTATClientes.nombreCliente;
            frm.DireccionFirma = strTATClientes.Firma;
            return frm.ShowDialog();
        }
        #endregion

        public TATClientes.strTATClientes Agregarr(ref TATClientes.strTATClientes strclientes)
        {
            frmTATHistorialMedicoINS frm = new frmTATHistorialMedicoINS();
            frm.strClientes = strclientes;
            frm.lblNombreCliente.Text = strclientes.nombreCliente;
            frm.DireccionFirma = strclientes.Firma;
            frm.ShowDialog();
            strclientes = frm.strClientes;
            return strclientes;
        }
        


        
    }
}

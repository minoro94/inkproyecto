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
        #endregion

        #region MODIFICAR
        public TATClientes.strTATClientes Modificar(ref TATClientes.strTATClientes strClientes)
        {
            frmTATHistorialMedicoMDF frm = new frmTATHistorialMedicoMDF();
            frm.strClientes = strClientes;
            frm.lblNombreCliente.Text = strClientes.nombreCliente;
            frm.ShowDialog();
            strClientes = frm.strClientes;
            return strClientes;
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATClientes.strTATClientes strClientes)
        {
            frmTATHistorialMedicoRMV frm = new frmTATHistorialMedicoRMV();
            frm.str = strClientes;
            return frm.ShowDialog();
        }
        #endregion

        #region MOSTRAR
        public DialogResult Mostrar(ref TATClientes.strTATClientes strClientes)
        {
            frmTATHistorialMedicoMOS frm = new frmTATHistorialMedicoMOS();
            frm.str = strClientes;
            return frm.ShowDialog();
        }
        #endregion




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
   public class wfTATEmpleados
    {
        #region OBJETOS
        TATEmpleados TABLA = new TATEmpleados();
        TATEmpleados.strTATEmpleados str = new TATEmpleados.strTATEmpleados();
        #endregion

        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATEmpleadosINS Forma = new frmTATEmpleadosINS();
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATEmpleados.strTATEmpleados str, string USUARIO)
        {
            frmTATEmpleadosMDF Forma = new frmTATEmpleadosMDF();
            Forma.IdEmpleados = str.idEmpleado;
            Forma.IdTiposEmpleados = str.idTipoEmpleado;
            Forma.txtNombreEmpleado.Text = str.nombreEmpleado;
            Forma.txtDireccion.Text = str.Direccion;
            Forma.txtTelefono.Text = str.Telefono;
            Forma.txtNumSeg.Text = str.numSeguro;
            Forma.USUARIO = USUARIO;

            return Forma.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATEmpleados.strTATEmpleados str, string USUARIO)
        {
            frmTATEmpleadosRMV Forma = new frmTATEmpleadosRMV();
            Forma.ID = str.idEmpleado;
            Forma.lblNombreEmpleado.Text = str.nombreEmpleado.ToString();
            Forma.lblTipoEmpleado.Text = str.nombreTipoEmpleado.ToString();
            Forma.lblDireccion.Text = str.Direccion.ToString();
            Forma.lblTelefono.Text = str.Telefono.ToString();
            Forma.lblNumSeg.Text = str.numSeguro.ToString();
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog(); ;
        }
        #endregion

        #region BUSCAR
        public DialogResult Buscar(ref TATEmpleados.strTATEmpleados DATOS)
        {
            frmTATEmpleadosFND Forma = new frmTATEmpleadosFND();
            DialogResult res = Forma.ShowDialog();
            DATOS = Forma.strEmpleados;
            return res;
        }
        #endregion
    }
}

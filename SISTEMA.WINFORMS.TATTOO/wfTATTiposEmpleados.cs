using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public class wfTATTiposEmpleados
    {

        #region OBJETOS
        TATTIpoEmpleados TABLA = new TATTIpoEmpleados();
        TATTIpoEmpleados.strTATTipoEmpleados str = new TATTIpoEmpleados.strTATTipoEmpleados();
        #endregion

        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATTiposEmpleadosINS Forma = new frmTATTiposEmpleadosINS();
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATTIpoEmpleados.strTATTipoEmpleados str, string USUARIO)
        {
            frmTATTiposEmpleadosMDF Forma = new frmTATTiposEmpleadosMDF();
            Forma.IDTiposEmpleados = str.idTipoEmpleado;
            Forma.IDTipoPermisos = str.idTipoPermiso;
            Forma.txtTipoEmpleado.Text = str.nombreTipoEmpleado;
            Forma.txtDescripcion.Text = str.Descripcion;
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATTIpoEmpleados.strTATTipoEmpleados str, string USUARIO)
        {
            frmTATTiposEmpleadosRMV Forma = new frmTATTiposEmpleadosRMV();
            Forma.ID = str.idTipoEmpleado;
            Forma.lblTipoEmpleado.Text = str.nombreTipoEmpleado.ToString();
            Forma.lblTipoPermiso.Text = str.nombreTipoPermiso.ToString();
            Forma.lblDescripcion.Text = str.Descripcion.ToString();
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion
        #region BUSCAR
        public DialogResult Buscar(ref TATTIpoEmpleados.strTATTipoEmpleados DATOS)
        {
            frmTATTiposEmpleadosFND Forma = new frmTATTiposEmpleadosFND();
            DialogResult res = Forma.ShowDialog();
            DATOS = Forma.str;
            return DialogResult.OK;
        }
        #endregion
    }
}

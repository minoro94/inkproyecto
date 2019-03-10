using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.MAINMENU
{
    public class wfTATUsuarios
    {
        #region OBJETOS
        TATUsuarios TABLA = new TATUsuarios();
        #endregion

        #region AGREGAR
        public DialogResult Agregar()
        {
            frmTATUsuariosINS Forma = new frmTATUsuariosINS();
            return Forma.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATUsuarios.strTATUsuarios str)
        {
            frmTATUsuariosMDF Forma = new frmTATUsuariosMDF();
            Forma.IdUsuario = str.idUsuario;
            Forma.IdEmpleado = str.idEmpleado;
            Forma.txtNombreUsuario.Text = str.nombreUsuario;
            Forma.txtContraseña.Text = str.Contraseña;

            TATPermisosTablas Tabla_PermisosTablas = new TATPermisosTablas();
            TATPermisosTablas.strTATPermisosTablas strPermisosTablas = new TATPermisosTablas.strTATPermisosTablas();
            TATPermisosTablas.strTATPermisosTablas[] ARR = null;

            strPermisosTablas.idUsuario = str.idUsuario;
            Tabla_PermisosTablas.Listar(ref ARR, strPermisosTablas);
            Forma.ARRPermisosTablas = ARR;
            return Forma.ShowDialog();
            
        }
        #endregion

        #region ELIMINAR
        public DialogResult Remover(ref int id)
        {
            frmTATUsuariosRMV Forma = new frmTATUsuariosRMV();
            TATUsuarios.strTATUsuarios str = new TATUsuarios.strTATUsuarios();
            TATPermisosTablas.strTATPermisosTablas strPermisosTablas = new TATPermisosTablas.strTATPermisosTablas();
            TATPermisosTablas.strTATPermisosTablas[] ARRPermisosTablas = null;
            TATPermisosTablas Tabla_PermisosTablas = new TATPermisosTablas();
            str.idUsuario = id;
            strPermisosTablas.idUsuario = id;
            TABLA.DAO(ref str, 4);
            Tabla_PermisosTablas.Listar(ref ARRPermisosTablas, strPermisosTablas);
            Forma.idUsuario = id;
            Forma.ARRPermisosTablas = ARRPermisosTablas;
            Forma.lblNombreEmpleado.Text = str.nombreEmpleado.ToString();
            Forma.lblNombreUsuario.Text = str.nombreUsuario.ToString();
            Forma.lblContraseña.Text = str.Contraseña.ToString();
            return Forma.ShowDialog();
            
        }
        #endregion
    }
}

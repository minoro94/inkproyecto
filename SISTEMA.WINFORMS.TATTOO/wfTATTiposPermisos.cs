using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public class wfTATTiposPermisos
    {

        #region OBJETOS
        public TATTiposPermisos TABLA = new TATTiposPermisos();
        #endregion

        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATTiposPermisosINS Forma = new frmTATTiposPermisosINS();
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
            
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATTiposPermisos.strTATTiposPermisos str, string USUARIO)
        {
            frmTATTIposPermisosMDF Forma = new frmTATTIposPermisosMDF();
            Forma.id = str.idTipoPermiso;
            Forma.txtTipoPermiso.Text = str.nombreTipoPermiso;
            Forma.txtDescripcion.Text = str.Descripcion;
            if (str.activo == true)
            {
                Forma.chkActivo.Checked = true;
            }
            else
            {
                Forma.chkActivo.Checked = false;
            }
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATTiposPermisos.strTATTiposPermisos str, string USUARIO)
        {
            frmTATTiposPermisosRMV Forma = new frmTATTiposPermisosRMV();
            Forma.id = str.idTipoPermiso;
            Forma.lblTipoPermiso.Text = str.nombreTipoPermiso;
            Forma.lblDescripcion.Text = str.Descripcion;
            if (str.activo == true)
            {
                Forma.chkActivo.Checked = true;
            }
            else
            {
                Forma.chkActivo.Checked = false;
            }
            Forma.USUARIO = USUARIO;

            return Forma.ShowDialog();

            
        }
        #endregion

        #region BUSCAR
        public DialogResult Buscar(ref TATTiposPermisos.strTATTiposPermisos DATOS)
        {
            frmTATTIposPermisosFND Forma = new frmTATTIposPermisosFND();
            DialogResult res = Forma.ShowDialog();
            DATOS = Forma.str;
            return res;
        }
        #endregion
    }
}

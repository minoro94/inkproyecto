using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public class wfTATInventario
    {
        #region OBJETOS
        TATInventario TABLA = new TATInventario();
        TATInventario.strTATInventario str = new TATInventario.strTATInventario();
        #endregion

        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO, int idUsuario)
        {
            frmTATInventarioINS frm = new frmTATInventarioINS();
            frm.USUARIO = USUARIO;
            frm.idUsuario = idUsuario;
            return frm.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATInventario.strTATInventario str, string USUARIO)
        {
            frmTATInventarioMDF frm = new frmTATInventarioMDF();
            frm.txtNombreProducto.Text = str.NombreProducto;
            frm.nudCantidad.Value = str.Cantidad;
            frm.txtNota.Text = str.Nota;
            frm.USUARIO = str.USUARIO;
            frm.idUsuario = str.idUsuario;
            return frm.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATInventario.strTATInventario str, string USUARIO)
        {
            frmTATInventarioRMV frm = new frmTATInventarioRMV();
            return frm.ShowDialog();
        }
        #endregion
    }
}

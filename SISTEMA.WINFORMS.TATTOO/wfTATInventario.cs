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
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATInventarioINS frm = new frmTATInventarioINS();
            return frm.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATInventario.strTATInventario str, string USUARIO)
        {
            frmTATInventarioMDF frm = new frmTATInventarioMDF();
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

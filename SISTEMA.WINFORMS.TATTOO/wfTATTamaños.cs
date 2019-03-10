using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.TATTOO
{
    public class wfTATTamaños
    {
        #region OBJETOS
        public TATTamaños TABLA = new TATTamaños();
        #endregion

        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATTamañosINS Forma = new frmTATTamañosINS();
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATTamaños.strTATTamaños str, string USUARIO)
        {
            frmTATTamañosMDF Forma = new frmTATTamañosMDF();
            Forma.id = str.idTamaño;
            Forma.txtTamaño.Text = str.Tamaño;
            Forma.txtDetalle.Text = str.Detalle;
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATTamaños.strTATTamaños str, string USUARIO)
        {
            frmTATTamañosRMV Forma = new frmTATTamañosRMV();
            Forma.id = str.idTamaño;
            Forma.lblTamaño.Text = str.Tamaño;
            Forma.lblDetalle.Text = str.Detalle;
            Forma.USUARIO = str.USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region BUSCAR
        public DialogResult Buscar(ref TATTamaños.strTATTamaños str, string USUARIO)
        {
            return DialogResult.OK;
        }
        #endregion
    }
}

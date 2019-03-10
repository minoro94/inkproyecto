using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISTEMA.TATTOO;
using System.Windows.Forms;

namespace SISTEMA.WINFORMS.TATTOO
{
    public class wfTATEstadoCita
    {
        #region OBJETOS
        TATEstadoCita TABLA = new TATEstadoCita();
        #endregion

        #region AGREGRAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATEstadoCitaINS frm = new frmTATEstadoCitaINS();
            frm.USUARIO = USUARIO;
            return frm.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATEstadoCita.strTATEstadoCita str, string USUARIO)
        {
            frmTATEstadoCitaMDF frm = new frmTATEstadoCitaMDF();
            frm.id = str.idEstadoCita;
            frm.txtNombreEstadoCita.Text = str.NombreEstadoCita;
            frm.txtDescripcion.Text = str.Descripcion;
            frm.USUARIO = USUARIO;
            return frm.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATEstadoCita.strTATEstadoCita str, string USUARIOA)
        {
            frmTATEstadoCitaRMV frm = new frmTATEstadoCitaRMV();
            frm.id = str.idEstadoCita;
            frm.lblNombreEstadoCita.Text = str.NombreEstadoCita;
            frm.lblDescripcion.Text = str.Descripcion;
            frm.USUARIO = str.USUARIO;
            return frm.ShowDialog();
        }
        #endregion
    }
}

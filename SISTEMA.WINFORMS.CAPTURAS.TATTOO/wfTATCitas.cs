﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.CAPTURAS.TATTOO
{
   public class wfTATCitas
    {
        #region OBJETOS
        TATCitas TABLA = new TATCitas();
        #endregion

        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATCitasCAT_INS Forma = new frmTATCitasCAT_INS();
            return Forma.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATCitas.strTATCitas str, string USUARIO)
        {
            frmTATCitasCAP_MDF Forma = new frmTATCitasCAP_MDF();
            return Forma.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATCitas.strTATCitas str, string USUARIO)
        {
            frmTATCitasCAP_RMV Forma = new frmTATCitasCAP_RMV();
            return Forma.ShowDialog();
        }
        #endregion
    }
}

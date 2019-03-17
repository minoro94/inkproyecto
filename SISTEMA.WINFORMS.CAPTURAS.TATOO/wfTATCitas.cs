﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SISTEMA.TATTOO;

namespace SISTEMA.WINFORMS.CAPTURAS.TATOO
{
    public class wfTATCitas
    {
        #region OBJETOS
        TATCitas TABLA = new TATCitas();
        #endregion

        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATClientesCAP_FND frm = new frmTATClientesCAP_FND();
            frm.USUARIO = USUARIO;
            
            return frm.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATCitas.strTATCitas str, string USUARIO)
        {
            frmTATCitasCAP_MDF Forma = new frmTATCitasCAP_MDF();
            Forma.lblNombreCliente.Text = str.nombreCliente;
            Forma.lblTelefono.Text = str.Telefono;
            Forma.txtAnticipo.Text = str.Anticipo.ToString();
            Forma.txtCosto.Text = str.Costo.ToString();
            Forma.txtDescripcion.Text = str.Descripcion;
            Forma.ptbPerfil.Image = Herramientas.decodeImagen(str.ZonaCuerpo, ".png");
            Forma.ptbTatuaje.Image = Herramientas.decodeImagen(str.ImagenTatto, ".png");
            Forma.imgtato = str.ImagenTatto;
            Forma.IDTamaño = str.idTamaño;
            Forma.IDEstadoCita = str.idEstadoCita;
            Forma.idCliente = str.idCliente;
            Forma.dtpFechaCita.Value = str.FechaCita;
            Forma.USUARIO = str.USUARIO;
            Forma.idCita = str.idCita;
            return Forma.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover(ref TATCitas.strTATCitas str, string USUARIO)
        {
            frmTATCitasCAP_RMV frm = new frmTATCitasCAP_RMV();
            frm.lblNombreCliente.Text = str.nombreCliente;
            frm.lblTelefono.Text = str.Telefono;
            frm.lblFechaCita.Text = str.FechaCita.ToLongDateString() + " " + str.FechaCita.ToLongTimeString();
            frm.lblEstadoCita.Text = str.NombreEstadoCita;
            frm.lblTamaño.Text = str.Tamaño;
            frm.ptbPerfil.Image = Herramientas.decodeImagen(str.ZonaCuerpo, ".png");
            frm.ptbTatuaje.Image = Herramientas.decodeImagen(str.ImagenTatto, ".png");
            frm.lblDescripcion.Text = str.Descripcion;
            frm.lblCosto.Text = str.Costo.ToString();
            frm.lblAnticipo.Text = str.Anticipo.ToString();
            frm.idCita = str.idCita;
            frm.USUARIO = USUARIO;
            return frm.ShowDialog();
        }
        #endregion

        #region MOSTRAR
        public DialogResult Mostrar(ref TATCitas.strTATCitas str, string USUARIO)
        {
            frmTATCitasCAP_MOS frm = new frmTATCitasCAP_MOS();
            frm.lblNombreCliente.Text = str.nombreCliente;
            frm.lblTelefono.Text = str.Telefono;
            frm.lblFechaCita.Text = str.FechaCita.ToLongDateString() + " " + str.FechaCita.ToLongTimeString();
            frm.lblEstadoCita.Text = str.NombreEstadoCita;
            frm.lblTamaño.Text = str.Tamaño;
            frm.ptbPerfil.Image = Herramientas.decodeImagen(str.ZonaCuerpo, ".png");
            frm.ptbTatuaje.Image = Herramientas.decodeImagen(str.ImagenTatto, ".png");
            frm.lblDescripcion.Text = str.Descripcion;
            frm.lblCosto.Text = str.Costo.ToString();
            frm.lblAnticipo.Text = str.Anticipo.ToString();
            return frm.ShowDialog();
        }
        #endregion
    }
}

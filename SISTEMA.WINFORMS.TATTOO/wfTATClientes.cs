﻿using System;
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
    public class wfTATClientes
    {


        #region AGREGAR
        public DialogResult Agregar(ref string USUARIO)
        {
            frmTATClientesINS Forma = new frmTATClientesINS();
            Forma.USUARIO = USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region MODIFICAR
        public DialogResult Modificar(ref TATClientes.strTATClientes str, string USUARIO)
        {
            frmTATClientesMDF Forma = new frmTATClientesMDF();
            Forma.str = str;
            Forma.id = str.idCliente;
            Forma.txtNombreCliente.Text = str.nombreCliente;
            Forma.txtTelefono.Text = str.Telefono;
            Forma.txtCorreo.Text = str.Correo;
            Forma.txtDomicilio.Text = str.Domicilio;
            Forma.txtINE.Text = str.Identificacion;
            Forma.txtEdad.Text = Convert.ToString(str.Edad);
            Forma.txtMunicipio.Text = str.Municipio;
            Forma.txtCodigoPostal.Text = str.CodigoPostal;
            if(str.Sexo == true)
            {
                Forma.rdbHombre.Checked = true;
                Forma.rdbMujer.Checked = false;
            }
            else
            {
                Forma.rdbHombre.Checked = false;
                Forma.rdbMujer.Checked = true;
            }
            Forma.USUARIO = str.USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region MOSTRAR
        public DialogResult Mostrar(ref TATClientes.strTATClientes str)
        {
            frmTATClientesMOS frm = new frmTATClientesMOS();
            frm.lblNombre.Text = str.nombreCliente;
            frm.lblTelefono.Text = str.Telefono;
            frm.lblCorreo.Text = str.Correo;
            frm.lblINE.Text = str.Identificacion;
            frm.lblEdad.Text = str.Edad.ToString();
            frm.lblDomicilio.Text = str.Domicilio;
            frm.lblMunicipio.Text = str.Municipio;
            frm.lblCodigoPostal.Text = str.CodigoPostal;
            if (str.Sexo)
            {
                frm.lblSexo.Text = "SI";
            }
            else
            {
                frm.lblSexo.Text = "NO";
            }
            frm.str = str;
            return frm.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover (ref TATClientes.strTATClientes str, string USUARIO)
        {
            frmTATClientesRMV Forma = new frmTATClientesRMV();
            Forma.str = str;
            Forma.id = str.idCliente;
            Forma.lblNombreCliente.Text = str.nombreCliente;
            Forma.lblTelefono.Text = str.Telefono;
            Forma.lblCorreo.Text = str.Correo;
            Forma.lblDomicilio.Text = str.Domicilio;
            Forma.lblINE.Text = str.Identificacion;
            Forma.lblEdad.Text = Convert.ToString(str.Edad);
            Forma.lblMunicipio.Text = str.Municipio;
            Forma.lblCodigoPostal.Text = str.CodigoPostal;
            if (str.Sexo == true)
            {
                Forma.lblSexo.Text = "Hombre";
            }
            else
            {
                Forma.lblSexo.Text = "Mujer";
            }
            Forma.USUARIO = str.USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region BUSCAR
        public DialogResult Buscar(ref TATClientes.strTATClientes DATOS)
        {
            frmTATClientesFND Forma = new frmTATClientesFND();
            DialogResult res = Forma.ShowDialog();
            DATOS = Forma.str;
            return DialogResult.OK;
        }
        #endregion
    }
}

using System;
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
        #region OBJETOS
        TATClientes TABLA = new TATClientes();
        TATClientes.strTATClientes str = new TATClientes.strTATClientes();
        #endregion

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
            Forma.txtHistorialMedico.Text = str.HistorialMedico;
            Forma.USUARIO = str.USUARIO;
            return Forma.ShowDialog();
        }
        #endregion

        #region REMOVER
        public DialogResult Remover (ref TATClientes.strTATClientes str, string USUARIO)
        {
            frmTATClientesRMV Forma = new frmTATClientesRMV();
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
            Forma.lblHistorialMedico.Text = str.HistorialMedico;
            Forma.USUARIO = str.USUARIO;
            return Forma.ShowDialog();
        }
        #endregion
    }
}

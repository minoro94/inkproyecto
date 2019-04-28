using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATClientes
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        public TATHistorialesMedicos strHistoriales = new TATHistorialesMedicos();
        #endregion

        #region ESTRUCTURA
        public struct strTATClientes
        {
            public int idCliente;
            public string nombreCliente;
            public string Telefono;
            public string Correo;
            public string Identificacion;
            public string Domicilio;
            public string Municipio;
            public string CodigoPostal;
            public int Edad;
            public bool Sexo;

            public bool Hipertension;
            public bool Diabetes;
            public bool Hemofilia;
            public bool Afecciones;
            public bool AfeccionesRen;
            public bool FiebreReum;
            public bool Hepatitis;
            public bool Sida;
            public bool Tuberculosis;
            public bool Cancer;
            public bool Lupus;
            public string Otros;
            public bool Embarazo;
            public int Meses;
            public string Alergias;
            public bool DificultadSangrado;
            public bool OtrasIntervenciones;
            public string ComplicacionesInterv;
            public string Firma;

            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;

        }
        #endregion

        #region LISTARES
        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATClientes[] ARR)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;

            DB.COM1.CommandText = "Select count (*) from visClientes where ELIMINADO = 0";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from visClientes where ELIMINADO = 0";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATClientes[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATClientes();
                    ARR[i].idCliente = (int)DB.REG1["idCliente"];
                    ARR[i].nombreCliente = (string)DB.REG1["nombreCliente"];
                    ARR[i].Telefono = (string)DB.REG1["Telefono"].ToString().Trim();
                    ARR[i].Correo = (string)DB.REG1["Correo"];
                    ARR[i].Identificacion = (string)DB.REG1["Identificacion"];
                    ARR[i].Domicilio = (string)DB.REG1["Domicilio"];
                    ARR[i].Municipio = (string)DB.REG1["Municipio"];
                    ARR[i].CodigoPostal = (string)DB.REG1["CodigoPostal"].ToString().Trim();
                    ARR[i].Edad = Convert.ToInt16(DB.REG1["Edad"]);
                    ARR[i].Sexo = (bool)DB.REG1["Sexo"];

                    ARR[i].Hipertension = (bool)DB.REG1["Hipertension"];
                    ARR[i].Diabetes = (bool)DB.REG1["Diabetes"];
                    ARR[i].Hemofilia = (bool)DB.REG1["Hemofilia"];
                    ARR[i].Afecciones = (bool)DB.REG1["AfeccionesCard"];
                    ARR[i].AfeccionesRen = (bool)DB.REG1["AfeccionesRen"];
                    ARR[i].FiebreReum = (bool)DB.REG1["FiebreReum"];
                    ARR[i].Hepatitis = (bool)DB.REG1["Hepatitis"];
                    ARR[i].Sida = (bool)DB.REG1["Sida"];
                    ARR[i].Tuberculosis = (bool)DB.REG1["Tuberculosis"];
                    ARR[i].Cancer = (bool)DB.REG1["Cancer"];
                    ARR[i].Lupus = (bool)DB.REG1["Lupus"];
                    ARR[i].Otros = (string)DB.REG1["Otros"];
                    ARR[i].Embarazo = (bool)DB.REG1["Embarazo"];
                    ARR[i].Meses = Convert.ToInt16(DB.REG1["Meses"]);
                    ARR[i].Alergias = (string)DB.REG1["Alergias"];
                    ARR[i].DificultadSangrado = (bool)DB.REG1["DificultadSangrado"];
                    ARR[i].OtrasIntervenciones = (bool)DB.REG1["OtrasIntervenciones"];
                    ARR[i].ComplicacionesInterv = (string)DB.REG1["ComplicacionesInterv"];
                    ARR[i].Firma = (string)DB.REG1["Firma"];

                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    i++;
                }
                DB.REG1.Close();
                DB.objConexion.Close();
                return true;
            }
            catch(Exception e)
            {
                DB.objConexion.Close();
                DB.REG1.Close();
                return false;
            }
        }
        #endregion

        #region LISTAR CON FILTRO
        public bool Listar(ref strTATClientes[] ARR, strTATClientes filtro)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            if(filtro.nombreCliente != null)
            {
                DB.COM1.CommandText = "Select count (*) from visClientes where ELIMINADO = 0 AND nombreCliente like '%' + '" + filtro.nombreCliente + "' + '%'";
                Cuantos = (int)DB.COM1.ExecuteScalar();

                DB.COM1.CommandText = "Select * from visClientes where ELIMINADO = 0 AND nombreCliente like '%' + '" + filtro.nombreCliente + "' + '%'";
            }
            else if(filtro.idCliente != 0)
            {
                DB.COM1.CommandText = "Select count (*) from visClientes where ELIMINADO = 0 AND idCliente = " + filtro.idCliente + " ";
                Cuantos = (int)DB.COM1.ExecuteScalar();

                DB.COM1.CommandText = "Select * from visClientes where ELIMINADO = 0 AND idCliente = " + filtro.idCliente + " ";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from visClientes where ELIMINADO = 0 ";
                Cuantos = (int)DB.COM1.ExecuteScalar();

                DB.COM1.CommandText = "Select * from visClientes where ELIMINADO = 0 ";
            }

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATClientes[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATClientes();
                    ARR[i].idCliente = (int)DB.REG1["idCliente"];
                    ARR[i].nombreCliente = (string)DB.REG1["nombreCliente"];
                    ARR[i].Telefono = (string)DB.REG1["Telefono"].ToString().Trim();
                    ARR[i].Correo = (string)DB.REG1["Correo"];
                    ARR[i].Identificacion = (string)DB.REG1["Identificacion"];
                    ARR[i].Domicilio = (string)DB.REG1["Domicilio"];
                    ARR[i].Municipio = (string)DB.REG1["Municipio"];
                    ARR[i].CodigoPostal = (string)DB.REG1["CodigoPostal"].ToString().Trim();
                    ARR[i].Edad = Convert.ToInt16(DB.REG1["Edad"]);
                    ARR[i].Sexo = (bool)DB.REG1["Sexo"];


                    ARR[i].Hipertension = (bool)DB.REG1["Hipertension"];
                    ARR[i].Diabetes = (bool)DB.REG1["Diabetes"];
                    ARR[i].Hemofilia = (bool)DB.REG1["Hemofilia"];
                    ARR[i].Afecciones = (bool)DB.REG1["AfeccionesCard"];
                    ARR[i].AfeccionesRen = (bool)DB.REG1["AfeccionesRen"];
                    ARR[i].FiebreReum = (bool)DB.REG1["FiebreReum"];
                    ARR[i].Hepatitis = (bool)DB.REG1["Hepatitis"];
                    ARR[i].Sida = (bool)DB.REG1["Sida"];
                    ARR[i].Tuberculosis = (bool)DB.REG1["Tuberculosis"];
                    ARR[i].Cancer = (bool)DB.REG1["Cancer"];
                    ARR[i].Lupus = (bool)DB.REG1["Lupus"];
                    ARR[i].Otros = (string)DB.REG1["Otros"];
                    ARR[i].Embarazo = (bool)DB.REG1["Embarazo"];
                    ARR[i].Meses = Convert.ToInt16(DB.REG1["Meses"]);
                    ARR[i].Alergias = (string)DB.REG1["Alergias"];
                    ARR[i].DificultadSangrado = (bool)DB.REG1["DificultadSangrado"];
                    ARR[i].OtrasIntervenciones = (bool)DB.REG1["OtrasIntervenciones"];
                    ARR[i].ComplicacionesInterv = (string)DB.REG1["ComplicacionesInterv"];
                    ARR[i].Firma = (string)DB.REG1["Firma"];

                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    i++;
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                DB.REG1.Close();
                DB.objConexion.Close();
            }
        }
        #endregion
        #endregion

        #region DAO
        public bool DAO(ref strTATClientes str, int Instruccion)
        {
            DB.conexionBD();

            DB.COM1.CommandText = "spClientes";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();

            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idCliente",str.idCliente);
                DB.COM1.Parameters.AddWithValue("nombreCliente",str.nombreCliente);
                DB.COM1.Parameters.AddWithValue("Telefono",str.Telefono);
                DB.COM1.Parameters.AddWithValue("Correo",str.Correo);
                DB.COM1.Parameters.AddWithValue("Identificacion",str.Identificacion);
                DB.COM1.Parameters.AddWithValue("Domicilio",str.Domicilio);
                DB.COM1.Parameters.AddWithValue("Municipio",str.Municipio);
                DB.COM1.Parameters.AddWithValue("CodigoPostal",str.CodigoPostal);
                DB.COM1.Parameters.AddWithValue("Edad",str.Edad);
                DB.COM1.Parameters.AddWithValue("Sexo",str.Sexo);


                DB.COM1.Parameters.AddWithValue("Hipertension", str.Hipertension);
                DB.COM1.Parameters.AddWithValue("Diabetes", str.Diabetes);
                DB.COM1.Parameters.AddWithValue("Hemofilia", str.Hemofilia);
                DB.COM1.Parameters.AddWithValue("AfeccionesCard", str.Afecciones);
                DB.COM1.Parameters.AddWithValue("AfeccionesRen", str.AfeccionesRen);
                DB.COM1.Parameters.AddWithValue("FiebreReum", str.FiebreReum);
                DB.COM1.Parameters.AddWithValue("Hepatitis", str.Hepatitis);
                DB.COM1.Parameters.AddWithValue("Sida", str.Sida);
                DB.COM1.Parameters.AddWithValue("Tuberculosis", str.Tuberculosis);
                DB.COM1.Parameters.AddWithValue("Cancer", str.Cancer);
                DB.COM1.Parameters.AddWithValue("Lupus", str.Lupus);
                DB.COM1.Parameters.AddWithValue("Otros", str.Otros);
                DB.COM1.Parameters.AddWithValue("Embarazo", str.Embarazo);
                DB.COM1.Parameters.AddWithValue("Meses", str.Meses);
                DB.COM1.Parameters.AddWithValue("Alergias", str.Alergias);
                DB.COM1.Parameters.AddWithValue("DificultadSangrado", str.DificultadSangrado);
                DB.COM1.Parameters.AddWithValue("OtrasIntervenciones", str.OtrasIntervenciones);
                DB.COM1.Parameters.AddWithValue("ComplicacionesInterv", str.ComplicacionesInterv);
                DB.COM1.Parameters.AddWithValue("Firma", str.Firma);


                DB.COM1.Parameters.AddWithValue("USUARIO",str.USUARIO);
                DB.COM1.Parameters.AddWithValue("FECHAHORACAMBIO",DateTime.Now);
                DB.COM1.Parameters.AddWithValue("ELIMINADO",str.ELIMINADO);

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idCliente = (int)DB.REG1["idCliente"];
                    str.nombreCliente = (string)DB.REG1["nombreCliente"];
                    str.Telefono = (string)DB.REG1["Telefono"].ToString().Trim();
                    str.Correo = (string)DB.REG1["Correo"];
                    str.Identificacion = (string)DB.REG1["Identificacion"];
                    str.Domicilio = (string)DB.REG1["Domicilio"];
                    str.Municipio = (string)DB.REG1["Municipio"];
                    str.CodigoPostal = (string)DB.REG1["CodigoPostal"].ToString().Trim();
                    str.Edad = (int)DB.REG1["Edad"];
                    str.Sexo = (bool)DB.REG1["Sexo"];


                    str.Hipertension = (bool)DB.REG1["Hipertension"];
                    str.Diabetes = (bool)DB.REG1["Diabetes"];
                    str.Hemofilia = (bool)DB.REG1["Hemofilia"];
                    str.Afecciones = (bool)DB.REG1["AfeccionesCard"];
                    str.AfeccionesRen = (bool)DB.REG1["AfeccionesRen"];
                    str.FiebreReum = (bool)DB.REG1["FiebreReum"];
                    str.Hepatitis = (bool)DB.REG1["Hepatitis"];
                    str.Sida = (bool)DB.REG1["Sida"];
                    str.Tuberculosis = (bool)DB.REG1["Tuberculosis"];
                    str.Cancer = (bool)DB.REG1["Cancer"];
                    str.Lupus = (bool)DB.REG1["Lupus"];
                    str.Otros = (string)DB.REG1["Otros"];
                    str.Embarazo = (bool)DB.REG1["Embarazo"];
                    str.Meses = Convert.ToInt16(DB.REG1["Meses"]);
                    str.Alergias = (string)DB.REG1["Alergias"];
                    str.DificultadSangrado = (bool)DB.REG1["DificultadSangrado"];
                    str.OtrasIntervenciones = (bool)DB.REG1["OtrasInvervenciones"];
                    str.ComplicacionesInterv = (string)DB.REG1["ComplicacionesInterv"];
                    str.Firma = (string)DB.REG1["Firma"];



                    str.USUARIO = (string)DB.REG1["USUARIO"];
                    str.FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    str.ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                }
                return true;

            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                DB.REG1.Close();
                DB.objConexion.Close();
                DB.COM1.Parameters.Clear();
                DB.COM1.CommandType = CommandType.Text;
            }
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            if(DB.objConexion != null)
            {
                if(DB.REG1 != null)
                {
                    if (!DB.REG1.IsClosed)
                    {
                        DB.REG1.Close();
                    }
                }
                if(DB.objConexion.State == ConnectionState.Open)
                {
                    DB.objConexion.Close();
                }
            }
        }
        #endregion
    }
}

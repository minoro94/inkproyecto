using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATEstadoCita
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATEstadoCita
        {
            public int idEstadoCita;
            public string NombreEstadoCita;
            public string Descripcion;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
        }
        #endregion

        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATEstadoCita[] ARR)
        {
            DB.conexionBD();
            
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;

            DB.COM1.CommandText = "Select count (*) from EstadoCita where ELIMINADO = 0";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from EstadoCita where ELIMINADO = 0";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATEstadoCita[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATEstadoCita();
                    ARR[i].idEstadoCita = (int)DB.REG1["idEstadoCita"];
                    ARR[i].NombreEstadoCita = (string)DB.REG1["NombreEstadoCita"];
                    ARR[i].Descripcion = (string)DB.REG1["Descripcion"];
                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    i++;
                }
                DB.REG1.Close();
                DB.objConexion.Close();
                return true;
            }
            catch
            {
                DB.objConexion.Close();
                DB.REG1.Close();
                return false;
            }
            
        }

        #region LISTAR CON FILTRO
        public bool Listar(ref strTATEstadoCita[] ARR, strTATEstadoCita filtro)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            if(filtro.NombreEstadoCita != "")
            {
                DB.COM1.CommandText = "Select count (*) from EstadoCita where ELIMINADO = 0 AND NombreEstadoCita like '%' + '" + filtro.NombreEstadoCita + "' + '%'";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from EstadoCita where ELIMINADO = 0 AND NombreEstadoCita like '%' + '" + filtro.NombreEstadoCita + "' + '%'";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from EstadoCita where ELIMINADO = 0";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from EstadoCita where ELIMINADO = 0";
            }

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATEstadoCita[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATEstadoCita();
                    ARR[i].idEstadoCita = (int)DB.REG1["idEstadoCita"];
                    ARR[i].NombreEstadoCita = (string)DB.REG1["NombreEstadoCita"];
                    ARR[i].Descripcion = (string)DB.REG1["Descripcion"];
                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    i++;
                }
                return true;
            }
            catch
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

        #region DATA ACCES OBJECT
        public bool DAO(ref strTATEstadoCita str , int Instruccion)
        {
            DB.conexionBD();

            DB.COM1.CommandText = "spEstadoCita";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idEstadoCita", str.idEstadoCita);
                DB.COM1.Parameters.AddWithValue("NombreEstadoCita", str.NombreEstadoCita);
                DB.COM1.Parameters.AddWithValue("Descripcion", str.Descripcion);
                DB.COM1.Parameters.AddWithValue("USUARIO", str.USUARIO);
                

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idEstadoCita = (int)DB.REG1["idEstadoCita"];
                    str.NombreEstadoCita = (string)DB.REG1["NombreEstadoCita"];
                    str.Descripcion = (string)DB.REG1["Descripcion"];
                    str.USUARIO = (string)DB.REG1["USUARIO"];
                    str.FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    str.ELIMINADO = (bool)DB.REG1["ELIMINADO"];

                }
                return true;
            }
            catch
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
            if (DB.objConexion != null)
            {
                if (DB.REG1 != null)
                {
                    if (!DB.REG1.IsClosed)
                    {
                        DB.REG1.Close();
                    }
                }
                if (DB.objConexion.State == ConnectionState.Open)
                {
                    DB.objConexion.Close();
                }
            }
        }
        #endregion
    }
}

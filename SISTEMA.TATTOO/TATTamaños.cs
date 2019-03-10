using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISTEMA.TATTOO;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATTamaños
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATTamaños
        {
            public int idTamaño;
            public string Tamaño;
            public string Detalle;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
        }
        #endregion

        #region LISTARES

        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATTamaños[] ARR)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            DB.COM1.CommandText = "Select count (*) from Tamaños where ELIMINADO = 0";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from Tamaños where ELIMINADO = 0";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATTamaños[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATTamaños();
                    ARR[i].idTamaño = (int)DB.REG1["idTamaño"];
                    ARR[i].Tamaño = (string)DB.REG1["Tamaño"];
                    ARR[i].Detalle = (string)DB.REG1["Detalle"];
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
        #endregion

        #region LISTAR CON FILTRO
        public bool Listar(ref strTATTamaños[] ARR, strTATTamaños filtro)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            if(filtro.Tamaño != "")
            {
                DB.COM1.CommandText = "Select count (*) from Tamaños where ELIMINADO = 0 and Tamaño like '%' + '" + filtro.Tamaño + "' + '%'";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from Tamaños where ELIMINADO = 0 and Tamaño like '%' + '" + filtro.Tamaño + "' + '%'";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from Tamaños where ELIMINADO = 0";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from Tamaños where ELIMINADO = 0";
            }

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATTamaños[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATTamaños();
                    ARR[i].idTamaño = (int)DB.REG1["idTamaño"];
                    ARR[i].Tamaño = (string)DB.REG1["Tamaño"];
                    ARR[i].Detalle = (string)DB.REG1["Detalle"];
                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
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

        #region DATA ACCESS OBJECT
        public bool DAO(ref strTATTamaños str, int Instruccion)
        {
            DB.conexionBD();

            DB.COM1.CommandText = "spTamaños";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idTamaño", str.idTamaño);
                DB.COM1.Parameters.AddWithValue("Tamaño", str.Tamaño);
                DB.COM1.Parameters.AddWithValue("Detalle", str.Detalle);
                DB.COM1.Parameters.AddWithValue("USUARIO", str.USUARIO);
                DB.COM1.Parameters.AddWithValue("FECHAHORACAMBIO", DateTime.Now);
                DB.COM1.Parameters.AddWithValue("ELIMINADO", str.ELIMINADO);

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idTamaño = (int)DB.REG1["idTamaño"];
                    str.Tamaño = (string)DB.REG1["Tamaño"];
                    str.Detalle = (string)DB.REG1["Detalle"];
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATEmpleados
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATEmpleados
        {
            public int idEmpleado;
            public int idTipoEmpleado;
            public string nombreEmpleado;
            public string Direccion;
            public string Telefono;
            public string numSeguro;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
            public string nombreTipoEmpleado;
        }
        #endregion

        #region LISTARES

        #region LISTAR SIN FILTRO

        public bool Listar(ref strTATEmpleados[] ARR)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            DB.COM1.CommandText = "Select count (*) from visEmpleados where ELIMINADO = 0 AND idEmpleado not in (1)";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from visEmpleados where ELIMINADO = 0 AND idEmpleado not in (1)";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATEmpleados[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATEmpleados();
                    ARR[i].idEmpleado = (int)DB.REG1["idEmpleado"];
                    ARR[i].idTipoEmpleado = (int)DB.REG1["idTipoEmpleado"];
                    ARR[i].nombreEmpleado = DB.REG1["nombreEmpleado"].ToString();
                    ARR[i].Direccion = DB.REG1["Direccion"].ToString();
                    ARR[i].Telefono = DB.REG1["Telefono"].ToString();
                    ARR[i].numSeguro = DB.REG1["numSeguro"].ToString();
                    ARR[i].USUARIO = DB.REG1["USUARIO"].ToString();
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreTipoEmpleado = DB.REG1["nombreTipoEmpleado"].ToString();
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

        public bool Listar(ref strTATEmpleados[] ARR, string filtro)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            if(filtro != null)
            {
                DB.COM1.CommandText = "Select count (*) from (SELECT * FROM visEmpleados where ELIMINADO = 0 AND idEmpleado not in (1)) AS A WHERE A.nombreEmpleado like '%' + '" + filtro + "' + '%' OR A.nombreTipoEmpleado like '%' + '" + filtro + "' + '%'";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from (SELECT * FROM visEmpleados where ELIMINADO = 0 AND idEmpleado not in (1)) AS A WHERE  A.nombreEmpleado like '%' + '" + filtro + "' + '%' OR A.nombreTipoEmpleado like '%' + '" + filtro + "' + '%'";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from visEmpleados where ELIMINADO = 0 AND idEmpleado not in (1)";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from visEmpleados where ELIMINADO = 0 AND idEmpleado not in (1)";
            }
            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATEmpleados[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATEmpleados();
                    ARR[i].idEmpleado = (int)DB.REG1["idEmpleado"];
                    ARR[i].idTipoEmpleado = (int)DB.REG1["idTipoEmpleado"];
                    ARR[i].nombreEmpleado = DB.REG1["nombreEmpleado"].ToString();
                    ARR[i].Direccion = DB.REG1["Direccion"].ToString();
                    ARR[i].Telefono = DB.REG1["Telefono"].ToString();
                    ARR[i].numSeguro = DB.REG1["numSeguro"].ToString();
                    ARR[i].USUARIO = DB.REG1["USUARIO"].ToString();
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreTipoEmpleado = DB.REG1["nombreTipoEmpleado"].ToString();
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
        public bool DAO(ref strTATEmpleados str, int Instruccion)
        {
            DB.conexionBD();
            DB.COM1.CommandText = "spEmpleados";
            DB.COM1.CommandType = CommandType.StoredProcedure;
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();

            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idEmpleado", str.idEmpleado);
                DB.COM1.Parameters.AddWithValue("idTipoEmpleado", str.idTipoEmpleado);
                DB.COM1.Parameters.AddWithValue("nombreEmpleado", str.nombreEmpleado);
                DB.COM1.Parameters.AddWithValue("Direccion", str.Direccion);
                DB.COM1.Parameters.AddWithValue("Telefono", str.Telefono);
                DB.COM1.Parameters.AddWithValue("numSeguro", str.numSeguro);
                DB.COM1.Parameters.AddWithValue("USUARIO", str.USUARIO);
                DB.COM1.Parameters.AddWithValue("FECHAHORACAMBIO", DateTime.Now);
                DB.COM1.Parameters.AddWithValue("ELIMINADO", str.ELIMINADO);

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idEmpleado = Convert.ToInt32(DB.REG1["idEmpleado"]);
                    str.idTipoEmpleado = Convert.ToInt32(DB.REG1["idTipoEmpleado"]);
                    str.nombreEmpleado = (DB.REG1["nombreEmpleado"].ToString());
                    str.Direccion = DB.REG1["Direccion"].ToString();
                    str.Telefono = DB.REG1["Telefono"].ToString();
                    str.numSeguro = DB.REG1["numSeguro"].ToString();
                    str.USUARIO = DB.REG1["USUARIO"].ToString();
                    str.FECHAHORACAMBIO = Convert.ToDateTime(DB.REG1["FECHAHORACAMBIO"]);
                    str.ELIMINADO = Convert.ToBoolean(DB.REG1["ELIMINADO"]);
                    str.nombreTipoEmpleado = Convert.ToString(DB.REG1["nombreTipoEmpleado"]);
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
            if(DB.objConexion != null)
            {
                if(DB.REG1 != null)
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

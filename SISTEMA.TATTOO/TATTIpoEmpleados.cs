using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATTIpoEmpleados
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATTipoEmpleados
        {
            public int idTipoEmpleado;
            public int idTipoPermiso;
            public string nombreTipoEmpleado;
            public string Descripcion;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
            public string nombreTipoPermiso;
        }
        #endregion

        #region LISTARES
        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATTipoEmpleados[] ARR)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int cuantos = 0;
            DB.COM1.CommandText = "Select count (*) from visTiposEmpleados where ELIMINADO = 0 AND idTipoEmpleado not in (2)";

            cuantos = (int)DB.COM1.ExecuteScalar();

            DB.COM1.CommandText = "Select * from visTiposEmpleados where ELIMINADO = 0 AND idTipoEmpleado not in (2)";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATTipoEmpleados[cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATTipoEmpleados();
                    ARR[i].idTipoEmpleado = (int)DB.REG1["idTipoEmpleado"];
                    ARR[i].idTipoPermiso = (int)DB.REG1["idTipoPermiso"];
                    ARR[i].nombreTipoEmpleado = DB.REG1["nombreTipoEmpleado"].ToString();
                    ARR[i].Descripcion = DB.REG1["Descripcion"].ToString();
                    ARR[i].USUARIO = DB.REG1["USUARIO"].ToString();
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreTipoPermiso = DB.REG1["nombreTipoPermiso"].ToString();
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
        public bool Listar(ref strTATTipoEmpleados[] ARR, string filtro)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int cuantos = 0;
            if (filtro != "")
            {
                DB.COM1.CommandText = "Select count (*) from (SELECT * FROM visTiposEmpleados where ELIMINADO = 0 AND idTipoEmpleado not in (2)) AS A WHERE A.nombreTipoEmpleado like '%' + '" + filtro + "' + '%'" +
                "OR A.nombreTipoPermiso like '%' + '" + filtro + "' + '%'";
                cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from (SELECT * FROM visTiposEmpleados where ELIMINADO = 0 AND idTipoEmpleado not in (2)) AS A WHERE A.nombreTipoEmpleado like '%' + '" + filtro + "' + '%'" +
                "OR A.nombreTipoPermiso like '%' + '" + filtro + "' + '%'";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from visTiposEmpleados where ELIMINADO = 0 AND idTipoEmpleado not in (2)";
                cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from visTiposEmpleados where ELIMINADO = 0 AND idTipoEmpleado not in (2)";
            }
            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATTipoEmpleados[cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATTipoEmpleados();
                    ARR[i].idTipoEmpleado = (int)DB.REG1["idTipoEmpleado"];
                    ARR[i].idTipoPermiso = (int)DB.REG1["idTipoPermiso"];
                    ARR[i].nombreTipoEmpleado = DB.REG1["nombreTipoEmpleado"].ToString();
                    ARR[i].Descripcion = DB.REG1["Descripcion"].ToString();
                    ARR[i].USUARIO = DB.REG1["USUARIO"].ToString();
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreTipoPermiso = DB.REG1["nombreTipoPermiso"].ToString();
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
        public bool DAO(ref strTATTipoEmpleados str, int Instruccion)
        {
            DB.conexionBD();


            DB.COM1.CommandText = "spTiposEmpleados ";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idTipoEmpleado", str.idTipoEmpleado);
                DB.COM1.Parameters.AddWithValue("idTipoPermiso", str.idTipoPermiso);
                DB.COM1.Parameters.AddWithValue("nombreTipoEmpleado", str.nombreTipoEmpleado);
                DB.COM1.Parameters.AddWithValue("Descripcion", str.Descripcion);
                DB.COM1.Parameters.AddWithValue("USUARIO", str.USUARIO);
                DB.COM1.Parameters.AddWithValue("FECHAHORACAMBIO", DateTime.Now);
                DB.COM1.Parameters.AddWithValue("ELIMINADO", str.ELIMINADO);

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idTipoEmpleado = Convert.ToInt32(DB.REG1["idTipoEmpleado"]);
                    str.idTipoPermiso = Convert.ToInt32(DB.REG1["idTipoPermiso"]);
                    str.nombreTipoEmpleado = Convert.ToString(DB.REG1["nombreTipoEmpleado"]);
                    str.Descripcion = DB.REG1["Descripcion"].ToString();
                    str.USUARIO = DB.REG1["USUARIO"].ToString();
                    str.FECHAHORACAMBIO = Convert.ToDateTime(DB.REG1["FECHAHORACAMBIO"]);
                    str.ELIMINADO = Convert.ToBoolean(DB.REG1["ELIMINADO"]);
                    str.nombreTipoPermiso = Convert.ToString(DB.REG1["nombreTipoPermiso"]);
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

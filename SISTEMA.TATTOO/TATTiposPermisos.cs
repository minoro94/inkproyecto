using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATTiposPermisos
    {
        #region OBEJTOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATTiposPermisos
        {
            public int idTipoPermiso;
            public string nombreTipoPermiso;
            public string Descripcion;
            public bool activo;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
        }
        #endregion

        #region LISTARES
        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATTiposPermisos[] ARR)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;

            DB.COM1.CommandText = "Select count (*) from TiposPermisos where ELIMINADO = 0 AND idTipoPermiso NOT IN (9)";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from TiposPermisos where ELIMINADO = 0 AND idTipoPermiso NOT IN(9)";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATTiposPermisos[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATTiposPermisos();
                    ARR[i].idTipoPermiso = (int)DB.REG1["idTipoPermiso"];
                    ARR[i].nombreTipoPermiso = DB.REG1["nombreTipoPermiso"].ToString();
                    ARR[i].Descripcion = DB.REG1["Descripcion"].ToString();
                    ARR[i].activo = (bool)DB.REG1["activo"];
                    ARR[i].USUARIO = DB.REG1["USUARIO"].ToString();
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    i++;
                }
                DB.objConexion.Close();
                if (DB.REG1 != null)
                    DB.REG1.Close();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion

        #region LISTAR CON FILTRO
        public bool Listar(ref strTATTiposPermisos[] ARR, strTATTiposPermisos filtro)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int cuantos = 0;
            if (filtro.nombreTipoPermiso != null)
            {
                DB.COM1.CommandText = "Select count (*) from TiposPermisos where ELIMINADO = 0 AND nombreTipoPermiso like '%' + '" + filtro.nombreTipoPermiso + "' + '%' AND idTipoPermiso NOT IN(9)";
                cuantos = (int)DB.COM1.ExecuteScalar();

                DB.COM1.CommandText = "Select * from TiposPermisos where ELIMINADO = 0 AND nombreTipoPermiso like '%' + '" + filtro.nombreTipoPermiso + "' + '%' AND idTipoPermiso NOT IN(9)";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from TiposPermisos where ELIMINADO = 0  AND idTipoPermiso NOT IN(9)";
                cuantos = (int)DB.COM1.ExecuteScalar();

                DB.COM1.CommandText = "Select * from TiposPermisos where ELIMINADO = 0  AND idTipoPermiso NOT IN(9)";
            }
            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATTiposPermisos[cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATTiposPermisos();
                    ARR[i].idTipoPermiso = (int)DB.REG1["idTipoPermiso"];
                    ARR[i].nombreTipoPermiso = DB.REG1["nombreTipoPermiso"].ToString();
                    ARR[i].Descripcion = DB.REG1["Descripcion"].ToString();
                    ARR[i].activo = (bool)DB.REG1["activo"];
                    ARR[i].USUARIO = DB.REG1["USUARIO"].ToString();
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
        public bool DAO(ref strTATTiposPermisos str, int Instruccion)
        {
            DB.conexionBD();


            DB.COM1.CommandText = "spTiposPermisos ";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idTipoPermiso", str.idTipoPermiso);
                DB.COM1.Parameters.AddWithValue("nombreTipoPermiso", str.nombreTipoPermiso);
                DB.COM1.Parameters.AddWithValue("Descripcion", str.Descripcion);
                DB.COM1.Parameters.AddWithValue("activo", str.activo);
                DB.COM1.Parameters.AddWithValue("USUARIO", str.USUARIO);
                DB.COM1.Parameters.AddWithValue("FECHAHORACAMBIO", DateTime.Now);
                DB.COM1.Parameters.AddWithValue("ELIMINADO", str.ELIMINADO);

                DB.REG1 = DB.COM1.ExecuteReader();


                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idTipoPermiso = Convert.ToInt32(DB.REG1["idTipoPermiso"]);
                    str.nombreTipoPermiso = Convert.ToString(DB.REG1["nombreTipoPermiso"]);
                    str.Descripcion = DB.REG1["Descripcion"].ToString();
                    str.activo = Convert.ToBoolean(DB.REG1["activo"]);
                    str.USUARIO = DB.REG1["USUARIO"].ToString();
                    str.FECHAHORACAMBIO = Convert.ToDateTime(DB.REG1["FECHAHORACAMBIO"]);
                    str.ELIMINADO = Convert.ToBoolean(DB.REG1["ELIMINADO"]);

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

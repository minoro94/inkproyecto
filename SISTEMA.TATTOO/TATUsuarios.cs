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
    public class TATUsuarios
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATUsuarios
        {
            public int idUsuario;
            public int idEmpleado;
            public string nombreUsuario;
            public string Contraseña;
            public bool ELIMINADO;
            public string nombreEmpleado;
        }
        #endregion

        #region LISTARES

        #region LISTAR SIN FILTRO

        public bool Listar(ref strTATUsuarios[] ARR)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            DB.COM1.CommandText = "Select count (*) from visUsuarios where ELIMINADO = 0 AND idUsuario not in (1)";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from visTATUsuarios where ELIMINADO = 0 AND idUsuario not in (1)";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATUsuarios[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATUsuarios();
                    ARR[i].idUsuario = (int)DB.REG1["idUsuario"];
                    ARR[i].idEmpleado = (int)DB.REG1["idEmpleado"];
                    ARR[i].nombreUsuario = DB.REG1["nombreUsuario"].ToString();
                    ARR[i].Contraseña = DB.REG1["Contraseña"].ToString();
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreEmpleado = DB.REG1["nombreEmpleado"].ToString();
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

        public bool Listar(ref strTATUsuarios[] ARR, string filtro)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            if(filtro != "")
            {
                DB.COM1.CommandText = "Select COUNT(*) from (SELECT * FROM visUsuarios where ELIMINADO = 0 AND idUsuario not in (1)) AS A WHERE A.nombreUsuario like '%' + '" + filtro +
                    "' + '%'OR A.nombreEmpleado like '%' + '" + filtro + "' + '%'";

                Cuantos = (int)DB.COM1.ExecuteScalar();

                DB.COM1.CommandText = "Select * from (SELECT * FROM visUsuarios where ELIMINADO = 0 AND idUsuario not in (1)) AS A WHERE A.nombreUsuario like '%' + '" + filtro +
                    "' + '%'OR A.nombreEmpleado like '%' + '" + filtro + "' + '%'";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from visUsuarios where ELIMINADO = 0 AND idUsuario not in (1)";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from visUsuarios where ELIMINADO = 0 AND idUsuario not in (1)";
            }

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATUsuarios[Cuantos];
                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATUsuarios();
                    ARR[i].idUsuario = (int)DB.REG1["idUsuario"];
                    ARR[i].idEmpleado = (int)DB.REG1["idEmpleado"];
                    ARR[i].nombreUsuario = DB.REG1["nombreUsuario"].ToString();
                    ARR[i].Contraseña = DB.REG1["Contraseña"].ToString();
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreEmpleado = DB.REG1["nombreEmpleado"].ToString();
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

        #region DATA ACCESS OBJECT USUARIOS
        
        public bool DAO(ref strTATUsuarios str, int Instruccion)
        {
            DB.conexionBD();
            DB.COM1.CommandText = "spUsuarios";
            DB.COM1.CommandType = CommandType.StoredProcedure;
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();

            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idUsuario", str.idUsuario);
                DB.COM1.Parameters.AddWithValue("idEmpleado", str.idEmpleado);
                DB.COM1.Parameters.AddWithValue("nombreUsuario", str.nombreUsuario);
                DB.COM1.Parameters.AddWithValue("Contraseña", str.Contraseña);
                DB.COM1.Parameters.AddWithValue("ELIMINADO", str.ELIMINADO);

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idUsuario = (int)DB.REG1["idUsuario"];
                    str.idEmpleado = (int)DB.REG1["idEmpleado"];
                    str.nombreUsuario = (string)DB.REG1["nombreUsuario"];
                    str.Contraseña = (string)DB.REG1["Contraseña"];
                    str.ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    str.nombreEmpleado = (string)DB.REG1["nombreEmpleado"];
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

        #region DATA ACCESS OBJECT USUARIOS Y PERMISOS INSERTAR, MODIFICAR Y ELIMINAR

        public bool DAO(ref strTATUsuarios str, DataTable TablaPermisos, int Instruccion)
        {
            bool res = false;
            DB.conexionBD();
            SqlTransaction trans;

            try
            {
                #region INSERTAR Y MODIFICAR
                if(Instruccion == 1 || Instruccion == 2)
                {
                    DB.COM1.CommandText = "spPermisosTablasDET";
                    DB.COM1.CommandType = CommandType.StoredProcedure;

                    DB.COM1.Connection = DB.objConexion;
                    DB.objConexion.Open();
                    trans = DB.objConexion.BeginTransaction();
                    DB.COM1.Transaction = trans;

                    DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                    DB.COM1.Parameters.AddWithValue("idUsuario", str.idUsuario);
                    DB.COM1.Parameters.AddWithValue("idEmpleado", str.idEmpleado);
                    DB.COM1.Parameters.AddWithValue("NombreUsuario", str.nombreUsuario);
                    DB.COM1.Parameters.AddWithValue("Contraseña", str.Contraseña);
                    DB.COM1.Parameters.AddWithValue("tabla", TablaPermisos);
                    DB.COM1.Parameters.AddWithValue("ELIMINADO", str.ELIMINADO);

                    try
                    {
                        DB.COM1.ExecuteNonQuery();
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        res = false;
                    }

                    res = true;
                }
                #endregion

                #region ELIMINAR

                if(Instruccion == 3)
                {
                    DB.COM1.CommandText = "spPermisosTablasDET";
                    DB.COM1.CommandType = CommandType.StoredProcedure;

                    DB.COM1.Connection = DB.objConexion;
                    DB.objConexion.Open();
                    trans = DB.objConexion.BeginTransaction();
                    DB.COM1.Transaction = trans;

                    DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                    DB.COM1.Parameters.AddWithValue("idUsuario", str.idUsuario);
                    try
                    {
                        DB.COM1.ExecuteNonQuery();
                        trans.Commit();
                        res = true;
                    }
                    catch
                    {
                        trans.Rollback();
                        res = false;
                    }
                }
                #endregion
            }
            catch
            {
                return res;
            }
            finally
            {
                DB.objConexion.Close();
                DB.COM1.Parameters.Clear();
                DB.COM1.CommandType = CommandType.Text;
            }

            return res;
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

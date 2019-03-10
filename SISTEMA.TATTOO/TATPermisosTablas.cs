using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATPermisosTablas
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATPermisosTablas
        {
            public int idPermiso;
            public int idUsuario;
            public string NombreTabla;
            public bool Permiso;
            public bool ELIMINADO;
            public DateTime FECHAHORACAMBIO;
            public string nombreUsuario;
        }
        #endregion

        #region LISTAR CON FILTRO
        public bool Listar(ref strTATPermisosTablas[] ARR, strTATPermisosTablas filtro)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            
            if (filtro.idUsuario != 0)
            {
                DB.COM1.CommandText = "Select count (*) from visPermisosTablas where ELIMINADO = 0 AND idUsuario = " + filtro.idUsuario;
                if(filtro.NombreTabla != null)
                {
                    DB.COM1.CommandText += " AND NombreTabla like '%' + '" + filtro.NombreTabla + "' + '%'";
                }

                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from visPermisosTablas where ELIMINADO = 0 AND idUsuario = " + filtro.idUsuario;

                if (filtro.NombreTabla != null)
                {
                    DB.COM1.CommandText += " AND NombreTabla like '%' + ' " + filtro.NombreTabla + "' + '%'";
                }

            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from visPermisosTablas where ELIMINADO = 0 ";
                if(filtro.NombreTabla != null)
                {
                    DB.COM1.CommandText += " AND NombreTabla like '%' + ' " + filtro.NombreTabla + "' + '%'";
                }

                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from visPermisosTablas where ELIMINADO = 0";
                if(filtro.NombreTabla != null)
                {
                    DB.COM1.CommandText += " AND NombreTabla like '%' + ' " + filtro.NombreTabla + "' + '%'";
                }
            }
            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATPermisosTablas[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATPermisosTablas();
                    ARR[i].idPermiso = (int)DB.REG1["idPermiso"];
                    ARR[i].idUsuario = (int)DB.REG1["idUsuario"];
                    ARR[i].NombreTabla = DB.REG1["NombreTabla"].ToString();
                    ARR[i].Permiso = (bool)DB.REG1["Permiso"];
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreUsuario = DB.REG1["nombreUsuario"].ToString();

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

        #region DATA ACCES OBJECT
        public bool DAO(ref strTATPermisosTablas[] ARR, int Instruccion)
        {
            DB.conexionBD();
            SqlTransaction trans;


            DB.COM1.CommandText = "spPermisosTablas ";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            trans = DB.objConexion.BeginTransaction();
            DB.COM1.Transaction = trans;
            try
            {

                for (int i = 0; i < ARR.Length; i++)
                {

                    DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                    DB.COM1.Parameters.AddWithValue("idPermiso", ARR[i].idPermiso);
                    DB.COM1.Parameters.AddWithValue("idUsuario", ARR[i].idUsuario);
                    DB.COM1.Parameters.AddWithValue("NombreTabla", ARR[i].NombreTabla);
                    DB.COM1.Parameters.AddWithValue("Permiso", ARR[i].Permiso);
                    DB.COM1.Parameters.AddWithValue("FECHAHORACAMBIO", DateTime.Now);
                    DB.COM1.Parameters.AddWithValue("ELIMINADO", ARR[i].ELIMINADO);

                    DB.COM1.ExecuteNonQuery();
                    DB.COM1.Parameters.Clear();
                }
                trans.Commit();
                return true;
            }
            catch
            {
                try
                {
                    trans.Rollback();
                }
                catch
                {

                }
                return false;
            }
            finally
            {

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

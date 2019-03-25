using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATInventario
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATInventario
        {
            public int idInventario;
            public string NombreProducto;
            public int Cantidad;
            public string Nota;
            
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
            public int idUsuario;
            
        }
        #endregion

        #region LISTARES

        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATInventario[] ARR)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            DB.COM1.CommandText = "Select count (*) from Inventario where ELIMINADO = 0 ";

            Cuantos = (int)DB.COM1.ExecuteScalar();

            DB.COM1.CommandText = "Select * from Inventario where ELIMINADO = 0";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATInventario[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATInventario();
                    ARR[i].idInventario = (int)DB.REG1["idInventario"];
                    
                    ARR[i].idUsuario = (int)DB.REG1["idUsuario"];
                    ARR[i].Cantidad = (int)DB.REG1["Cantidad"];
                    ARR[i].Nota = DB.REG1["Nota"].ToString();
                    ARR[i].USUARIO = DB.REG1["USUARIO"].ToString();
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
                DB.REG1.Close();
                DB.objConexion.Close();
                return false;
            }
        }
        #endregion

        #region LISTAR CON FILTRO
        public bool Listar(ref strTATInventario[] ARR, strTATInventario filtro)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            if(filtro.NombreProducto != "")
            {
                DB.COM1.CommandText = "Select count (*) from Inventario where ELIMINADO = 0 and NombreProducto like '%' + '" + filtro.NombreProducto + "' + '%'";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from Inventario where ELIMINADO = 0 and NombreProducto like '%' + '" + filtro.NombreProducto + "' + '%'";
            }
            else
            {
                DB.COM1.CommandText = "Select count (*) from Inventario where ELIMINADO = 0";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from Inventario where ELIMINADO = 0";
            }
            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATInventario[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATInventario();
                    ARR[i].idInventario = (int)DB.REG1["idInventario"];
                    ARR[i].idUsuario = (int)DB.REG1["idUsuario"];
                    ARR[i].Cantidad = (int)DB.REG1["Cantidad"];
                    ARR[i].Nota = DB.REG1["Nota"].ToString();
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
                DB.REG1.Close();
            }
        }
        #endregion

        #endregion

        #region DATA ACCESS OBJECT
        public bool DAO(ref strTATInventario str, int Instruccion)
        {
            DB.conexionBD();

            DB.COM1.CommandText = "spTATInventario ";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();

            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idInventario", str.idInventario);
                DB.COM1.Parameters.AddWithValue("idUsuario", str.idUsuario);
                DB.COM1.Parameters.AddWithValue("Cantidad", str.Cantidad);
                DB.COM1.Parameters.AddWithValue("Nota", str.Nota);
                DB.COM1.Parameters.AddWithValue("USUARIO", str.USUARIO);
                

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idInventario = Convert.ToInt32(DB.REG1["idInventario"]);
                    str.idUsuario = Convert.ToInt32(DB.REG1["idUsuario"]);
                    str.Cantidad = Convert.ToInt32(DB.REG1["cantidadStock"]);
                    str.Nota = Convert.ToString(DB.REG1["Nota"]);
                    str.USUARIO = DB.REG1["USUARIO"].ToString();
                    str.FECHAHORACAMBIO = Convert.ToDateTime(DB.REG1["FECHAHORACAMBIO"]);
                    str.ELIMINADO = Convert.ToBoolean(DB.REG1["ELIMINADO"]);
                    
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

        #region DIPOSE
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

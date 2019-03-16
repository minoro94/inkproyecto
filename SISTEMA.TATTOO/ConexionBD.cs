using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace SISTEMA.TATTOO
{
    public class ConexionBD
    {
        #region OBJETOS
        public SqlConnection objConexion;
        public SqlDataReader REG1;
        public SqlCommand COM1 = new SqlCommand();
        #endregion

        #region CADENA DE CONEXION
        public static string getString()
        {
            string con = string.Empty;
            try
            {
                return File.ReadAllText($"{Environment.CurrentDirectory.Substring(0, 2)}\\SISTEMCONFIG\\DATABASE.CNF");
            }
            catch
            {

            }
            return con;
        }

        public void conexionBD()
        {
            //Cadena de conexion con seguridad SQL
            string cadenaConexion = "Server=192.168.1.107;Database=Tattoo;User Id=sa;Password=123456;";

            //Cadena de conexion con Seguridad Integrada de Windows
            //Personalizar la cadena de conxion de acuerdo a su Base de datos
            //  Cambia esto 
            try
            {
                string cadenaConexionTrust = File.ReadAllText($"{Environment.CurrentDirectory.Substring(0, 2)}\\SISTEMCONFIG\\DATABASE.CNF");
                objConexion = new SqlConnection(cadenaConexion);
            }
            catch (SqlException ex)
            {
                File.WriteAllText($"{Environment.CurrentDirectory[0].ToString():\\SISTEMCONFIG\\logs.txt}", ex.Message);
            }
        }
        #endregion

        #region DISPOSE
        public void Dispose()
        {
            if(REG1 != null)
            {
                if (!REG1.IsClosed)
                {
                    REG1.Close();
                }
            }

            if(objConexion.State == ConnectionState.Open)
            {
                objConexion.Close();
            }
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATCitasInventario
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATCitasInventario
        {
            public int idCitaInventario;
            public int idInventario;
            public int Cantidad;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
        }
        #endregion

        #region LISTARES
        public bool Listar(ref strTATCitasInventario[]ARR, int idCita)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            DB.COM1.CommandText = "Select count (*) from CitasInventario where ELIMINADO = 0 and idCita = " + idCita + "";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from CitasInventario where ELIMINADO = 0 and idCita = " + idCita + "";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATCitasInventario[Cuantos];
                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATCitasInventario();
                    ARR[i].idCitaInventario = (int)DB.REG1["idCitaInventario"];
                    ARR[i].idInventario = (int)DB.REG1["idInventario"];
                    ARR[i].Cantidad = (int)DB.REG1["Cantidad"];
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

        #region DISPOSE
        public void DIspose()
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATSesionesCitas
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        public struct strTATSesionesCitas
        {
            public int idSesionCita;
            public int idCita;
            public int NumeroSesion;
            public DateTime FechaCita;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
        }

        #region LISTARES
        public bool Listar(ref strTATSesionesCitas[]ARR, int idCita)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            DB.COM1.CommandText = "Select count (*) from SesionesCitas where ELIMINADO = 0 and idCita = " + idCita + "";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from SesionesCitas where ELIMINADO = 0 and idCita =" + idCita + "";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATSesionesCitas[Cuantos];
                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATSesionesCitas();
                    ARR[i].idSesionCita = (int)DB.REG1["idSesionCita"];
                    ARR[i].idCita = (int)DB.REG1["idCita"];
                    ARR[i].NumeroSesion = (int)DB.REG1["NumeroSesion"];
                    ARR[i].FechaCita = (DateTime)DB.REG1["FechaCita"];
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

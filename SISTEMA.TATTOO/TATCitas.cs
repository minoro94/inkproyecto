using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATCitas
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATCitas
        {
            public int idCita;
            public int idCliente;
            public int idEstadoCita;
            public int idTamaño;
            public DateTime FechaCita;
            public string Firma;
            public string ImagenTatto;
            public double Costo;
            public double Anticipo;
            public int ZonaCuerpo;
            public string Descripcion;
            public string USUARIO;
            public string FECHAHORACAMBIO;
            public bool ELIMINADO;

            public string nombreCliente;
            public string Tamaño;
            public string NombreEstadoCita;
        }
        #endregion

        #region LISTARES
        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATCitas[] ARR)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;

            DB.COM1.CommandText = "Select count (*) from visCitas where ELIMINADO = 0";
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from visCitas where ELIMINADO = 0";

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATCitas[Cuantos];

                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATCitas();
                    ARR[i].idCita = (int)DB.REG1["idCita"];
                    ARR[i].idCliente = (int)DB.REG1["idCliente"];
                    ARR[i].FechaCita = (DateTime)DB.REG1["FechaCita"];
                    ARR[i].idEstadoCita = (int)DB.REG1["idEstadoCita"];
                    ARR[i].Firma = (string)DB.REG1["Firma"];
                    ARR[i].ImagenTatto = (string)DB.REG1["ImagenTatto"];
                    ARR[i].idTamaño = (int)DB.REG1["idTamaño"];
                    ARR[i].Costo = (double)DB.REG1["Costo"];
                    ARR[i].Anticipo = (double)DB.REG1["Anticipo"];
                    ARR[i].ZonaCuerpo = (int)DB.REG1["ZonaCuerpo"];
                    ARR[i].Descripcion = (string)DB.REG1["Descripcion"];
                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].nombreCliente = (string)DB.REG1["nombreCliente"];
                    ARR[i].Tamaño = (string)DB.REG1["Tamaño"];
                    ARR[i].NombreEstadoCita = (string)DB.REG1["NombreEstadoCita"];
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
        public bool Listar(ref strTATCitas[] ARR, string Nombre, DateTime FechaI, DateTime FechaF)
        {
            
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            return true;
           


            
        }
        #endregion
        #endregion
    }
}

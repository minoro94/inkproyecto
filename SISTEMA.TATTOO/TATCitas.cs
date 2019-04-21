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
           // public string ImagenTatto;
            public double Costo;
            public double Anticipo;
            public string ZonaCuerpo;
            public string Descripcion;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;
            public bool ELIMINADO;
            public int NumeroSesion;
            public string nombreCliente;
            public string Tamaño;
            public string NombreEstadoCita;
            public string Telefono;
            public bool EstadoCorreo;
        }
        #endregion

        #region LISTARES
        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATCitas[] ARR,DateTime FechaInicio, DateTime FechaFin, strTATCitas str)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;

            DB.COM1.CommandText = "Select count(*) from dbo.visCitasPorFecha where FechaCita <  CAST(dateadd(day, 1 ,@FechaFin) AS DATE) and FechaCita> CAST(dateadd(day, -1 ,@FechaInicio) AS DATE) and ELIMINADO = 0 AND nombreCliente like '%' + '" + str.nombreCliente + "' + '%'";
            SqlParameter SQP1 = new SqlParameter("@FechaFin",FechaFin);
            SQP1.SqlDbType = SqlDbType.DateTime;
            SqlParameter SQP2 = new SqlParameter("@FechaInicio",FechaInicio);
            SQP2.SqlDbType = SqlDbType.DateTime;
            DB.COM1.Parameters.Add(SQP1);
            DB.COM1.Parameters.Add(SQP2);
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from dbo.visCitasPorFecha where FechaCita <  CAST(dateadd(day, 1 ,@FechaFin) AS DATE) and FechaCita> CAST(dateadd(day, -1 ,@FechaInicio) AS DATE) and ELIMINADO = 0  and nombreCliente like  '%' + '" + str.nombreCliente + "' + '%' ORDER BY FechaCita asc";

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
                    ARR[i].idTamaño = (int)DB.REG1["idTamaño"];
                    ARR[i].Costo = Convert.ToDouble(DB.REG1["Costo"]);
                    ARR[i].Anticipo = Convert.ToDouble(DB.REG1["Anticipo"]);
                    ARR[i].ZonaCuerpo = (string)DB.REG1["ZonaCuerpo"];
                    ARR[i].Descripcion = (string)DB.REG1["Descripcion"];
                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].NumeroSesion = (int)DB.REG1["NumeroSesion"];
                    ARR[i].nombreCliente = (string)DB.REG1["nombreCliente"];
                    ARR[i].Tamaño = (string)DB.REG1["Tamaño"];
                    ARR[i].NombreEstadoCita = (string)DB.REG1["NombreEstadoCita"];
                    ARR[i].Telefono = (string)DB.REG1["Telefono"];
                    ARR[i].EstadoCorreo = (bool)DB.REG1["EstadoCorreo"];
                    i++;
                }
                DB.REG1.Close();
                DB.objConexion.Close();
                DB.COM1.Parameters.Clear();
                return true;
            }
            catch(Exception e)
            {
                DB.objConexion.Close();
                DB.REG1.Close();
                DB.COM1.Parameters.Clear();
                return false;
            }
        }
        #endregion

        #region LISTAR SIN FILTRO
        public bool Listar(ref strTATCitas[] ARR, DateTime FechaInicio, strTATCitas str)
        {
            DB.conexionBD();

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;

            DB.COM1.CommandText = "Select count(*) from dbo.visCitasPorFecha where FechaCita <  dateadd(second, 60 ,@FechaInicio) and FechaCita> @FechaInicio and ELIMINADO = 0 AND nombreCliente like '%' + '" + str.nombreCliente + "' + '%'";
            SqlParameter SQP2 = new SqlParameter("@FechaInicio", FechaInicio);
            SQP2.SqlDbType = SqlDbType.DateTime;
            DB.COM1.Parameters.Add(SQP2);
            Cuantos = (int)DB.COM1.ExecuteScalar();
            DB.COM1.CommandText = "Select * from dbo.visCitasPorFecha  where FechaCita <  dateadd(second, 60 ,@FechaInicio) and FechaCita> @FechaInicio and ELIMINADO = 0  and nombreCliente like  '%' + '" + str.nombreCliente + "' + '%' ORDER BY FechaCita asc";

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
                    ARR[i].idTamaño = (int)DB.REG1["idTamaño"];
                    ARR[i].Costo = Convert.ToDouble(DB.REG1["Costo"]);
                    ARR[i].Anticipo = Convert.ToDouble(DB.REG1["Anticipo"]);
                    ARR[i].ZonaCuerpo = (string)DB.REG1["ZonaCuerpo"];
                    ARR[i].Descripcion = (string)DB.REG1["Descripcion"];
                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    ARR[i].NumeroSesion = (int)DB.REG1["NumeroSesion"];
                    ARR[i].nombreCliente = (string)DB.REG1["nombreCliente"];
                    ARR[i].Tamaño = (string)DB.REG1["Tamaño"];
                    ARR[i].NombreEstadoCita = (string)DB.REG1["NombreEstadoCita"];
                    ARR[i].Telefono = (string)DB.REG1["Telefono"];
                    ARR[i].EstadoCorreo = (bool)DB.REG1["EstadoCorreo"];
                    i++;
                }
                DB.REG1.Close();
                DB.objConexion.Close();
                DB.COM1.Parameters.Clear();
                return true;
            }
            catch (Exception e)
            {
                DB.objConexion.Close();
                DB.REG1.Close();
                DB.COM1.Parameters.Clear();
                return false;
            }
        }
        #endregion

        #endregion

        #region DAO
        public bool DAO(ref strTATCitas str, int Instruccion, DataTable dtInventario, DataTable dtFechaCitas, DataTable dtImgTatto)
        {
            DB.conexionBD();

            DB.COM1.CommandText = "spCitasDET";
            DB.COM1.CommandType = CommandType.StoredProcedure;

            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();

            try
            {
                DB.COM1.Parameters.AddWithValue("ACCION", Instruccion);
                DB.COM1.Parameters.AddWithValue("idCita",str.idCita);
                DB.COM1.Parameters.AddWithValue("idCliente",str.idCliente);
                DB.COM1.Parameters.AddWithValue("idEstadoCita",str.idEstadoCita);
                DB.COM1.Parameters.AddWithValue("idTamaño",str.idTamaño);
                DB.COM1.Parameters.AddWithValue("Firma",str.Firma);
                DB.COM1.Parameters.AddWithValue("Costo",str.Costo);
                DB.COM1.Parameters.AddWithValue("Anticipo",str.Anticipo);
                DB.COM1.Parameters.AddWithValue("ZonaCuerpo",str.ZonaCuerpo);
                DB.COM1.Parameters.AddWithValue("Descripcion",str.Descripcion);
                DB.COM1.Parameters.AddWithValue("EstadoCorreo", str.EstadoCorreo);
                DB.COM1.Parameters.AddWithValue("USUARIO",str.USUARIO);
                DB.COM1.Parameters.AddWithValue("FECHAHORACAMBIO",DateTime.Now);
                DB.COM1.Parameters.AddWithValue("ELIMINADO",str.ELIMINADO);
                DB.COM1.Parameters.AddWithValue("tblCitasInventario", dtInventario);
                DB.COM1.Parameters.AddWithValue("tblImagenesTattoo", dtImgTatto);
                DB.COM1.Parameters.AddWithValue("tblSesionesCitas", dtFechaCitas);

                DB.REG1 = DB.COM1.ExecuteReader();

                if (DB.REG1.HasRows)
                {
                    DB.REG1.Read();
                    str.idCita = (int)DB.REG1["idCita"];
                    str.idCliente = (int)DB.REG1["idCliente"];
                    str.idEstadoCita = (int)DB.REG1["idEstadoCita"];
                    str.idTamaño = (int)DB.REG1["idTamaño"];
                    str.Costo = Convert.ToDouble(DB.REG1["Costo"]);
                    str.Anticipo = Convert.ToDouble(DB.REG1["Anticipo"]);
                    str.ZonaCuerpo = (string)DB.REG1["ZonaCuerpo"];
                    str.Descripcion = (string)DB.REG1["Descripcion"];
                    str.USUARIO = (string)DB.REG1["USUARIO"];
                    str.FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    str.ELIMINADO = (bool)DB.REG1["ELIMINADO"];
                    str.nombreCliente = (string)DB.REG1["nombreCliente"];
                    str.Tamaño = (string)DB.REG1["Tamaño"];
                    str.NombreEstadoCita = (string)DB.REG1["NombreEstadoCita"];
                    str.Telefono = (string)DB.REG1["Telefono"];
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

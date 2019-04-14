using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA.TATTOO
{
    public class TATHistorialesMedicos
    {
        #region OBJETOS
        ConexionBD DB = new ConexionBD();
        #endregion

        #region ESTRUCTURA
        public struct strTATHistorialesMedicos
        {
            public int idHistorialMedico;
            public int idCliente;
            public bool Hipertension;
            public bool Diabetes;
            public bool Hemofilia;
            public bool Afecciones;
            public bool AfeccionesRen;
            public bool FiebreReum;
            public bool Hepatitis;
            public bool Sida;
            public bool Tuberculosis;
            public bool Cancer;
            public bool Lupus;
            public string Otros;
            public bool Embarazo;
            public int Meses;
            public string Alergias;
            public bool DificultadSangrado;
            public bool OtrasIntervenciones;
            public string ComplicacionesInterv;
            public bool ELIMINADO;
            public string USUARIO;
            public DateTime FECHAHORACAMBIO;

        }
        #endregion

        #region LISTARES
        public bool Listar(ref strTATHistorialesMedicos[] ARR, strTATHistorialesMedicos filtro)
        {
            DB.conexionBD();
            DB.COM1.Connection = DB.objConexion;
            DB.objConexion.Open();
            int Cuantos = 0;
            if(filtro.idCliente != 0)
            {
                DB.COM1.CommandText = "Select count (*) from HistorialesMedicos where ELIMINADO = 0 and idCliente = " + filtro.idCliente + " ";
                Cuantos = (int)DB.COM1.ExecuteScalar();
                DB.COM1.CommandText = "Select * from HistorialesMedicos where ELIMINADO = 0 and idCliente = " + filtro.idCliente + " "; 
            }

            try
            {
                DB.REG1 = DB.COM1.ExecuteReader();
                int i = 0;
                ARR = new strTATHistorialesMedicos[Cuantos];
                while (DB.REG1.Read())
                {
                    ARR[i] = new strTATHistorialesMedicos();
                    ARR[i].idHistorialMedico = (int)DB.REG1["idHistorialMedico"];
                    ARR[i].idCliente = (int)DB.REG1["idCliente"];
                    ARR[i].Hipertension = (bool)DB.REG1["Hipertension"];
                    ARR[i].Diabetes = (bool)DB.REG1["Diabetes"];
                    ARR[i].Hemofilia = (bool)DB.REG1["Hemofilia"];
                    ARR[i].Afecciones = (bool)DB.REG1["Afecciones"];
                    ARR[i].AfeccionesRen = (bool)DB.REG1["AfeccionesRen"];
                    ARR[i].FiebreReum = (bool)DB.REG1["FiebreReum"];
                    ARR[i].Hepatitis = (bool)DB.REG1["Hepatitis"];
                    ARR[i].Sida = (bool)DB.REG1["Sida"];
                    ARR[i].Tuberculosis = (bool)DB.REG1["Tuberculosis"];
                    ARR[i].Cancer = (bool)DB.REG1["Cancer"];
                    ARR[i].Lupus = (bool)DB.REG1["Lupus"];
                    ARR[i].Otros = (string)DB.REG1["Otros"];
                    ARR[i].Embarazo = (bool)DB.REG1["Embarazo"];
                    ARR[i].Meses = Convert.ToInt16(DB.REG1["Meses"]);
                    ARR[i].Alergias = (string)DB.REG1["Alergias"];
                    ARR[i].DificultadSangrado = (bool)DB.REG1["DificultadSangrado"];
                    ARR[i].OtrasIntervenciones = (bool)DB.REG1["OtrasInvervenciones"];
                    ARR[i].ComplicacionesInterv = (string)DB.REG1["ComplicacionesInterv"];
                    ARR[i].ELIMINADO = (bool)DB.REG1["ELIMINADOO"];
                    ARR[i].USUARIO = (string)DB.REG1["USUARIO"];
                    ARR[i].FECHAHORACAMBIO = (DateTime)DB.REG1["FECHAHORACAMBIO"];
                    i++;
                }
                DB.REG1.Close();
                DB.objConexion.Close();
                return true;
            }
            catch(Exception e)
            {
                DB.objConexion.Close();
                DB.REG1.Close();
                return false;
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

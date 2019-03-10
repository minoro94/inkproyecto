using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SISTEMA.TATTOO;

namespace SISTEMA.MAINMENU
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(Environment.CurrentDirectory.EndsWith("\\SISTEMA.MAINMENU\\bin\\Debug") || Environment.CurrentDirectory.EndsWith("\\SISTEMA.MAINMENU\\bin\\Release"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FORMA_PADRE());
            }
            else
            {
                if(args.Length > 0)
                {
                    try
                    {
                        string t = args[0].ToString();
                        string v = args[1].ToString();

                        switch (t)
                        {
                            case "register":
                                switch (v)
                                {
                                    case "127.0.0.1":
                                        try
                                        {
                                            using (SqlConnection con = new SqlConnection(ConexionBD.getString()))
                                            {
                                                using (SqlCommand cmdCount = new SqlCommand($"SELECT COUNT(*) FROM dbo.sys WHERE pc = '{Environment.MachineName}'", con))
                                                {
                                                    con.Open();
                                                    bool existe = Convert.ToBoolean(cmdCount.ExecuteScalar());
                                                    if (!existe)
                                                    {
                                                        using (SqlCommand cmd = new SqlCommand($"INSERT INTO DBO.sys VALUES('{Environment.MachineName}')", con))
                                                        {
                                                            cmd.ExecuteNonQuery();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex) { }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex) { }
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(ConexionBD.getString()))
                    {
                        using (SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM dbo.sys WHERE pc = '{Environment.MachineName}'", con))
                        {
                            con.Open();
                            bool existe = Convert.ToBoolean(cmd.ExecuteScalar());
                            if (existe)
                            {
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new FORMA_PADRE());
                            }
                        }
                    }
                }
            }
            
        }
    }
}

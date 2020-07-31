using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DentalCare_System.DB
{
    class DbConnection
    {
        public static MySqlConnection ObtenerConeccion()
        {
            /* MySqlConnection Conexion = new MySqlConnection("server=127.0.0.1;database=appcitas;Uid=root;pwd=;");
             Conexion.Open();
             return Conexion;*/

            string servidor = "localhost";
            string bd = "appcitas";
            string usuario = "root";
            string password = "";

            string cadenaConexion = "Database=" + bd + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + password + "";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }

        }

    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeyerSStore
{
    class Conexion
    {
        public static MySqlConnection conexion()
        {
            string servidor = "[SERVIDOR]";
            string bd = "[BASE DE DATOS]";
            string puerto = "[PUERTO]";
            string usuario = "[USUARIO]";
            string contrasena = "[CONTRASEÑA]";

            string cadenaConexion = $"server={servidor}; port={puerto}; user id={usuario}; password={contrasena}; database={bd};";

            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);
                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


    }
}

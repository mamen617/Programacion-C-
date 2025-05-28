using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleClubNautico
{
    public class Conexion
    {
        String cadena = "server=localhost;user=root;password=;database=ClubNautico";

        public MySqlConnection GetConexion()
        {
            MySqlConnection conn = new MySqlConnection(cadena);
            return conn;
        }
    }
}

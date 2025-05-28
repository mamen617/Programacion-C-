using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Eventos
{
    public class Conexion
    {
        //1. crear cadena de conexion
        String servidor = "localhost";
        String usuario = "root";
        String pass = "";
        String baseDatos = "Eventos";

        // ¡¡¡¡ Ojo para utilizar el MySqlConnection hay que instalar MySql.Data !!!!
        // Botón derecho:  Dependencias : Administrar Paquetes NuGet : MySql.Data
        // Luego en codigo pulsar control + . sobre MySqlConnection para que te ponga el 
        // using MySql.Data.MySqlClient;

        public MySqlConnection GetConnection()
        {
            //2. crear conexion 
            String cadena = "server=" + servidor + ";user=" + usuario + ";password=" + pass + ";database=" + baseDatos + "; ";
            MySqlConnection conn = new MySqlConnection(cadena);
            return conn;
        }
    }
}

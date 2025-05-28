using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleClientePedido
{



    public class Conexion
    {
        //1. crear cadena de conexion
        String servidor = "localhost";
        String usuario = "root";
        String pass = "";
        String baseDatos = "ejemplo";
        
       public MySqlConnection GetConnection()
        {
            //2. crear conexion 
            String cadena = "server=" + servidor + ";user=" + usuario + ";password=" + pass + ";database=" + baseDatos + "; ";
            MySqlConnection conn = new MySqlConnection(cadena);
            return conn;
        }
        
}
}

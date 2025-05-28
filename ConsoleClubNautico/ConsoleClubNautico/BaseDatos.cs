using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleClubNautico
{
    internal class BaseDatos
    {

        public string Misql { get; set; }
      
        public BaseDatos(string sql)  //Constructor
        {
            this.Misql = sql;
        }

        public void Ejecutar_Consulta_NonQuery()
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT, UPDATE, DELETE 
                    string consulta = Misql;
                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    int resultado = comando.ExecuteNonQuery(); // EJECUTO
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


        }
    }
}

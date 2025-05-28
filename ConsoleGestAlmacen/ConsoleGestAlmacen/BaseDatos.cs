using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleGestAlmacen.Modelo;
using MySql.Data.MySqlClient;

namespace ConsoleGestAlmacen
{
    internal class BaseDatos
    {
      
        public void CrearBaseDatos()
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea La consulta
                    string consulta = "" +
                    " DROP Table entradas ;" +
                    " DROP table salidas ; " +
                    " DROP table productos ; " +
                    " CREATE TABLE entradas " +
                    "(" +
                    " id int(4) NOT NULL" +
                    " , codigo varchar(8) NOT NULL" +
                    " , cantidad int(3) NOT NULL" +
                    " , fecha datetime NOT NULL DEFAULT current_timestamp()" +
                    ") " +
                    " ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci ;" +
                    " " +
                    " CREATE TABLE productos" +
                    " (" +
                    " id int(4) NOT NULL" +
                    ",codigo varchar(8) NOT NULL" +
                    ",nombre varchar(100) NOT NULL" +
                    ", tipo varchar(40) NOT NULL" +
                    ") " +
                    " ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;" +
                    " CREATE TABLE salidas " +
                    " (" +
                    " id int(4) NOT NULL" +
                    ", codigo varchar(8) NOT NULL " +
                    ", cantidad  int(3) NOT NULL " +
                    ", fecha datetime NOT NULL DEFAULT current_timestamp()" +
                    ") " +
                    " ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci; " +
                    " ALTER TABLE entradas  ADD PRIMARY KEY (id); " +
                    " ALTER TABLE productos ADD PRIMARY KEY (id); " +
                    " ALTER TABLE salidas  ADD PRIMARY KEY (id); " +
                    " ALTER TABLE entradas  MODIFY id int(4) NOT NULL AUTO_INCREMENT;" +
                    " ALTER TABLE productos MODIFY id int(4) NOT NULL AUTO_INCREMENT; " +
                    " ALTER TABLE salidas  MODIFY  id int(4) NOT NULL AUTO_INCREMENT;" +
                    " ";
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

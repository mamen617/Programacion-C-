using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClubNautico.Modelo;
using MySql.Data.MySqlClient;

namespace ConsoleClubNautico.Controller
{
    internal class DestinoController
    {
        public void Insertar(Destinos a)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = " INSERT INTO Destinos (ID_Destino, nombre) " +
                        " VALUES (Null, @nombre)";
                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //Añado los parametros para sustituirlos en la sql
                    comando.Parameters.AddWithValue("@nombre", a.nombre);
                    int resultado = comando.ExecuteNonQuery(); // EJECUTO
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void BorrarTabla()
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = "Delete from Destinos";
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
        public List<Destinos> Listar()
        {
            List<Destinos> listar = new List<Destinos>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    string consulta = " SELECT * from Destinos ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Destinos destino = new Destinos();
                        destino.id_Destino = (int)resultado["id_Destino"];
                        destino.nombre = (string)resultado["nombre"];
                        listar.Add(destino);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listar;
        }
    }
}

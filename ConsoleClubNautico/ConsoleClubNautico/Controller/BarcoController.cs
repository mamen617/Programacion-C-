using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleClubNautico.Modelo;
using MySql.Data.MySqlClient;

namespace ConsoleClubNautico.Controller
{
    internal class BarcoController
    {
        public void Insertar(Barcos a)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = " INSERT INTO barcos " +
                                    " (id_Barco, matricula, id_Socio, nombre, Id_Amarre) " +
                                    " VALUES " +
                                    " (Null, @matricula, @id_Socio, @nombre, @Id_Amarre)";

                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //Añado los parametros para sustituirlos en la sql
                    comando.Parameters.AddWithValue("@matricula", a.matricula);
                    comando.Parameters.AddWithValue("@id_Socio", a.Socio.id_Socio);
                    comando.Parameters.AddWithValue("@nombre", a.nombre);
                    comando.Parameters.AddWithValue("@Id_Amarre", a.Amarre.id_Amarre);
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
                    string consulta = "Delete from Barcos";
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
        public List<Barcos> Listar()
        {
            List<Barcos> listar = new List<Barcos>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    //string consulta = " SELECT b.id_Barco, b.matricula, b.id_Socio, b.nombre, b.Id_Amarre ,s.nombre as nombre_socio " +
                    //    ", s.dni , a.cuota " +
                    //    " FROM barcos b " +
                    //    " INNER JOIN Socios s ON (b.Id_Socio = s.Id_Socio ) " +
                    //    " INNER JOIN Amarres a  ON (b.Id_Amarre = a.Id_Amarre) ";
                    string consulta = " Select * from Barcos ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Barcos barco = new Barcos();
                        barco.id_Barco = (int)resultado["id_Barco"];
                        barco.matricula = (string)resultado["matricula"];
                        barco.nombre = (string)resultado["nombre"];
                        listar.Add(barco);
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


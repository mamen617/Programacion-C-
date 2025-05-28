using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsoleClubNautico.Modelo;
using MySql.Data.MySqlClient;

namespace ConsoleClubNautico.Controller
{
    internal class PatronControler
    {
        public void Insertar(Patrones a)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = " INSERT INTO Patrones " +
                                    " (id_Patron, dni, nombre, direccion, telefono) " +
                                    " VALUES " +
                                    " (Null, @dni, @nombre, @direccion, @telefono)";
                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //Añado los parametros para sustituirlos en la sql
                    comando.Parameters.AddWithValue("@dni", a.dni);
                    comando.Parameters.AddWithValue("@nombre", a.nombre);
                    comando.Parameters.AddWithValue("@direccion", a.direccion);
                    comando.Parameters.AddWithValue("@telefono", a.telefono);
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
                    string consulta = "Delete from Patrones";
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
        public List<Patrones> Listar()
        {
            List<Patrones> listar = new List<Patrones>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    string consulta = "SELECT * FROM Patrones ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Patrones patron = new Patrones();
                        patron.id_Patron = (int)resultado["Id_Patron"];
                        patron.nombre = (string)resultado["nombre"];
                        patron.dni = (string)resultado["dni"];
                        patron.telefono=  (string)resultado["telefono"];
                        listar.Add(patron);
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

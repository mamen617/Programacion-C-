using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsoleClubNautico.Modelo;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static Mysqlx.Crud.Order.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleClubNautico.Controller
{
    internal class SociosController
    {
        public void Insertar(Socios a)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = " INSERT INTO Socios " +
                                    " (id_Socio, dni, nombre, direccion, telefono) " +
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
                    string consulta = "Delete from Socios";
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
        public List<Socios> Listar()
        {
            List<Socios> listar = new List<Socios>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    //string consulta = " SELECT b.id_Barco, b.matricula, b.id_Socio, b.nombre, b.Id_Amarre ,s.nombre as nombre_socio " +
                    //    ", s.dni , a.cuota  " +
                    //    " FROM barcos b " +
                    //    " INNER JOIN Socios s ON (b.Id_Socio = s.Id_Socio ) INNER JOIN " +
                    //    " INNER JOIN Amarres a on ON(a.Id_Amarre = a.Id_Amarre) ";
                    string consulta = "select * from socios";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Socios socio = new Socios();
                        socio.id_Socio = (int)resultado["Id_Socio"];
                        socio.nombre = (string)resultado["nombre"];
                        socio.dni = (string)resultado["dni"];
                        listar.Add(socio);
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

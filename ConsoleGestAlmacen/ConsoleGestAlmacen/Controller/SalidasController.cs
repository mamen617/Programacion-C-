using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGestAlmacen.Modelo;
using MySql.Data.MySqlClient;

namespace ConsoleGestAlmacen.Controller
{
    internal class SalidasController
    {
        public List<Salidas> ListarSalidas()
        {
            List<Salidas> ListarSalidas = new List<Salidas>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    string consulta = " SELECT s.id as idSalida, s.codigo,s.cantidad, s.fecha" +
                        ", p.id as idProducto, p.nombre, p.tipo From Salidas s " +
                        " inner join productos p on (s.codigo = p.codigo ) order by s.codigo ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);

                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Salidas salida = new Salidas();
                        salida.Id = (int)resultado["idSalida"];
                        salida.MiProducto.Id = (int)resultado["idProducto"];
                        salida.MiProducto.Codigo = (string)resultado["codigo"];
                        salida.MiProducto.Nombre = (string)resultado["nombre"];
                        salida.MiProducto.Tipo = (string)resultado["tipo"];
                        salida.Cantidad = (int)resultado["cantidad"];
                        salida.Fecha = (DateTime)resultado["fecha"];
                        ListarSalidas.Add(salida);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }


            return ListarSalidas;
        }


        public void InsertarSalidas(Salidas e)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // Crea INSERT 
                    string consulta = "INSERT INTO Salidas (id, codigo, cantidad, fecha) " +
                        "VALUES (Null, @codigo,@cantidad,@fecha)";
                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //Añado los parametros para sustituirlos en la sql
                    comando.Parameters.AddWithValue("@codigo", e.MiProducto.Codigo);
                    comando.Parameters.AddWithValue("@cantidad", e.Cantidad);
                    comando.Parameters.AddWithValue("@fecha", e.Fecha);
                    int resultado = comando.ExecuteNonQuery(); // EJECUTO
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void InsertarSalidas(string codigo, int cantidad, DateTime fecha)
        {
            Salidas salida = new Salidas();
            salida.MiProducto.Codigo = codigo;
            salida.Cantidad = cantidad;
            salida.Fecha = fecha;
            InsertarSalidas(salida);
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
                    string consulta = "Delete from Salidas";
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
        public void BorrarTabla(int id)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open();
                    // consulta de borrado 
                    string consulta = "Delete from Salidas" +
                        " Where id = @id ";

                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@id", id);

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


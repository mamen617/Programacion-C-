using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleGestAlmacen.Modelo;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Cursor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleGestAlmacen.Controller
{
    internal class EntradasController
    {
        public List<Entradas> ListarEntradas()
        {
            List<Entradas> ListarEntradas = new List<Entradas>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();

                    string consulta = " SELECT e.id as idEntrada, e.codigo,e.cantidad, e.fecha" +
                        ", p.id as idProducto, p.nombre, p.tipo From entradas e " +
                        " inner join productos p on (e.codigo = p.codigo ) order by e.codigo ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);

                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Entradas entrada = new Entradas();
                        entrada.Id = (int)resultado["idEntrada"];
                        entrada.MiProducto.Id = (int)resultado["idProducto"];
                        entrada.MiProducto.Codigo = (string)resultado["codigo"];
                        entrada.MiProducto.Nombre = (string)resultado["nombre"];
                        entrada.MiProducto.Tipo = (string)resultado["tipo"];
                        entrada.Cantidad = (int)resultado["cantidad"];
                        entrada.Fecha = (DateTime)resultado["fecha"];
                        ListarEntradas.Add(entrada);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }


            return ListarEntradas;
        }


        public void InsertarEntradas(Entradas e)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    // Abre BBDD
                    conn.Open(); 
                    // Crea INSERT 
                    string consulta = "INSERT INTO entradas(id, codigo, cantidad, fecha) " +
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

        public void InsertarEntradas(string codigo, int cantidad, DateTime fecha)
        {
            Entradas entrada = new Entradas();
            entrada.MiProducto.Codigo = codigo;
            entrada.Cantidad = cantidad;
            entrada.Fecha = fecha;
            InsertarEntradas(entrada);
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
                    string consulta = "Delete from Entradas";
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
                    string consulta = "Delete from Entradas" +
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

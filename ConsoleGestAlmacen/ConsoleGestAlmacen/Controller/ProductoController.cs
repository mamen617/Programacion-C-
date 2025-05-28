using ConsoleGestAlmacen.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestAlmacen.Controller
{
    internal class ProductoController
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> listadoProductos = new List<Producto>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT * from productos order by codigo ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);

                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Producto producto = new Producto();
                        producto.Id = (int)resultado["id"];
                        producto.Codigo = (string)resultado["codigo"];
                        producto.Nombre = (string)resultado["nombre"];
                        producto.Tipo = (string)resultado["tipo"];
                        listadoProductos.Add(producto);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }        
            }
            return listadoProductos;
        }

        public void InsertarProducto(Producto p)
        {
            // Creo Conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open(); // Abre BBDD
                    string consulta = "INSERT INTO productos(codigo, nombre, tipo) " +
                        " VALUES (@codigo,@nombre,@tipo)"; // Crea INSERT 
                    // MAPEO datos
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@codigo", p.Codigo);
                    comando.Parameters.AddWithValue("@nombre", p.Nombre);
                    comando.Parameters.AddWithValue("@tipo", p.Tipo);
                    int resultado = comando.ExecuteNonQuery(); // EJECUTO
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }        
            }
         }

        public void InsertarProducto(string codigo, string nombre, string tipo)
        {
            Producto producto = new Producto();
            producto.Codigo = codigo;
            producto.Tipo = tipo;   
            producto.Nombre = nombre;
            InsertarProducto(producto);
        }
        public int getNumProductos()
        {
            int resultado = 0;
            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open(); // Abre BBDD
                    string consulta = "Select count(*) as numero from productos";
                    // MAPEO datos                                                              
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    // El executescalar se utiliza para devolver un dato
                    resultado = Convert.ToInt32(comando.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return resultado;
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
                    // consulta de borrado 
                    string consulta = "Delete from Productos";
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
                    string consulta = "Delete from Productos" +
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
        public List<Producto> ListarStock()
        {
            List<Producto> listadoProductos = new List<Producto>();

            using (var conn = new Conexion().GetConexion())
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT p.codigo,  p.nombre " +
                        ", IFNULL(e.total_entradas, 0) AS total_entradas " +
                        ", IFNULL(s.total_salidas, 0) AS total_salidas " +
                        ", (IFNULL(e.total_entradas, 0) - IFNULL(s.total_salidas, 0)) AS stock" +
                        " FROM  productos p " +
                        " LEFT JOIN " +
                        " (SELECT codigo, SUM(cantidad) AS total_entradas FROM entradas GROUP BY codigo) e " +
                        " ON p.codigo = e.codigo " +
                        " LEFT JOIN " +
                        " (SELECT codigo, SUM(cantidad) AS total_salidas  FROM salidas  GROUP BY codigo) s " +
                        " ON p.codigo = s.codigo;";

                    //SELECT
                    //codigo,
                    //SUM(cantidad) AS stock_actual
                    //FROM(
                    //SELECT codigo, cantidad FROM entradas
                    //UNION ALL
                    //SELECT codigo, -cantidad FROM salidas
                    //) AS movimientos
                    //GROUP BY codigo
                    //ORDER BY codigo;

                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    MySqlDataReader resultado = comando.ExecuteReader();

                    while (resultado.Read())
                    {
                        Producto producto = new Producto();
                        producto.Codigo = (string)resultado["codigo"];
                        producto.Nombre = (string)resultado["nombre"];
                        producto.total_entradas = Convert.ToInt32(resultado["total_entradas"]);
                        producto.total_salidas = Convert.ToInt32(resultado["total_salidas"]);
                        producto.stock = Convert.ToInt32(resultado["stock"]);
                        // ** Esto sirve para convertir a decimales (float) si no se convierte como está arriba
                        //producto.total_entradas = (int)resultado.GetFloat(resultado.GetOrdinal("total_entradas"));
                        //producto.total_salidas = (int)resultado.GetFloat(resultado.GetOrdinal("total_salidas"));
                        //producto.stock = (int)resultado.GetFloat(resultado.GetOrdinal("stock"));
                        listadoProductos.Add(producto);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return listadoProductos;
        }

    }
}

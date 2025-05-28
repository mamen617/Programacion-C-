using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleClientePedido.Modelo;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Mysqlx.Cursor;
using static System.Runtime.InteropServices.JavaScript.JSType;


//INSERT INTO Clientes(ClienteID, Nombre, Ciudad) VALUES
//(1, 'Juan Martínez', 'Madrid'),
//(2, 'Laura Sánchez', 'Barcelona'),
//(3, 'Pedro Gómez', 'Valencia'),
//(4, 'Sofía Ramírez', 'Sevilla');
//INSERT INTO Pedidos(PedidoID, Fecha, ClienteID, Monto) VALUES
//(101, '2024-05-01', 1, 250.50),
//(102, '2024-05-02', 2, 120.00),
//(103, '2024-05-03', 1, 75.00),
//(104, '2024-05-04', 3, 60.00),
//(105, '2024-05-05', 1, 300.00);

namespace ConsoleClientePedido
{
    public class Gestion
    {
        public void Menu()
        {
            Console.WriteLine("soy el menu");


            //opción 1: Instertar cliente
            Cliente c = new Cliente("Begoña","Mexico");
            CrearCliente(c);

            //opción 2: Crear pedidos
     
            Pedido p = new Pedido("08/05/2025", 1, 25);

            //opción 3: Eliminar pedidos

            //opción 4: Listar pedidos
            ListarPedido();
            ListarPedido("2024-05-04");
            //opción 5: Listar clientes
            ListarClientes();
            //opción 6: salir
        }
        public void ListarClientes()
        {
            /* Asi se haria sin utilizar la clase conexion****************************
                //1. crear cadena de conexion 
                string servidor = "localhost";
                string usuario = "root";
                string pass = "";
                string baseDatos = "ejemplo";
                string cadena = "server=" + servidor + ";user=" + usuario + ";password=" + pass + ";database=" + baseDatos + "; ";
                //2. crear conexion 
                //using MySqlConnection conn = new MySqlConnection(cadena);
            */
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = " select ClienteID, Nombre, Ciudad from clientes";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //guardar los datos en algun sitio
                    MySqlDataReader resultado = comando.ExecuteReader();
                    Console.WriteLine("*********************");
                    Console.WriteLine("Listado de clientes");
                    Console.WriteLine("*********************");
                    while (resultado.Read())
                    {
                        //5. Mostrar por pantalla
                        Console.WriteLine(resultado["Nombre"] + "-" + resultado["Ciudad"]);
                    }
                    //6. cerrar conexión
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // aqui podriamos cerrar la connexion
                }
            }
        }
        public void ListarPedido()
        {
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = " select c.clienteID, nombre, ciudad,PedidoID, fecha, monto from clientes c " +
                    " inner join Pedidos p on c.clienteID = p.clienteID ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //guardar los datos en algun sitio
                    MySqlDataReader resultado = comando.ExecuteReader();
                    Console.WriteLine("**********************************");
                    Console.WriteLine("** Listado de todos los Pedidos **");
                    Console.WriteLine("**********************************");
                    while (resultado.Read())
                    {
                        //5. Mostrar por pantalla
                        Console.WriteLine(resultado["nombre"] + " - " + resultado["PedidoID"] +
                        " - " + resultado["fecha"] + " - " + resultado["monto"]);
                    }
                    //6. cerrar conexión
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // aqui podriamos cerrar la connexion
                }
            }
         }
        public void ListarPedido(string Fecha)
        {
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = " select c.clienteID, nombre, ciudad,PedidoID, fecha, monto from clientes c " +
                        " inner join Pedidos p on c.clienteID = p.clienteID  where fecha < @Fecha ";

                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@Fecha", Fecha);

                    //guardar los datos en algun sitio
                    MySqlDataReader resultado = comando.ExecuteReader();
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("Listado de Pedidos anteriores a " + Fecha);
                    Console.WriteLine("***************************************************");
                    while (resultado.Read())
                    {
                        //5. Mostrar por pantalla
                        Console.WriteLine(resultado["nombre"] + " - " + resultado["PedidoID"] +
                            " - " + resultado["fecha"] + " - " + resultado["monto"]);
                    }
                    //6. cerrar conexión
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // aqui podriamos cerrar la connexion
                }
            }
        }
        public void CrearCliente(Cliente c)
        {
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = "INSERT INTO clientes (Nombre,Ciudad) VALUES (@nombre,@ciudad)";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@nombre", c.Nombre);
                    comando.Parameters.AddWithValue("@ciudad", c.Ciudad);
                    //Ejecuta
                    int fila = comando.ExecuteNonQuery();
                    if (fila > 0)
                    {
                        Console.WriteLine("***************************************************");
                        Console.WriteLine("Cliente Creado: " + c.Nombre + "," + c.Ciudad);
                        Console.WriteLine("***************************************************");
                    }
                    else
                    {
                        Console.WriteLine("***************************************************");
                        Console.WriteLine("No se ha generado la insercción ");
                        Console.WriteLine("***************************************************");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // aqui podriamos cerrar la connexion
                }
            }
        }

        public void EliminarCliente(Cliente c)
        {
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = "DELETE FROM clientes WHERE Id = @id";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@nombre", c.Id);
                    //Ejecuta
                    int fila = comando.ExecuteNonQuery();
                    if (fila > 0)
                    {
                        Console.WriteLine("****************************************************************************");
                        Console.WriteLine("** Cliente Borrado: " + c.Id + " ," + c.Nombre + ", " + c.Ciudad);
                        Console.WriteLine("****************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("*****************************************************************************************");
                        Console.WriteLine("** No se ha podido Borrar el cliente: " + c.Id + " ," + c.Nombre + ", " + c.Ciudad);
                        Console.WriteLine("*****************************************************************************************");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // aqui podriamos cerrar la connexion
                }
            }
        }

    }
}

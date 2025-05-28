using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eventos.Modelo;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using Org.BouncyCastle.Asn1;

namespace Eventos
{
    public class Gestion
    {
        public void Menu()
        {
            int opcion = 1;
            do
            {


                Console.WriteLine("****************");
                Console.WriteLine("**** Menú ******");
                Console.WriteLine("****************");
                Console.WriteLine("");

                //opción 1: Consultar mis compras de entradas
               Console.WriteLine("1: Consultar mis compras de entradas");
                //opción 2: Comprar una nueva entrada
                Console.WriteLine("2: Comprar una nueva entrada");
                //Pedido p = new Pedido("08/05/2025", 1, 25);

                //opción 3: Ver el total gastado en entradas
                Console.WriteLine("3: Ver el total gastado en entradas");

                //opción 4: Consultar próximas fechas de eventos comprados
                Console.WriteLine("4: Consultar próximas fechas de eventos comprados");

                //opción 5: salir
                Console.WriteLine("5: salir");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        ConsultaEntradas();
                        break;
                    case 2:
                        ComprarEntradas();
                        break;
                    case 3:
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.WriteLine("");
                        break;
                }
            } while (opcion != 5);
        }

        public void ComprarEntradas()
        {
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    Console.Write("Introduce el usuario : ");
                    string nombreUsuario = Console.ReadLine();
                    int IDUsuario = DevuelveIDUsuario(nombreUsuario);
                    int EventoID = ListarEventos();
                    if  (EventoID > 0) { 
                        //3. abrir base de datos
                        conn.Open();
                        //4. Ejecutar consulta

                        string consulta = " INSERT INTO compras " +
                            " (CompraID, UsuarioID, EventoID, FechaCompra) VALUES " +
                            " (Null,@usuarioID,@EventoID,@FechaCompra) ";

                        MySqlCommand comando = new MySqlCommand(consulta, conn);
                        comando.Parameters.AddWithValue("@usuarioID", IDUsuario);
                        comando.Parameters.AddWithValue("@EventoID", EventoID);
                        comando.Parameters.AddWithValue("@FechaCompra", "2025-05-09");
                        //guardar los datos en algun sitio
                        MySqlDataReader resultado = comando.ExecuteReader();
                        Console.WriteLine("");
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("Listado de Entradas del Usuario: " + nombreUsuario);
                        Console.WriteLine("**********************************************************");
                        Console.WriteLine("");
                        while (resultado.Read())
                        {
                            //5. Mostrar por pantalla
                            Console.WriteLine(resultado["NombreUsuario"] + "-" + resultado["NombreEvento"] + "-" + resultado["FechaEvento"] + "-" + resultado["Precio"]);
                        }
                        //6. cerrar conexión
                        conn.Close();
                    }
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
        public int DevuelveIDUsuario(string NombreUsuario)
        {
            int UsuarioID = 0;
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = " SELECT UsuarioID FROM usuarios Where NombreUsuario =@NombreUsuario ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@NombreUsuario", NombreUsuario);
                    MySqlDataReader resultado = comando.ExecuteReader();
                    while (resultado.Read())
                    {
                        UsuarioID = Convert.ToInt32(resultado["UsuarioID"]);
                    }
                    //6. cerrar conexión
                    return UsuarioID;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                   
                }

            }
            return UsuarioID;
        }
        public int ListarEventos()
        {
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = " SELECT EventoID, NombreEvento ,FechaEvento,Precio " +
                        " FROM  EventoId ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    //guardar los datos en algun sitio
                    MySqlDataReader resultado = comando.ExecuteReader();
                    Console.WriteLine("");
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine("Listado de Eventos****************************************");
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine("");
                    while (resultado.Read())
                    {
                        //5. Mostrar por pantalla
                        Console.WriteLine(resultado["EventoID"] + "-" + resultado["NombreEvento"] + "-" + resultado["FechaEvento"] + "-" + resultado["Precio"]);
                    }
                    //6. cerrar conexión
                    conn.Close();
                    Console.Write("Introduce el Codigo de Evento:");
                    int EventoID = int.Parse(Console.ReadLine());
                    return EventoID;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {

                }

            }
            return 0;
        }
        public void ConsultaEntradas()
        {
            using (var conn = new Conexion().GetConnection())
            {
                try
                {
                    Console.Write("Introduce el usuario : ");
                    string nombreUsuario = Console.ReadLine();
                    //3. abrir base de datos
                    conn.Open();
                    //4. Ejecutar consulta
                    string consulta = " SELECT u.UsuarioID as UsuarioID , u.NombreUsuario as NombreUsuario " +
                        ", c.CompraID as CompraID, c.EventoID as EventoID,c.FechaCompra as FechaCompra " +
                        " , e.NombreEvento as NombreEvento, e.FechaEvento as FechaEvento, e.Precio as Precio " +
                        " FROM usuarios u inner JOIN compras c " +
                        " on (u.UsuarioID = c.UsuarioID) inner join EventoId e on  (c.EventoID = e.EventoID)  " +
                        " WHERE u.NombreUsuario = @NombreUsuario ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);
                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    //guardar los datos en algun sitio
                    MySqlDataReader resultado = comando.ExecuteReader();
                    Console.WriteLine("");
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine("Listado de Entradas del Usuario: " + nombreUsuario);
                    Console.WriteLine("**********************************************************");
                    Console.WriteLine("");
                    while (resultado.Read())
                    {
                        //5. Mostrar por pantalla
                        Console.WriteLine(resultado["NombreUsuario"] + "-" + resultado["NombreEvento"] + "-" + resultado["FechaEvento"] + "-" + resultado["Precio"]);
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
    }
}

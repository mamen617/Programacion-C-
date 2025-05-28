using ConsolePedidoEvento1.Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsolePedidoEvento1.Controller
{
    internal class EntradasController
    {
        public List<Compra> getListaEntradas(string nombre)
        {
            List<Compra> listadoEntradas = new List<Compra>();

            // Crear cadena conexion
            using (var conn = new Conexion().GetConexion())
            {
                try
                {// P3: Abrir BBDD
                    conn.Open();
                    // P4: Ejecutar consulta
                    string consulta = "select * from eventoid e join compras c " +
                        "on e.EventoID = c.EventoID " +
                        "join usuarios u on u.UsuarioID = c.UsuarioID " +
                        "WHERE u.NombreUsuario LIKE @nombre ";
                    MySqlCommand comando = new MySqlCommand(consulta, conn);

                    comando.Parameters.AddWithValue("@nombre", "%"+nombre+"%");
                    // Guardar el resultado de ese comando en algun sitio
                    MySqlDataReader resultado = comando.ExecuteReader();
                    // P5: Mostra por pantalla datos
                    while (resultado.Read())
                    {
                        Compra compra = new Compra();
                        Evento evento = new Evento();
                        Usuario usuario = new Usuario();

                        evento.NombreEvento = (string)resultado["NombreEvento"];
                        evento.FechaEvento = (DateTime) resultado["FechaEvento"];
                        evento.PrecioEvento = resultado.GetFloat(resultado.GetOrdinal("Precio"));

                        usuario.Nombre = (string) resultado["NombreUsuario"];

                        compra.FechaCompra = (DateTime) resultado["FechaCompra"];
                        compra.obUsuario = usuario;
                        compra.obEvento = evento;

                       // Console.WriteLine(compra.ToString()) ;


                        listadoEntradas.Add(compra);

                      }
                    // P6: Cerrar conexion
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return listadoEntradas;
            }
        }
    }
}

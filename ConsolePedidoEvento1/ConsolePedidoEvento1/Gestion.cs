using ConsolePedidoEvento1.Controller;
using ConsolePedidoEvento1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePedidoEvento1
{
    internal class Gestion
    {
        /*
         * Esquema del menú


--- Gestor de Compras de Entradas --- 
1. Consultar mis compras de entradas 
2. Comprar una nueva entrada 
3. Ver el total gastado en entradas 
4. Consultar próximas fechas de eventos comprados 
5. Salir 

Detalle de las opciones

Comprar una nueva entrada
El usuario selecciona un evento disponible (puedes mostrar una lista de eventos) e inserta una nueva compra en la base de datos para ese usuario.

Ver el total gastado en entradas
El programa calcula y muestra la suma total de dinero que el usuario ha gastado en todas sus compras de entradas.

Consultar próximas fechas de eventos comprados
Muestra únicamente las entradas compradas para eventos cuya fecha es posterior a la fecha actual.

Salir
Finaliza la aplicación.
         */

        public void Menu()
        {
            Console.WriteLine("SOY UN MENU");
            // OPC 1 

            ConsultarEntradas();
        }

        /*
         * Consultar mis compras de entradas
          El usuario introduce su nombre de usuario 
          y el programa muestra todas las entradas que ha comprado, 
          incluyendo el evento, fecha del evento, precio y fecha de compra, 
          ordenadas por la fecha del evento.

        */
        public void ConsultarEntradas()
        {
            // Pedir por pantalla el nombre del usuario
            Console.WriteLine(" Introduce tu nombre");
            String nombreUsuario  = Console.ReadLine();
            // Recuperar de la tablas la información de CompraId, UsuarioID, ...
            // 
            EntradasController entradasController = new EntradasController();
            List<Compra> listado = entradasController.getListaEntradas(nombreUsuario);

            int i = 0;
            foreach (Compra compra in listado)
            {
                Console.WriteLine("PASO " );
                Console.WriteLine(i++ );
                Console.WriteLine(compra.ToString());
            }
                //  obCompra obC = GetEntradas(nombreUsuario):
            
            // NOmbreEvento = obC.Evento.NombreEvento
            // FechaEvento = obC.Evento.FechaEvento
            // PrecioEvento = obc.Evento.Precio
            // FechaCompra = obC.Compra.FechaCompra




        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    public class GestionProducto
    {
        Dictionary<String, Producto> listado = new Dictionary<string, Producto>();

        public void Generar_Diccionario()
        {
            // Añado elementos
            listado.Add("Pizza", new Producto("Pizza", 50, 2));
            listado.Add("Silla", new Producto("Silla", 20, 3));
            listado.Add("Zapato", new Producto("Zapato", 50, 10));
            listado.Add("Camisa", new Producto("Camisa", 70, 50));
            listado.Add("Motor", new Producto("Motor", 90, 80));
            listado.Add("Pincel", new Producto("Pincel", 150, 9));
            listado.Add("Raqueta", new Producto("Raqueta", 250, 9));
            listado.Add("Pintalabios", new Producto("Pintalabios", 750, 10));
            listado.Add("Bicicleta", new Producto("Bicicleta", 650, 25));
            listado.Add("Casco", new Producto("Casco", 750, 27));
            listado.Add("Ordenador", new Producto("Ordenador", 1050, 82));
            listado.Add("Croqueta", new Producto("Croqueta", 9, 92));
            listado.Add("Bombilla", new Producto("Bombilla", 8, 27));

        }
        //// Recorrer elementos
        public void Imprimir_Diccionario()
        {

            foreach (KeyValuePair<string, Producto> misProductos in listado)
            {
                // Imprime la clave
                // Console.WriteLine(misProductos.Key);
                // Imprime TODO
                misProductos.Value.Imprimir();
                // Imprime un valor
                //Console.WriteLine(misProductos.Value.getCantidad());
            }

        }

        public void Imprimir_Totales()
        {
            int totalProductos = 0;
            int totalCantidad = 0;
            double totalPrecio = 0;
            foreach (KeyValuePair<string, Producto> misProductos in listado)
            {
                totalProductos = totalProductos + 1;
                totalPrecio = totalPrecio + (misProductos.Value.getPrecio());
                totalCantidad = totalCantidad + (misProductos.Value.getCantidad());
             
            }
            Console.WriteLine("Total Productos: " + totalProductos);
            Console.WriteLine("Total Precio: " + totalPrecio + " Euros");
            Console.WriteLine("Total Cantidad: " + totalCantidad + " unidades");

        }
        public void Agregar_Producto_Dicicionario(string clave, string nombre, double precio, int cantidad )
        {
            if (listado.ContainsKey(clave))
            {
                Producto p = listado[clave];
                p.setCantidad(p.getCantidad() + cantidad);
                listado.Remove(clave);
                listado.Add(clave, p);
            }
            else
            {
                listado.Add(clave, new Producto(nombre, precio, cantidad));
            }
        }

        public void Borrar_Producto_Dicicionario(string clave)
        {
            if (listado.ContainsKey(clave))
            {
                listado.Remove(clave);
            }

        }

    }
}

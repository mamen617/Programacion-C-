using ConsoleGestAlmacen.Controller;
using ConsoleGestAlmacen.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleGestAlmacen
{
    internal class Gestion
    {
        // PRESENTACION

        public void Menu()
        {
            // Esto es un menu
            Console.WriteLine("Esto es un MENU ");

            BaseDatos bb = new BaseDatos();
            bb.CrearBaseDatos();

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de productos");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            ProductoController c = new ProductoController();
            // borro tabla
            c.BorrarTabla();
            c.InsertarProducto("AAAA", "Chorizo", "embutido");
            c.InsertarProducto("BBBB", "Cebolla", "Verdura");
            c.InsertarProducto("CCCC", "tomate", "fruta");

            Console.WriteLine("");
            Console.WriteLine("*************************");
            Console.WriteLine("Listado de Productos");
            Console.WriteLine("*************************");
            Console.WriteLine("");

            List<Producto> p = c.ListarProductos();
            foreach (Producto producto in p)
            {
                Console.WriteLine(producto.Imprimir());
            }
            Console.WriteLine("*************************");
            Console.WriteLine(" Total productos: " + c.getNumProductos());
            Console.WriteLine("*************************");

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de entradas");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            EntradasController e = new EntradasController();
            // borro tabla
            e.BorrarTabla();

            e.InsertarEntradas("AAAA", 10, DateTime.Now);
            e.InsertarEntradas("BBBB", 15, DateTime.Now);
            e.InsertarEntradas("BBBB", 7, DateTime.Now);
            e.InsertarEntradas("BBBB", 2, DateTime.Now);
            e.InsertarEntradas("CCCC", 15, DateTime.Now);

            Console.WriteLine("");
            Console.WriteLine("*************************");
            Console.WriteLine("Listado de Entradas");
            Console.WriteLine("*************************");
            Console.WriteLine("");

            List <Entradas> MiEntrada = e.ListarEntradas();
            foreach (Entradas ee in MiEntrada)
            {
                Console.WriteLine(ee.ToString());
            }


            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de salidas");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            SalidasController s = new SalidasController();
            // borro tabla
            s.BorrarTabla();
            s.InsertarSalidas("AAAA", 5, DateTime.Now);
            s.InsertarSalidas("AAAA", 1, DateTime.Now);
            s.InsertarSalidas("BBBB", 9, DateTime.Now);
            s.InsertarSalidas("CCCC", 4, DateTime.Now);

            Console.WriteLine("");
            Console.WriteLine("*************************");
            Console.WriteLine("Listado de Salidas");
            Console.WriteLine("*************************");
            Console.WriteLine("");

            List<Salidas> MiSalida = s.ListarSalidas();
            foreach (Salidas ss in MiSalida)
            {
                Console.WriteLine(ss.ToString());
            }

            Console.WriteLine("");
            Console.WriteLine("*************************");
            Console.WriteLine("Listado de stock");
            Console.WriteLine("*************************");
            Console.WriteLine("");

            //reutilizo la clase de producto no la vuelvo a declarar
            p = c.ListarStock();
            foreach (Producto producto in p)
            {
                Console.WriteLine(producto.Imprimir_stock());
            }
        }
    }
}

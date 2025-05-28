using ConsoleClubNautico.Controller;
using ConsoleClubNautico.Modelo;
using ConsoleClubNautico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleClubNautico
{
    internal class Gestion
    {
        // PRESENTACION

        public void Menu()
        {
            // Esto es un menu
            Console.WriteLine("Esto es un MENU ");


            //BaseDatos bb = new BaseDatos();
            //bb.CrearBaseDatos();


            DateTime fecha = DateTime.Now;
            


            // Amarres:*****************************************

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de Amarres");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            AmarreController AmarreC = new AmarreController();
            //AmarreC.BorrarTabla();
            Amarres amarre = new Amarres();
            amarre.cuota = 100;
            AmarreC.Insertar(amarre);
            amarre.cuota = 200;
            AmarreC.Insertar(amarre);
            amarre.cuota = 300;
            AmarreC.Insertar(amarre);
            AmarreC.Listar();

            List<Amarres> listado = AmarreC.Listar();
            foreach (Amarres i in listado)
            {
                Console.WriteLine(i.Imprimir_Tabla());
            }

            //Destinos:*****************************************

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de Destinos");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            DestinoController DestinoC = new DestinoController();
            //DestinoC.BorrarTabla();
            Destinos destino = new Destinos(); // declaración de objecto
            destino.nombre = "Cuba";
            DestinoC.Insertar(destino);
            destino.nombre = "Japon";
            DestinoC.Insertar(destino);
            destino.nombre = "Mexico";
            DestinoC.Insertar(destino);
            DestinoC.Listar();

            List<Destinos> listado_Destino = DestinoC.Listar();
            foreach (Destinos i in listado_Destino)
            {
                Console.WriteLine(i.Imprimir_Tabla());
            }

            // Patrones:*****************************************

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de Patrones");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            PatronControler PatronesC = new PatronControler();
            PatronesC.BorrarTabla();
            Patrones Patron = new Patrones( "111111111A","pepe","sin direccion 1", "611111111"); // declaración de objecto
            PatronesC.Insertar(Patron);
            Patron = new Patrones("222222222B", "juan", "sin direccion 2", "622222222"); // asignación de uno nuevo
            PatronesC.Insertar(Patron);
            Patron = new Patrones("333333333C", "carlos", "sin direccion", "61855567"); // asignación de uno nuevo
            PatronesC.Insertar(Patron);
            Patron = new Patrones("444444444D", "maria", "sin direccion", "61855567"); // asignación de uno nuevo
            PatronesC.Insertar(Patron);
            Patron = new Patrones("55555555D", "alberto", "sin direccion", "61855567"); // asignación de uno nuevo
            PatronesC.Insertar(Patron);
            PatronesC.Listar();

            List<Patrones> listado_Patrones = PatronesC.Listar();
            foreach (Patrones i in listado_Patrones)
            {
                Console.WriteLine(i.Imprimir_Tabla());
            }

            // Socios:*****************************************

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de Socios");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            SociosController SociosC = new SociosController();
            SociosC.BorrarTabla();
            Socios Socio = new Socios("111111111A", "pepe", "sin direccion 1", "611111111"); // declaración de objecto
            SociosC.Insertar(Socio);
            Socio = new Socios("222222222B", "juan", "sin direccion 2", "622222222"); // asignación de uno nuevo
            SociosC.Insertar(Socio);
            Socio = new Socios("333333333C", "carlos", "sin direccion", "61855567"); // asignación de uno nuevo
            SociosC.Insertar(Socio);
            Socio = new Socios("444444444D", "maria", "sin direccion", "61855567"); // asignación de uno nuevo
            SociosC.Insertar(Socio);
            Socio = new Socios("55555555D", "alberto", "sin direccion", "61855567"); // asignación de uno nuevo
            SociosC.Insertar(Socio);
            SociosC.Listar();

            List<Socios> listado_Socios = SociosC.Listar();
            foreach (Socios i in listado_Socios)
            {
                Console.WriteLine(i.Imprimir_Tabla());
            }

            // Barcos:*****************************************

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de Barcos");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            BarcoController BarcoC = new BarcoController();
            BarcoC.BorrarTabla();
            Barcos Barco = new Barcos();
            Barco = new Barcos(1, 70, "MAT-11111", "BARCO MANOLO");
            BarcoC.Insertar(Barco);
            Barco = new Barcos(2, 71, "MAT-22222", "BARCO PEPE");
            BarcoC.Insertar(Barco);
            Barco = new Barcos(3, 72, "MAT-55555", "BARCO JUAN");
            BarcoC.Insertar(Barco);
            Barco = new Barcos(3, 73, "MAT-66666", "BARCO LUNA");
            BarcoC.Insertar(Barco);
            Barco = new Barcos(5, 74, "MAT-88888", "BARCO LAPIZ");
            BarcoC.Insertar(Barco);
          
            BarcoC.Listar();

            List<Barcos> listadoB = BarcoC.Listar();
            foreach (Barcos i in listadoB)
            {
                Console.WriteLine(i.Imprimir_Tabla());
            }


            // Salidas:*****************************************

            Console.WriteLine("");
            Console.WriteLine("******************************");
            Console.WriteLine("Hago inserción de Salidas");
            Console.WriteLine("******************************");
            Console.WriteLine("");

            SalidasController SalidaC = new SalidasController();
            SalidaC.BorrarTabla();
            Salidas Salida = new Salidas();
            Salida = new Salidas(1, 70, fecha, 52);
            SalidaC.Insertar(Salida);
            Salida = new Salidas(1, 70, fecha, 53);
            SalidaC.Insertar(Salida);
            Salida = new Salidas(3, 72, fecha, 54);
            SalidaC.Insertar(Salida);
            Salida = new Salidas(3, 73, fecha, 55);
            SalidaC.Insertar(Salida);
            Salida = new Salidas(5, 74, fecha, 56);
            SalidaC.Insertar(Salida);

            SalidaC.Listar();

            List<Salidas> listado_Salida = SalidaC.Listar();
            foreach (Salidas i in listado_Salida)
            {
                Console.WriteLine(i.Imprimir_Tabla());
            }



        }
    }
}

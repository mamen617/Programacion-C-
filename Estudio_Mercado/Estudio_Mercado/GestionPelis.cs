using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estudio_Mercado
{
    public class GestionPelis
    {
        int id;
        string nombre = "";
        int puntos;
        string observaciones = "";

        List<Pelis> listaPelis = new List<Pelis>(); // LISTA de peliculas
             
        public void InsertarPelicula(Pelis miPeli)
        {
            listaPelis.Add(miPeli);
        }

        public void ListarPeliculas()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Listado de Peliculas");
            Console.WriteLine("********************");
            try
            {
                foreach (var c in listaPelis)
                {
                    c.Escribir();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Pelis rellenaPeli()
        {
            Console.Write("Introduce el id:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Introduce el nombre de la pelicula:");
            String nombre = Console.ReadLine();
            Console.Write("Introduce que puntuación le das del 1 al 10:");
            int puntos = int.Parse(Console.ReadLine());
            Console.Write("Introduce tus comentarios:");
            String observaciones = Console.ReadLine();
            //Aqui estoy construyendo el objeto pelis
            Pelis mipeli = new Pelis(id, nombre, puntos, observaciones);
            return mipeli;
        }


        public void MediaPeliculas()
        {
            Console.WriteLine("********************");
            Console.WriteLine("Media de Peliculas");
            Console.WriteLine("********************");

            int sumapuntos=0;
            try
            {
                foreach (var c in listaPelis)
                {
                    sumapuntos= sumapuntos + c.puntos;
                }
                int miMedia = sumapuntos /listaPelis.Count();

                Console.WriteLine($"Mi media es : {miMedia}");
                Console.WriteLine($"Total puntuacion  : {sumapuntos}");
                Console.WriteLine($"Total elementos   : {listaPelis.Count()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Inicio()
        {
            Console.WriteLine("Inicio del programa ");
            Console.WriteLine("********************");
            Console.WriteLine("Rellena los datos");
            Console.WriteLine("********************");
            // Crear el objeto o instanciar
            Pelis p1 = rellenaPeli();
            InsertarPelicula(p1);
            p1 = rellenaPeli();
            InsertarPelicula(p1);
            p1 = rellenaPeli();
            InsertarPelicula(p1);
            // Imprime el listado
            ListarPeliculas();

            MediaPeliculas();

        }



    }
}


  


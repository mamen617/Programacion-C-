using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Estudio_Mercado
{
    public class Pelis
    {
        public int id;
        public string nombre = "";
        public int puntos;
        public string observaciones = "";
        //Constructor
        public Pelis(int id, String nombre, int puntos, String observaciones)
        {
            this.id = id;
            this.nombre = nombre;
            this.puntos = puntos;
            this.observaciones = observaciones;
        }
        public void Escribir()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("nombre: " + nombre);
            Console.WriteLine("puntos: " + puntos);
            Console.WriteLine("observaciones: " + observaciones);
        }
    }
}

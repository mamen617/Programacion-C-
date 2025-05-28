using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    public class Producto
    {
        // atributos*********************************************

        //String id_diccionario;
        String nombre;
        int cantidad;        
        double precio;
        
        //Constructores*******************************************

        public Producto(String nombre)
        {
            this.nombre = nombre;
           
        }
        public Producto(String nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }
        public Producto(String nombre,  double precio, int cantidad)
        {
            this.nombre = nombre;
            this.precio = precio;
            this.cantidad = cantidad;
            
        }
        // Set ***************************************************
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
        public void setCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }
        public void setPrecio(double precio)
        {
            this.precio = precio;
        }
        public string getNombre()
        {
            return nombre;
        }

        public int getCantidad()
        {
            return cantidad;
        }
        public double getPrecio()
        {
            return precio;
        }

        // Metodos para ver por pantalla
        public void Imprimir()
        {
            Console.WriteLine("Producto: " + nombre);
            Console.WriteLine(" precio: " + precio + " Euros");
            Console.WriteLine(" cantidad: " + cantidad +  " und.");
        }


    }
}

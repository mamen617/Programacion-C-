using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleGestAlmacen.Modelo
{
    internal class Entradas
    {
        public int Id { get; set; }

        public Producto MiProducto { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public override string ToString()
        {
            return $"Id #{Id} | Codigo: {MiProducto.Codigo} | Nombre: {MiProducto.Nombre} | Cantidad: {Cantidad} | Fecha: {Fecha}";
        }
        //Constructor
        public Entradas()
        {
            MiProducto = new Producto();    
        }
        public Entradas(int id, Producto miproducto, int cantidad, DateTime fecha)
        {
            this.Id = id;
            this.MiProducto = miproducto;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }
    }
}

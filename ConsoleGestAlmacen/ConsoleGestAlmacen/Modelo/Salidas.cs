using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestAlmacen.Modelo
{
    internal class Salidas
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
        public Salidas()
        {
            MiProducto = new Producto();
        }
        public Salidas(int id, Producto miproducto, int cantidad, DateTime fecha)
        {
            this.Id = id;
            this.MiProducto = miproducto;
            this.Cantidad = cantidad;
            this.Fecha = fecha;
        }
    }
}

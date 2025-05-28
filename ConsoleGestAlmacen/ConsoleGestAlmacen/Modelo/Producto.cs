using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGestAlmacen.Modelo
{
    internal class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        // añado estas propiedades para el stock no son campos de la tabla productos
       public int total_entradas { get; set; }
       public int total_salidas { get; set; }
       public int stock { get; set; }

        public string Imprimir()
        {
            return $"Id #{Id} | Codigo: {Codigo} | Nombre: {Nombre} | Tipo: {Tipo}";
        }
        public override string ToString()
        {
            return $"Id #{Id} | Codigo: {Codigo} | Nombre: {Nombre} | Tipo: {Tipo}";
        }
        public string Imprimir_stock()
        {
            return $"Codigo: {Codigo} | Nombre: {Nombre} | Entradas: {total_entradas} | Salidas: {total_salidas} | stock: {stock}";
        }
    }
}

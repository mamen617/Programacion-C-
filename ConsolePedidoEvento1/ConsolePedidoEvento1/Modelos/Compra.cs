using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePedidoEvento1.Modelos
{
    internal class Compra
    {
        public int IdCompra { get; set; }
        public Usuario obUsuario { get; set; }

        public Evento obEvento { get; set; }

        public DateTime FechaCompra { get; set; }


        public override string ToString()
        {
            return $"Compra #{IdCompra} | Usuario: {obUsuario?.Nombre} | Evento: {obEvento?.NombreEvento} | Fecha Evento: {obEvento?.FechaEvento:d} | Precio: {obEvento?.PrecioEvento:f} | Fecha Compra: {FechaCompra:g}";
        }

    }
}

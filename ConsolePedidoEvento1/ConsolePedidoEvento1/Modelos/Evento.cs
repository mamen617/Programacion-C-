using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePedidoEvento1.Modelos
{
    internal class Evento
    {
        public int Id { get; set; }
        public string NombreEvento { get; set; }
        public DateTime FechaEvento { get; set; }
        public float PrecioEvento { get; set; }
    }
}

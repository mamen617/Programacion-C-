using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Eventos.Modelo
{
    public class EventoId
    {
        public int EventoID { get; set; }
        public string NombreEvento { get; set; }
        public string FechaEvento { get; set; }
        public decimal Precio { get; set; }

        //Constructor Completo Actualización y Eliminación
        public EventoId(int EventoID, string NombreEvento, string FechaEvento, decimal Precio)
        {
            this.EventoID = EventoID;
            this.NombreEvento = NombreEvento;
            this.FechaEvento = FechaEvento;
            this.Precio = Precio;
        }
        //Constructor de Selección
        public EventoId(string NombreEvento, string FechaEvento, decimal Precio)
        {
            this.NombreEvento = NombreEvento;
            this.FechaEvento = FechaEvento;
            this.Precio = Precio;
        }

    }
}

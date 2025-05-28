using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Modelo
{
    public class Compras
    {

        public int CompraID { get; set; }
        public int UsuarioID { get; set; }
        public int EventoID { get; set; }
        public string FechaCompra { get; set; }

        //Constructor vacio
        public Compras()
        {

        }
        //Constructor Completo Actualización y Eliminación
        public Compras(int compraID, int usuarioID, int eventoID, string fechaCompra)
        {
            this.CompraID = compraID;
            this.UsuarioID = usuarioID;
            this.EventoID = eventoID;
            this.FechaCompra = fechaCompra;
        }
        //Constructor de Selección
        public Compras (int usuarioID, int eventoID, string fechaCompra)
        {
            this.UsuarioID = usuarioID;
            this.EventoID = eventoID;
            this.FechaCompra = fechaCompra;
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Cursor;

namespace ConsoleClientePedido.Modelo
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public string Fecha { get; set; }
        public int ClienteID { get; set; }
        public decimal Monto { get; set; }

        //Constructor para actualizar o  consulta
        public Pedido(int pedidoID, String fecha, int clienteId, decimal monto)
        {
            this.PedidoID = pedidoID;   
            this.Fecha = fecha;
            this.ClienteID = clienteId;
            this.Monto = monto;
        }
        //Constructor de insercción
        public Pedido(String fecha, int clienteId, decimal monto)
        {
            this.Fecha = fecha;
            this.ClienteID = clienteId;
            this.Monto = monto;
        }



    }
}

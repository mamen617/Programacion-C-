using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClientePedido.Modelo
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        //Constructor para actualizar o  consulta
        public Cliente(int id, String nombre, String ciudad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Ciudad = ciudad;

        }
        //Constructor de insercción
        public Cliente(String nombre, String ciudad)
        {
            this.Nombre = nombre;
            this.Ciudad = ciudad;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConsoleClubNautico.Modelo;
using MySqlX.XDevAPI.Relational;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Org.BouncyCastle.Crypto.Digests;

namespace ConsoleClubNautico.Modelo
{
    internal class Patrones
    {
        public int id_Patron { get; set; }
        public  string dni { get; set; }
        public string nombre  { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public int Baja { get; set; }
        public DateTime FechaBaja { get; set; }

        public string sql_tabla  = "create table Patrones( " +
            "  id_Patron INT AUTO_INCREMENT PRIMARY KEY " +
            ", dni VARCHAR(100) NOT NULL UNIQUE " +
            ", nombre VARCHAR(100) NOT NULL " +
            ", direccion   VARCHAR(200) " +
            ", telefono VARCHAR(15) NOT NULL " +
            ");";
        
        public Patrones() //Constructor
        {
            this.dni = "";
            this.nombre = "";
            this.direccion = "";
            this.telefono = "";
        }
        public Patrones(int id_Patron) //Constructor
        {
            this.id_Patron = id_Patron; 
            this.dni = "";
            this.nombre = "";
            this.direccion = "";
            this.telefono = "";
        }
        public Patrones(string dni,string nombre, string direccion, string telefono) //Constructor
        {
            this.dni = dni;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        public string Imprimir_Tabla()
        {
            return $"Id #{id_Patron} | Nombre: {nombre} ";
        }
        

    }
}

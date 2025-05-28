using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleClubNautico.Modelo
{
    internal class Destinos
    {
        public int id_Destino { get; set; }
        public string nombre { get; set; }
        public int Baja { get; set; }
        public DateTime FechaBaja { get; set; }

        public string sql_tabla  = " create table Destinos (" +
            "id_Destino INT AUTO_INCREMENT PRIMARY KEY " +
            ", nombre VARCHAR(200)" +
            ");";

        public string Imprimir_Tabla()
        {
            return $"Id #{id_Destino} | Nombre: {nombre} ";
        }
        public Destinos(string nombre) 
        {
            this.nombre = nombre;
        }
        public Destinos(int id_destino)
        {
            this.id_Destino = id_destino;
            this.nombre = "";
        }
        public Destinos()
        {
            this.nombre = "";
        }

    }
}


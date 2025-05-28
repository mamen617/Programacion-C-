using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Expect.Open.Types.Condition.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleClubNautico.Modelo
{
    internal class Amarres
    {
        public int id_Amarre { get; set; }
        public string nombre { get; set; }
        public double cuota { get; set; }
        public int Baja { get; set; }
        public DateTime FechaBaja { get; set; }

        public string sql_tabla = " create table Amarres (" +
            "ID_Amarre INT AUTO_INCREMENT PRIMARY KEY " +
            ", nombre      VARCHAR(100) NOT NULL" +
            ", cuota Double default 0 )" +
            ");";

        public string Imprimir_Tabla()
        {
            return $"Id_Amarre #{id_Amarre} | nombre: {nombre}| cuota: {cuota} ";
        }
        public Amarres( int id_Amarre, string nombre, double cuota)  //Constructor
        {
            this.id_Amarre=id_Amarre; this.nombre=nombre; this.cuota=cuota;
        }
        public Amarres(string nombre, double cuota)//Constructor
        {
             this.nombre = nombre; this.cuota = cuota;
        }
        public Amarres(int id_Amarre)  //Constructor
        {
            this.id_Amarre = id_Amarre; this.nombre =""; this.cuota = 0;
        }
        public Amarres()  //Constructor
        {
            this.nombre = ""; this.cuota = 0;
        }


    }
}

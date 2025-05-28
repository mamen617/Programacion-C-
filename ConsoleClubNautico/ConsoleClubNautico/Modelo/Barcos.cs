using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Mysqlx.Expect.Open.Types.Condition.Types;

namespace ConsoleClubNautico.Modelo
{
    internal class Barcos
    {
        public int id_Barco { get; set; }
        public string matricula { get; set; }
        public Socios Socio { get; set; }
        public string nombre { get; set; }
        public Amarres Amarre { get; set; }
        public int Baja { get; set; }
        public DateTime FechaBaja { get; set; }

        public string sql_tabla = "create table Barcos (" +
            " id_Barco INT AUTO_INCREMENT PRIMARY KEY" +
            " , matricula VARCHAR(100) NOT NULL UNIQUE" +
            ", id_Socio INT NOT NULL " +
            ", nombre VARCHAR(100) NOT NULL " +
            ", Id_Amarre INT NOT NULL " +
            " );";
        public string sql_tabla_Fk = "ALTER TABLE Barcos " +
            "  ADD CONSTRAINT fk_id_Socio FOREIGN KEY (id_Socio) REFERENCES Socios(id_Socio)" +
            ", ADD CONSTRAINT fk_id_Amarre FOREIGN KEY (id_Amarre) REFERENCES Amarres (id_Amarre) ;";

        //Constructor
        public Barcos()
        {
            this.Socio = new Socios();
            this.Amarre = new Amarres();
            this.matricula = "";
            this.nombre = "";
        }
        public Barcos(int id_barco)
        {
            this.id_Barco = id_barco;
            this.Socio = new Socios();
            this.Amarre = new Amarres();
            this.matricula = "";
            this.nombre = "";
        }
        public Barcos(Socios socio,Amarres amarre, string matricula, string nombre)
        {
            this.Socio = new Socios(socio.id_Socio,socio.dni,socio.nombre,socio.direccion,socio.telefono);
            this.Amarre = new Amarres(amarre.id_Amarre,amarre.nombre,amarre.cuota);
            this.matricula = matricula;
            this.nombre = nombre;
        }
        public Barcos(int idsocio, int idamarre, string matricula, string nombre)
        {
            this.Socio = new Socios(idsocio);
            this.Amarre = new Amarres(idamarre);
            this.matricula = matricula;
            this.nombre = nombre;
        }

        public string Imprimir_Tabla()
        {
            return $"Id #{id_Barco} | Matricula: {matricula} ";
        }

    }
}

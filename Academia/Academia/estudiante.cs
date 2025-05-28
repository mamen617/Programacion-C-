using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia
{
    public class estudiante
    {
        string nombre;
        string apellido;
        string dni;

        //Constructor___________________________________
        public estudiante(string nombre, string apellido, string dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
        }
    }
}

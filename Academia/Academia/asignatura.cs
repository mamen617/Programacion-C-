using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia
{
    public class asignatura
    {
        public string codAsignatura { get; set; }
        public string nombreAsignatura { get; set; }

        public asignatura(string codAsignatura, string nombreAsignatura)
        {
            this.codAsignatura = codAsignatura;
            this.nombreAsignatura = nombreAsignatura;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia
{
    public class matricular
    {
        public matricular(estudiante estu, asignatura asig)
        {
            this.estu = estu;
            this.asig = asig;
        }

        public estudiante estu { get; set; }
        public asignatura asig { get; set; }
  
    }
}
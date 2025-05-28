using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Coches
    {
        string matricula;
        string bastidor;

        public Coches(string b)
        {
            this.bastidor = b;
        }
        public Coches(int xx)
        {
     
        }
        public Coches(string mat, string bas)
        {
            matricula = mat;
            bastidor = bas;       
        }
        public void setMatricula(string matricula)
        {
            this.matricula = matricula;
        }
        public string dameElPescao()
        {
            return this.matricula;
        }
        public string getMatricula()
        {
            return this.matricula;
        }

        public string getBastidor()
        {
            return this.bastidor;
        }
    }
}

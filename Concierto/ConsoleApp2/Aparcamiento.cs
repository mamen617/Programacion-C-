using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Aparcamiento
    {
        Coches[] plazas = new Coches[20];

        public void Aparcar(Coches miCoche, int numPlaza)
        {
            plazas[numPlaza] = miCoche;
        }

        public void desAparcar(int numPlaza)
        {
            plazas[numPlaza] = null;
        }

        public bool comprobarPlaza(int numPlaza)
        {
            if ( plazas[numPlaza] ==  null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

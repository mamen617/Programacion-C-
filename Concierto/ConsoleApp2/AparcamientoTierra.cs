using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class AparcamientoTierra
    {
        List<Coches> plazasTierra;
        String nombreParking = "";

        public AparcamientoTierra()
        {
            plazasTierra = new List<Coches>();
        }
        public AparcamientoTierra(String nombre)
        {
            plazasTierra = new List<Coches>();
            nombreParking = nombre;
        }
        public void Aparcar(Coches miCoche)
        {
            plazasTierra.Add(miCoche);
        }

        public Boolean desAparcar(String matricula)
        {
            foreach (Coches elCoche in plazasTierra)
            {
                if (elCoche.getMatricula() == matricula)
                {
                    plazasTierra.Remove(elCoche);
                    return true;
                }
                
            }
            return false;
        }

    }
}

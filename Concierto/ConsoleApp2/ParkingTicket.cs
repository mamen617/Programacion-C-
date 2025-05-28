using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ParkingTicket
    {
        Dictionary<int, Coches> plazaTicket;
        private int ticket = 0;

        public ParkingTicket() {
            plazaTicket = new Dictionary<int, Coches>();
        }
        public int Aparcar(Coches coches)
        {
            int miticket = GetNextTicket();
            plazaTicket.Add(miticket, coches) ;

            return miticket;
        }

        public Boolean desAparcar(int miTicket)
        {
            plazaTicket.Remove(miTicket) ;
            return true ;
        }
        public int GetNextTicket()
        {
            return ticket++;
        }
    }
}

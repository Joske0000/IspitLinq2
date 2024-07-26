using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2
{
    public class Racun
    {
        public int BrojRacuna { get; set; }
        public int ProizvodID { get; set; }

        public int Kolicina { get; set; }


        public Racun(int brojRacuna, int proizvodID, int kolicina)
        {
            BrojRacuna = brojRacuna;
            ProizvodID = proizvodID;
            Kolicina = kolicina;
        }

    }
}

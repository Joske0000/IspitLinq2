using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model2
{
    public class Proizvod
    {
        public int ProductID { get; set; }
        public string Naziv { get; set; }

        public Proizvod(int productID, string naziv)
        {
            ProductID = productID;
            Naziv = naziv;
        }

    }
}

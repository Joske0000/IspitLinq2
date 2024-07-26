using System;
using System.Collections.Generic;
using System.Linq;
using Model2;
using System.Text;
using System.Threading.Tasks;

namespace IspitLinq2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Proizvod> ListaProizvoda = new List<Proizvod>
            {
                new Proizvod(1, "Čokolada - za kuhanje"),
                new Proizvod(2, "Lino Lada – Gold"),
                new Proizvod(3, "Papir za pečenje"),
                new Proizvod(4, "Brašno – pšenično"),
                new Proizvod(5, "Šećer – standard"),
            };

            List<Racun> ListaRacuna = new List<Racun>
            {
                new Racun(100, 3, 800),
                new Racun(101, 2, 650),
                new Racun(102, 3, 900),
                new Racun(103, 4, 700),
                new Racun(104, 3, 900),
                new Racun(105, 4, 660),
                new Racun(106, 1, 458),
            };

            var sortirano = (from artikl in ListaProizvoda
                             orderby artikl.Naziv
                             select artikl
                             ).ToList();
            Console.WriteLine("Ovo je popis proizvoda");
            Console.WriteLine("===========================================");

            foreach (var artikl in sortirano)
            {
                Console.WriteLine($"ID: {artikl.ProductID}, Naziv: {artikl.Naziv}");
            }
            Console.WriteLine();

            var ListaSpojenihPodataka = (from racun in ListaRacuna
                                         join proizvod in ListaProizvoda
                                         on racun.ProizvodID equals proizvod.ProductID
                                         select new
                                         {
                                             racun.BrojRacuna,
                                             proizvod.ProductID,
                                             racun.Kolicina
                                         }).OrderBy(x => x.BrojRacuna).ToList();

            Console.WriteLine("Ovo je popis racuna");
            Console.WriteLine("===========================================");
            foreach (var racun in ListaSpojenihPodataka)
            {
                Console.WriteLine($"Broj racuna: {racun.BrojRacuna}, ProductID: {racun.ProductID}, Kolicina: {racun.Kolicina}");
            }

            Console.WriteLine();

            var ListaSpojenihPodataka2 = (from racun in ListaRacuna
                                          join proizvod in ListaProizvoda
                                          on racun.ProizvodID equals proizvod.ProductID
                                          select new
                                          {
                                              proizvod.ProductID,
                                              proizvod.Naziv,
                                              racun.Kolicina
                                          }).OrderBy(x => x.ProductID).ThenBy(x => x.Naziv).ToList();

            Console.WriteLine("Evo popisa nakon pridruzivanja");
            Console.WriteLine("Id Proizvoda                 Naziv Proizvoda                 Kupljena kolicina");
            Console.WriteLine("=======================================================================================");
            foreach (var racun in ListaSpojenihPodataka2)
            {
                Console.WriteLine($"{racun.ProductID},                          {racun.Naziv},                     {racun.Kolicina}");
            }
            Console.WriteLine();



            Console.ReadKey();
        }
    }
}

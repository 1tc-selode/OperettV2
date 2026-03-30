using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using core;

namespace console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Olvassa be az operett adatokat egy listába
            List<Operett> operettek = Services.GetAll();

            // 1. Hány mű szerepel az adatbázisban?

            //List<int> egyediOperett = new List<int>();
            //foreach (var o in operettek)
            //{
            //    if (!egyediOperett.Contains(o.Muid))
            //    {
            //        egyediOperett.Add(o.Muid);
            //    }
            //}

            int egyediOperettDb = operettek
                .Select(o => o.Muid)
                .Distinct()
                .Count();

            //Console.WriteLine($"1. Művek száma: {egyediOperett.Count()}");
            Console.WriteLine($"1. Művek száma: {egyediOperettDb}");



            // 2. Hány operettet mutattak be az 1920-as években?
            //list<int> egyedioperett20asevek = new list<int>();
            //foreach (var o in operettek)
            //{
            //    if (!egyedioperett20asevek.contains(o.muid) && o.ev >= 1920 && o.ev <= 1929)
            //    {
            //        egyedioperett20asevek.add(o.muid);
            //    }
            //}

            int huszasEvekOperettDb = operettek
                .Where(o => o.Ev>=1920 && o.Ev<=1930)
                .Select(o => o.Muid)
                .Distinct()
                .Count();

            //Console.WriteLine($"2. 1920-as években bemutatottak száma: {egyediOperett20asEvek.Count}");
            Console.WriteLine($"2. 1920-as években bemutatottak száma: {huszasEvekOperettDb}");



            // 3. Kérjen be egy operett címet, majd írja ki az operett adatait és alkotóit.
            Console.Write("3. Adjon meg egy operett címet: ");
            string keresettCim = Console.ReadLine();

            //bool talalt = false;
            //foreach (var o in operettek)
            //{
            //    if (o.Cim.Equals(keresettCim, StringComparison.OrdinalIgnoreCase))
            //    {
            //        Console.WriteLine($"Cím: {o.Cim}, Év: {o.Ev}, Alkotó: {o.Nev}, Felvonások: {o.Felvonas}, Színház: {o.Szinhaz}");
            //        talalt = true;
            //    }
            //}
            //if (!talalt)
            //    Console.WriteLine("Nincs ilyen operett az adatbázisban.");

            List<Operett> talalt = operettek
                .Where(o => o.Cim == keresettCim)
                .GroupBy(o => new { o.Cim, o.Ev})
                .Select(g => g.First())
                .ToList();
            if (talalt != null)
            {
                foreach (Operett o in talalt)
                {
                    Console.WriteLine(o);
                }
            }
            else
            {
                Console.WriteLine("nincs talalat");
            }

            // 5. Hány operett rendelkezik 3-nál több felvonással?
            List<int> egyediOperett3nalTobbFelvonas = new List<int>();
            foreach (var o in operettek)
            {
                if (!egyediOperett3nalTobbFelvonas.Contains(o.Muid) && Services.TobbMintHaromFelvonasos(o))
                {
                    egyediOperett3nalTobbFelvonas.Add(o.Muid);
                }
            }
            Console.WriteLine($"5. 3-nál több felvonásos operettek száma: {egyediOperett3nalTobbFelvonas.Count()}");
        }
    }
}

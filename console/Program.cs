using System;
using System.Collections.Generic;
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
            List<int> egyediOperett = new List<int>();

            foreach (var o in operettek)
            {
                if (!egyediOperett.Contains(o.Muid))
                {
                    egyediOperett.Add(o.Muid);
                }
            }
            Console.WriteLine($"1. Művek száma: {egyediOperett.Count()}");


            // 2. Hány operettet mutattak be az 1920-as években?
            List<int> egyediOperett20asEvek = new List<int>();
            foreach (var o in operettek)
            {
                if (!egyediOperett20asEvek.Contains(o.Muid) && o.Ev >= 1920 && o.Ev <= 1929)
                {
                    egyediOperett20asEvek.Add(o.Muid);
                }
            }
            Console.WriteLine($"2. 1920-as években bemutatottak száma: {egyediOperett20asEvek.Count}");


            // 3. Kérjen be egy operett címet, majd írja ki az operett adatait és alkotóit.
            Console.Write("3. Adjon meg egy operett címet: ");
            string keresettCim = Console.ReadLine();
            bool talalt = false;
            foreach (var o in operettek)
            {
                if (o.Cim.Equals(keresettCim, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Cím: {o.Cim}, Év: {o.Ev}, Alkotó: {o.Nev}, Felvonások: {o.Felvonas}, Színház: {o.Szinhaz}");
                    talalt = true;
                }
            }
            if (!talalt)
                Console.WriteLine("Nincs ilyen operett az adatbázisban.");


            // 5. Hány operett rendelkezik 3-nál több felvonással?
            int haromnalTobbFelvonas = 0;
            foreach (var o in operettek)
            {
                if (Services.TobbMintHaromFelvonasos(o))
                {
                    haromnalTobbFelvonas++;
                }
            }
            Console.WriteLine($"5. 3-nál több felvonásos operettek száma: {haromnalTobbFelvonas}");
        }
    }
}

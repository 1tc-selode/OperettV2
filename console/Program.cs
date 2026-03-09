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
            int muSzam = 0;
            foreach (var o in operettek)
                muSzam++;
            Console.WriteLine($"1. Művek száma: {muSzam}");

            // 2. Hány operettet mutattak be az 1920-as években?
            int ev1920as = 0;
            foreach (var o in operettek)
                if (o.Ev >= 1920 && o.Ev <= 1929)
                    ev1920as++;
            Console.WriteLine($"2. 1920-as években bemutatottak: {ev1920as}");

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
            int haromFelett = 0;
            foreach (var o in operettek)
                if (Services.TobbMintHaromFelvonasos(o))
                    haromFelett++;
            Console.WriteLine($"5. 3-nál több felvonásos operettek száma: {haromFelett}");
        }
    }
}

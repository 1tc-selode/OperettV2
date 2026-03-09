using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core
{
    public class Operett
    {
        public string Nev { get; set; } // Alkotó neve a JOIN-ból
        public int Alkotoid { get; set; }
        public int Muid { get; set; }
        public string Tipus { get; set; }
        public string Cim { get; set; }
        public string Eredeti { get; set; }
        public string Szinhaz { get; set; }
        public int Felvonas { get; set; }
        public int Kep { get; set; }
        public int Ev { get; set; }

        public Operett(string nev, string alkoto, string muid, string tipus, string cim, string eredeti, string szinhaz, string felvonas, string kep, string ev)
        {
            Nev = nev;
            Alkotoid = int.Parse(alkoto);
            Muid = int.Parse(muid);
            Tipus = tipus;
            Cim = cim;
            Eredeti = eredeti;
            Szinhaz = szinhaz;
            Felvonas = !string.IsNullOrEmpty(felvonas) ? int.Parse(felvonas) : 0;
            Kep = !string.IsNullOrEmpty(kep) ? int.Parse(kep) : 0;
            Ev = !string.IsNullOrEmpty(ev) ? int.Parse(ev) : 0;
        }

        public override string ToString()
        {
            return $"{Cim} ({Ev}) - {Szinhaz}, {Felvonas} felvonás";
        }
    }
}

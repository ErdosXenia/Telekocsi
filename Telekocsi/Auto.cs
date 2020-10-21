using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telekocsi
{
    class Auto
    {
        public string IndulasA { get;private set; }
        public string CelA { get;private set; }
        public string Rendszam { get;private set; }
        public string Telefonszam { get;private set; }
        public int Ferohely { get;private set; }
        public string Utvonal { get;private set; }

        public Auto(string sor)
        {
            string[] a = sor.Split(';');
            IndulasA = a[0];
            CelA = a[1];
            Rendszam = a[2];
            Telefonszam = a[3];
            Ferohely = Convert.ToInt32(a[4]);
            Utvonal = IndulasA + "-" + CelA;
        }
    }
}

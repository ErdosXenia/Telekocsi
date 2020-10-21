using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Telekocsi
{
    class Program
    {
        static List<Auto> autok = new List<Auto>();
        static List<Igeny> igenyek = new List<Igeny>();

        static void Beolvas()
        {
            StreamReader sr1 = new StreamReader("autok.csv");
            sr1.ReadLine();
            while (!sr1.EndOfStream)
            {
                autok.Add(new Auto(sr1.ReadLine()));
            }
            sr1.Close();

            StreamReader sr2 = new StreamReader("igenyek.csv");
            sr2.ReadLine();
            while (!sr2.EndOfStream)
            {
                igenyek.Add(new Igeny(sr2.ReadLine()));
            }
            sr2.Close();
        }

        static void feladat2()
        {
            Console.WriteLine("2. Feladat: ");
            Console.WriteLine("   {0} hirdető adatát tartalmazza a fájl.",autok.Count());
        }

        static void feladat3()
        {
            Console.WriteLine("\n3. Feladat: ");
            int sum = 0;
            foreach (var a in autok)
            {
                if (a.IndulasA=="Budapest" && a.CelA=="Miskolc")
                {
                    sum += a.Ferohely;  
                }
            }
            Console.WriteLine("   Összesen {0} férőhelyet hirdettek az autósok Budapestről Miskolcra.",sum);
        }

        static void feladat4()
        {
            Console.WriteLine($"\n4. Feladat: ");
            /*Dictionary<string, int> utvonalak = new Dictionary<string, int>();
            foreach (var a in autok)
            {
                if (!utvonalak.ContainsKey(a.Utvonal))
                {
                    utvonalak.Add(a.Utvonal, a.Ferohely);
                }
                else
                {
                    utvonalak[a.Utvonal] += a.Ferohely;
                }
            }*/
            int max = 0;
            string utv = "";
            /*foreach (var u in utvonalak)
            {
                if (u.Value>max)
                {
                    max = u.Value;
                    utv = u.Key;
                }
            }*/

            var utvonalak = from a in autok
                            orderby a.Utvonal
                            group a by a.Utvonal into temp
                            select temp;

            foreach (var ut in utvonalak)
            {
                int fh = ut.Sum(x => x.Ferohely);
                if (max < fh)
                {
                    max = fh;
                    utv = ut.Key;
                }
            }
            Console.WriteLine($"   {max} - {utv}");
        }

        static void feladat5()
        {
            Console.WriteLine("\n5. feladat:");
            
            foreach (var i in igenyek)
            {
                /*foreach (var a in autok)
                {
                    if (i.IndulasI==a.IndulasA && i.CelI==a.CelA)
                    {
                        Console.WriteLine($"   {i.Azonosito} => {a.Rendszam}");    
                    }
                }*/
                int w = 0;
                while (w < autok.Count &&
                    !( i.IndulasI == autok[w].IndulasA 
                    && i.CelI == autok[w].CelA && i.Szemelyek <= autok[w].Ferohely))
                {
                    w++;
                }
                if (w<autok.Count)
                {
                    Console.WriteLine($"   {i.Azonosito} => {autok[w].Rendszam}");
                }
            }
        }

        static void feladat6()
        {

            StreamWriter sw = new StreamWriter("utasuzenetek.txt");

            foreach (var i in igenyek)
            {
                
                int w = 0;
                while (w < autok.Count &&
                    !(i.IndulasI == autok[w].IndulasA
                    && i.CelI == autok[w].CelA
                    && i.Szemelyek <= autok[w].Ferohely))
                {
                    w++;
                }
                if (w < autok.Count)
                {
                    sw.WriteLine($"{i.Azonosito}: Rendszám: {autok[w].Rendszam}, Telefonszám: {autok[w].Telefonszam}");
                }
                else
                {
                    sw.WriteLine($"{i.Azonosito}: Sajnos nem sikerült autót találni.");
                }

            }
            sw.Close();
        }

        static void Main(string[] args)
        {
            Beolvas();
            feladat2();
            feladat3();
            feladat4();
            feladat5();
            feladat6();
            Console.ReadKey();
        }
    }
}

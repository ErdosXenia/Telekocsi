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
            List<string> utvonalak = new List<string>();
            /*int max = 0;
            string utvonal;
            foreach (var a in autok)
            {
                if (max < a.Ferohely)
                {
                    max = a.Ferohely;
                    utvonal = a.IndulasA + "-" + a.CelA;
                }
                
            }
            /*Console.Write("A legtöbb férőhelyet ({0}-ot)", max);

            foreach (var a in autok)
            {
                if (a.Ferohely==max)
                {
                    Console.WriteLine($"a {a.IndulasA}-{a.CelA} útvonalon ajánlották fel a hirdetők");
                }
            }*/

        }

        static void feladat5()
        {
            Console.WriteLine("\n5. feladat:");
            foreach (var i in igenyek)
            {
                foreach (var a in autok)
                {
                    if (i.IndulasI==a.IndulasA && i.CelI==a.CelA)
                    {
                        Console.WriteLine($"   {i.Azonosito} => {a.Rendszam}");
                    }
                }
            }
        }

        static void feladat6()
        {

            StreamWriter sw = new StreamWriter("utasuzenetek.txt");
            
            foreach (var a in autok)
            {
                foreach (var i in igenyek)
                {
                    
                    if (i.IndulasI != a.IndulasA && i.CelI != a.CelA)
                    {
                        
                        sw.WriteLine($"{i.Azonosito}: Sajnos nem sikerült autót találni.");
                    }
                    else
                    {
                        sw.WriteLine($"{i.Azonosito}: Rendszám: {a.Rendszam}, Telefonszám: {a.Telefonszam}");
                    }
                }
            }
            sw.Close();
        }

        static void Main(string[] args)
        {
            Beolvas();
            feladat2();
            feladat3();
            //feladat4();
            feladat5();
            feladat6();
            Console.ReadKey();
        }
    }
}

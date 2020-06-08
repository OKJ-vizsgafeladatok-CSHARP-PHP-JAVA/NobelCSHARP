using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NobelGYAK
{
    class Nobel
    {
        public int ev { get; set; }
        public string tipus { get; set; }
        public string keresztnev { get; set; }
        public string vezeteknev { get; set; }
        public string teljesNev => keresztnev + " " + vezeteknev;

        public Nobel(int ev, string tipus, string keresztnev, string vezeteknev) // jobb gomb->quick actions and refactorings....
        {
            this.ev = ev;
            this.tipus = tipus;
            this.keresztnev = keresztnev;
            this.vezeteknev = vezeteknev;
        }

    }

    class Program
    {
        static List<Nobel> dijList = new List<Nobel>();
        static void Main(string[] args)
        {
            #region 2. feladat
            StreamReader sr = new StreamReader(File.OpenRead("nobel.csv"));//csak "-t fogad el
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] split = sr.ReadLine().Split(';');//csak '-t fogad el
                dijList.Add(new Nobel(
                    Convert.ToInt32(split[0]),
                    split[1],
                    split[2],
                    split[3]
                    ));
            }
            sr.Close();
            #endregion

            #region 3.-4. feladat
            var irodalmi2017 = "";

            foreach (var item in dijList)
            {
                if (item.teljesNev.Equals("Arthur B. McDonald"))
                {
                    Console.WriteLine("3. feladat: "+item.tipus);
                }
                if (item.tipus.Equals("irodalmi")&&item.ev==2017)
                {
                    irodalmi2017 = item.teljesNev;
                }
            }
            Console.WriteLine("4. feladat: "+irodalmi2017);
            #endregion

            #region 5. feladat
            Console.WriteLine("5. feladat: ");
            foreach (var item in dijList)
            {
                if (item.tipus.Equals("béke") && item.ev>1990&&item.vezeteknev=="")
                {
                    Console.WriteLine("\t"+item.ev+": "+item.teljesNev);
                }
            }
            #endregion

            #region 6. feladat
            Console.WriteLine("6. feladat: ");
            foreach (var item in dijList)
            {
                if (item.teljesNev.ToLower().Contains("curie"))
                {
                    Console.WriteLine("\t"+item.ev+": "+item.teljesNev+"({0})",item.tipus);
                }
            }
            #endregion

            #region 7. feladat
            Console.WriteLine("7. feladat:");
            var stat = dijList.GroupBy(x => x.tipus)
                    .Select(o => new
                    {
                        tipus=o.Key,
                        db=o.Count()
                    }
                );
            foreach (var item in stat)
            {
                Console.WriteLine("\t"+item.tipus+" "+item.db);
            }
            #endregion

            #region 8. feladat:
            Console.WriteLine("8. feladat: orvosi.txt");
            using (StreamWriter sw=new StreamWriter(File.Create("orvosi.txt")))
            {
                foreach (var item in dijList)
                {
                    if (item.tipus.Equals("orvosi"))
                    {
                        sw.WriteLine(item.ev + ":" + item.teljesNev);
                    }
                }
                sw.Close();
            }
            #endregion

            Console.ReadKey();
        }
    }
}

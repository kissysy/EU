using System;
using System.IO;

namespace EU
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] adatok = File.ReadAllLines("EUcsatlakozas.txt");
            string[,] tordeltadatok = new string[adatok.Length, 2];
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] spliter = adatok[i].Split(';');
                tordeltadatok[i, 0] = spliter[0];
                tordeltadatok[i, 1] = spliter[1];
            }


            //3.feladat
            int osszesszam = 0;
            int csatlakozottak = 0;
            string csatlakozottdatum = "";
            bool volte = false;
            int legnagyobbhonap = 0, legnagyobbev = 0, legnagyobbnap = 0; string utoljaracsatlakozott = "";
            for (int i = 0; i < adatok.Length; i++)
            {
                string[] split = tordeltadatok[i, 1].Split('.');
                int ev = Convert.ToInt32(split[0]);
                int honap = Convert.ToInt32(split[1]);
                int nap = Convert.ToInt32(split[2]);
                if (ev <= 2018)
                {
                    osszesszam++;
                }

                if (ev == 2007) //ez a 4. feladat megoldása
                {
                    csatlakozottak++;
                }

                if (tordeltadatok[i, 0] == "Magyarország") //5.feladat megoldása
                {
                    csatlakozottdatum = tordeltadatok[i, 1];
                }

                if (honap == 05)//6.feladat megoldása
                {
                    volte = true;
                }

                if (legnagyobbev <= ev)
                {
                    if (legnagyobbhonap <= honap)
                    {
                        if (legnagyobbnap <= nap)
                        {
                            legnagyobbev = ev;
                            legnagyobbhonap = honap;
                            legnagyobbnap = nap;
                            utoljaracsatlakozott = tordeltadatok[i, 0];
                        }
                    }
                }

            }
            Console.WriteLine("3.feladat:EU tagállamainak száma :{0} db", osszesszam);
            //4.feladat
            Console.WriteLine("4.feladat:2007-ben {0} ország csatlakozott.", csatlakozottak);
            //5.feladat
            Console.WriteLine("5.feladat:Magyarország csatlakozásának dátuma:{0}", csatlakozottdatum);
            //6.feladat
            if (volte == true)
                Console.WriteLine("6.feladat:Májusban volt csatlakozás!");
            else
                Console.WriteLine("6.feladat: Májusban nem volt csatlakozás!");
            //7.feladat
            Console.WriteLine("7.feladat: Legutoljára csatlakozott ország :{0}!", utoljaracsatlakozott);
            //8.feladat
            Console.WriteLine("8.feladat: statisztika");
            int[,] statisztika = new int[adatok.Length, 2];
            int szamolo = 0;
            for (int i = 0; i < adatok.Length; i++)
            {
                int jodb = 0;
                string[] split = tordeltadatok[i, 1].Split('.');
                int ev = Convert.ToInt32(split[0]);
                int honap = Convert.ToInt32(split[1]);
                int nap = Convert.ToInt32(split[2]);
                int y = 0;
                string[] spliter = tordeltadatok[0, 1].Split('.');
                int kezdoev = Convert.ToInt32(spliter[0]);
               
                for (y = 0; y <= 27; y++)
                {
                    if (ev == statisztika[y, 0])
                    {
                        statisztika[y, 1]++;
                        jodb++;
                    }
                }
                if (jodb == 0)
                {
                    szamolo++;
                    statisztika[szamolo, 0] = ev;
                    statisztika[szamolo, 1] = 1;

                }
            }

            for (int i = 0; i < szamolo + 1; i++)
            {
                Console.WriteLine("{0} - {1} ország", statisztika[i, 0], statisztika[i, 1]);
            }




            Console.ReadLine();






        }
    }
}
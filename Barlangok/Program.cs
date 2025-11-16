namespace Barlangok
{
    internal class Program
    {
        static Barlang[] barlangok = new Barlang[1000];
        static void Main(string[] args)
        {
            int barlangDb = Feladat3("barlangok.txt");
            Feladat4(barlangDb);
            Feladat5(barlangDb);
            Feladat6(barlangDb);
        }

        static public int Feladat3(string fajlnev)
        {

            using (StreamReader sr = new StreamReader(fajlnev))
            {
                sr.ReadLine();
                int i = 0;
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    Barlang barlang = new Barlang(sor);
                    barlangok[i] = barlang;
                    i++;
                }
                return i;
            }


        }

        static public void Feladat4(int db)
        {
            Console.WriteLine($"4. feladat: Barlangok száma: {db}");
        }

        static public void Feladat5(int db)
        {
            int i = 0;
            int miskolcidb = 0;
            double melysegSum = 0;
            while (i < db)
            {
                if (barlangok[i].Telepules.StartsWith("Miskolc"))
                {
                    melysegSum += barlangok[i].Melyseg;
                    miskolcidb++;
                }
                i++;
            }
            double atlag = melysegSum / miskolcidb; ;
            Console.WriteLine($"5. feladat: Az átlagos mélysége: {atlag:f3} m");
        }

        static public void Feladat6(int db)
        {
            Console.Write("6. feladat: Kérem a védettségi szintet: ");
            string vedettsegiSzint = Console.ReadLine();
            Barlang[] elerhetobarlangok = new Barlang[db];
            int i = 0;
            while (i < db)
            {
                elerhetobarlangok[i] = barlangok[i];
                i++;
            }
            var LeghosszabBarlangVedettsegSzerint = elerhetobarlangok.Where(barlang => barlang.Vedettseg == vedettsegiSzint).MaxBy(barlang => barlang.Hossz);
            Console.WriteLine(LeghosszabBarlangVedettsegSzerint);

        }
    }
}

using System;

namespace DefaultAgurmenteSampe
{
    class Program
    {
        static void Main(string[] args)
        {
            int z1 = 5, z2 = 10, z3 = 15;


            int zahlWithDefault = default;
            Console.WriteLine(zahlWithDefault);

            long ergebnis = Summe(z1, z2, z3);
            long ergebnis2 = Summe(z1, zahl2: z2, zahl3: z3);
            long ergebnis2a = Summe(z1,  zahl3: z3, zahl2: z2);
            long ergebnis3 = Summe(z1, zahl2: z2 , z3);
            long ergebnis4 = Summe(123);


            Console.ReadLine();
        }

        public static long Summe(int zahl1, int zahl2 = default, int zahl3 = default)
        {
            return zahl1 + zahl2 + zahl3;
        }


    }
}

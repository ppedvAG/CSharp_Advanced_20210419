using System;

namespace CSharp70
{
    class Program
    {
        static void Main(string[] args)
        {
            int myAge; //
            int myConvertedNumber;

            SetReferenceVariable(out myAge);
            Console.WriteLine($"Das Alter der Variable myAge ist: {myAge}");
            //Console.ReadLine();

            string stringZahl = "12345";
            
            if (int.TryParse(stringZahl, out myConvertedNumber))
            {
                Console.WriteLine($"Die Konventierung hat geklappt {myConvertedNumber}");
            }
            else
                Console.WriteLine($"Eingabe-String war nicht valide");




            int[] zahlen = { 5, 7, 434, 85, 2_3, 777, -12 };


            //ERhalte die Speicheradresse von zahl[n] 
            ref int position = ref Zahlensuche(23, zahlen);

            //Durch die Speicheradresse wird das Zahlen-Array manipuliert.
            position = 100_000_000;

            Console.WriteLine(zahlen[5]);
            Console.ReadLine();
        }


        static void SetReferenceVariable (out int alter)
        {
            alter = 31;
        }

        static ref int Zahlensuche (int gesuchteZahl, int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                    return ref zahlen[i];
            }

            throw new IndexOutOfRangeException();
        }
    }
}

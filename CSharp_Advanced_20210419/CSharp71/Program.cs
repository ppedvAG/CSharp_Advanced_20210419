using System;

namespace CSharp71
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string strEingabe = "Hallo Welt!";
            Print<string>(strEingabe);

            int intEingabe = 12345;
            Print<int>(intEingabe);

            DateTime currentTime = DateTime.Now;
            Print<DateTime>(currentTime);

            Console.ReadLine();
        }

        static void Print<T> (T input)
        {
            switch (input)
            {
                case int i:
                    Console.WriteLine($"Inputwert ist ein Integer: {i}");
                    break;
                case string str:
                    Console.WriteLine($"Inputwert ist ein Integer: {str}");
                    break;
                case DateTime dat:
                    Console.WriteLine($"Inputwert ist ein Integer: {dat.ToString()}");
                    break;
                default:
                    Console.WriteLine($"Typ konnte nicht gefunden werden");
                    break;
            }
        }
    }
}

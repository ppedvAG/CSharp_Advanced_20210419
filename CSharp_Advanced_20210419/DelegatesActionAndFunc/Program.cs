using System;

namespace DelegatesActionAndFunc
{
    class Program
    {
        delegate int NumbChange(int num); //Definieren eines Delegate - Typs

        static void Main(string[] args)
        {
            NumbChange nc1 = new NumbChange(AddNmberWith12);
            int result = nc1(15);


            nc1 += SubNumberWith13;
            result = nc1(15);


            nc1 -= AddNmberWith12;
            result = nc1(15);

            Action a1 = new Action(VoidMethodeWithoutParams);

            Action<int, int, int> a3 = AddNums;
            a3 += AddNums;

            a3(33, 22, 11);

            Func<int, int, int> rechnerFunc = Add; //Bei Func ist der letzte Datentyp der Rückgabe-Datentyp

            result = rechnerFunc(33, 22);
        }

        public static int Add(int z1, int z2)
        {
            return z1 + z2;
        }

        public static int AddNmberWith12(int number)
        {
           return number += 12;
        }

        public static int SubNumberWith13(int number)
        {
            return number -= 13;
        }

        public static void VoidMethodeWithoutParams()
        {
            Console.WriteLine("Hello world!");
        }

        public static void AddNums(int a, int b, int c)
        {
            int result = a + b + c;

            Console.WriteLine($"{result}");
        }
    }
}

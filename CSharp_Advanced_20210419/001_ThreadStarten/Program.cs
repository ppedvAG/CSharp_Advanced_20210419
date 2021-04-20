using System;
using System.Threading;

namespace _001_ThreadStarten
{
    class Program
    {
        static void Main(string[] args)
        {

            //System.Threading
            Thread thread = new Thread(MacheEtwasInEinemThread);
            thread.Start();


            //Wollen warten, bis Thread zueende ist
            thread.Join();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("O");
            }

            Console.ReadLine();
        }

        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("#");
            }
        }
    }
}

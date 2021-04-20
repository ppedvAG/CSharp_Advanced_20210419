using System;
using System.Threading;

namespace ThreadMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart parameterizedThread = new ParameterizedThreadStart(MacheEtwasInEinemThread);
            Thread thread = new Thread(parameterizedThread);

            thread.Start(123);
            thread.Join();


            for (int i = 0; i < 100; i++)
            {
                Console.Write("O");
            }

            Console.WriteLine("Bin fertig!");
            Console.ReadKey();
        }

        private static void MacheEtwasInEinemThread(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                Console.Write("#");
            }
        }
    }
}

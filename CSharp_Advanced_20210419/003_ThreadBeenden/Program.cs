using System;
using System.Threading;

namespace _003_ThreadBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(MachEtwas);
            t.Start();

            Thread.Sleep(3000);
            //t.Abort(); obselete
            t.Interrupt();

            Console.WriteLine("Hello World!");
        }


        private static void MachEtwas()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("zZzZZ");
                }
            }
            catch
            {

            }

        }
    }

   
}

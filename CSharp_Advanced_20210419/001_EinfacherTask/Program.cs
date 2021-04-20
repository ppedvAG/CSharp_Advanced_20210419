using System;
using System.Threading;
using System.Threading.Tasks;

namespace _001_EinfacherTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task easyTask = new Task(IchMacheWasImTask);
            easyTask.Start();
            easyTask.Wait(); //Thread.Join 
            
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("*");
            }

            Console.ReadKey();
        }

        private static void IchMacheWasImTask()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Console.Write("#");
            }
        }
    }
}

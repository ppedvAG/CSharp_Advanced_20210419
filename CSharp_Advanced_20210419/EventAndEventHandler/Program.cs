using System;
using System.Threading.Tasks;
using System.Threading;

namespace EventAndEventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessBusinessLogic pbl = new ProcessBusinessLogic();
            pbl.ProcessCompleted += Pbl_ProcessCompleted;
            pbl.ProcessInWorking += Pbl_ProcessInWorking;


            Task myTask = Task.Run(pbl.StartProcess);



            ProcessBusinessLogic2 pbl2 = new ProcessBusinessLogic2();
            pbl2.ProcessCompleted += Pbl2_ProcessCompleted;
            pbl2.ProcessCompletedNew += Pbl2_ProcessCompletedNew;
            pbl2.StartProcess();


        }

        private static void Pbl_ProcessInWorking(int processBarValue)
        {
            Console.WriteLine($"Aktuelle Prozentzahl: {processBarValue}");
        }

        private static void Pbl2_ProcessCompletedNew(object sender, EventArgs e)
        {
            MyEventArg myEventArg = (MyEventArg)e;

            Console.WriteLine($"Bin fertig {myEventArg.Uhrzeit.ToString()}");
        }

        private static void Pbl2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Liebe Grüße von Pbl_ProcessCompleted()");
        }

        private static void Pbl_ProcessCompleted()
        {
            Console.WriteLine("Liebe Grüße von Pbl_ProcessCompleted()");
        }
    }
}

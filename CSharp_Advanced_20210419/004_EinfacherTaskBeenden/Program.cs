using System;
using System.Threading;
using System.Threading.Tasks;

namespace _004_EinfacherTaskBeenden
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Task task = Task.Factory.StartNew(MeineMethodeMitAbbrechen, cts); //CancellationToke -> Referenz wird übergeben (Point)

            Thread.Sleep(10000);
            Console.WriteLine("Jetzt wird der Task geschlossen");

            cts.Cancel(); //Task wird mit Cancel geschlossen
            Console.ReadKey();
        }


        private static void MeineMethodeMitAbbrechen(object param)
        {
            CancellationTokenSource source = (CancellationTokenSource)param;

            while(true)
            {
                Console.WriteLine("zzzz.zzzzz....zz");
                Thread.Sleep(50);

                if (source.IsCancellationRequested)
                    break;
            }
        }
    }


}

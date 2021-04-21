using System;
using System.Threading.Tasks;

namespace TaskErgebnisAnContinueTaskÜbergeben
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> task = Task.Run(DayTime);

            //task.Wait();
            task.ContinueWith(abc => ShowDayTime(abc.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(task => ForErrorHandling(), TaskContinuationOptions.OnlyOnFaulted);
            Console.ReadLine();
        }

        public static string DayTime()
        {
            DateTime date = DateTime.Now;

            return date.Hour > 17
                ? "evening"
                : date.Hour > 12
                ? "afternoon"
                : "morning";
        }

        public static void ShowDayTime (string result)
        {
            Console.WriteLine(result);
        }

        public static void ForErrorHandling()
        {

        }
    }
}

using System;
using System.Threading.Tasks;

namespace _006_Verketten_von_Tasks_mithilfe_von_Fortsetzungstasks
{
    class Program
    {
        public static void Main(string[] args)
        {
            Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek); // ()=> ist eine anonyme Methode
            taskA.Wait();

            //await = warten ContinueTask fertig ist. 
            taskA.ContinueWith(antecedent => Console.WriteLine($"Today is {antecedent.Result}.")); //taskA.Result
             
            //Task<DayOfWeek> taskAlternativ = Task.Run(WhatDayIsToday)

            //Task<DayOfWeek> dayOfWeekResult = Task.Run(() => DateTime.Today.DayOfWeek);
            //Console.WriteLine($"{dayOfWeekResult}");

            Console.WriteLine("Alles soweit fertig!");

            Console.ReadKey();
        }


        public static DayOfWeek WhatDayIsToday()
        {
            return DateTime.Today.DayOfWeek;
        }
    }
}

using System.Collections.Generic;
using System;
using System.Threading.Tasks;

public class WhenAllExample
{
    public static void Main()
    {
        List<Task<int>> tasks = new List<Task<int>>(); // Eine Liste von Tasks, die einen Rückgabewert zurück geben
        
        
        for (int ctr = 1; ctr <= 10; ctr++)
        {
            int baseValue = ctr;
            tasks.Add(Task.Factory.StartNew(b => (int)b * (int)b, baseValue));
        }

        
        Task<int[]> results =  Task.WhenAll(tasks); //Es geht nur weiter, wenn alle Tasks fertig abgearbeitet sind

        int sum = 0;
        for (int ctr = 0; ctr <= results.Result.Length - 1; ctr++)
        {
            var result = results.Result[ctr];
            Console.Write($"{result} {((ctr == results.Result.Length - 1) ? "=" : "+")} ");
            sum += result;
        }

        Console.WriteLine(sum);
    }
}
// The example displays the similar output:
//    1 + 4 + 9 + 16 + 25 + 36 + 49 + 64 + 81 + 100 = 385
using System;
using System.Threading.Tasks;

namespace _002_TaskMitParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new();

            //Katze wird als Parameter übergeben. 
            //Task erwartet einen string als ReturnValue 
            Task<string> task = Task.Factory.StartNew(GibtDatumMitInput, katze); //Intern wird Task.Run(); 

            Task<string> task1 = Task.Run<string>(() => GibtDatumMitInput(katze));

            Task<string> easyTask = new Task<string>(() => GibtDatumMitInput(katze));
            easyTask.Start();

            task.Wait();
            task1.Wait();
            easyTask.Wait();


            Console.WriteLine(task.Result); //Datumausgabe 

            Console.ReadKey();


        }
        private static string GibtDatumMitInput(object input)
        {
            Katze katze = null;

            if (input is Katze)
                katze = (Katze)input;

            Console.WriteLine(katze.Name);

            return DateTime.Now.ToLongDateString();
        }
    }

    

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}

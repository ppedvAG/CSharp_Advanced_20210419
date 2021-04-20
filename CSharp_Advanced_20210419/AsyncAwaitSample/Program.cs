using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task task = Task.Run(SubMethode);
            task.Wait();

            await Task.Run(SubMethode);

        }


        public static async Task SubMethode()
        {
            //Normaler Task
            Task easyTask = Task.Run(MethodeOhneReturnwert);
            easyTask.Wait();

            await Task.Run(MethodeOhneReturnwert);


            //Mit Returnwerten
            Task<string> taskWithReturnValue = Task.Run(MethodeMitReturnwert);
            taskWithReturnValue.Wait();

            string retStr = await Task.Run(MethodeMitReturnwert);
        }

        public static void MethodeOhneReturnwert()
        {
            //Mach was
        }


        public static string MethodeMitReturnwert()
        {
            return DateTime.Now.ToString();
        }
    }
}

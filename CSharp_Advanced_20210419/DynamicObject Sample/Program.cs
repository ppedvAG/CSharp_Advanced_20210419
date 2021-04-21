using System;

namespace DynamicObject_Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dynamic bite nicht verwenden. Mit Typisierten Klassen hat man mehr Performance und der Programmierer hat eine besser Übersicht;
            dynamic dynamicObject = new System.Dynamic.ExpandoObject();

            dynamicObject.Haribo = "abc";
            dynamicObject.alksjdbflkjasdfbjk = 123123123;

            

            Console.WriteLine(dynamicObject.Haribo);
            Console.ReadLine();

        }
    }
}

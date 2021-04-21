using System;

namespace DelegateWithCallback
{
    class Program
    {
        public delegate void Del(string message);

        static void Main(string[] args)
        {
            Del handler = new Del(DelegateMthod);

            MethodWithCallback(12, 33, handler);


            Action<string> action = DelegateMthod;
            MethodWithCallback(44, 33, action);

        }

        public static void MethodWithCallback(int param1, int param2, Action<string> callback)
        {
            //Logik die etwas dauern kann. 

            callback("The Number is: " + (param1 + param2).ToString());
        }

        public static void MethodWithCallback(int param1, int param2, Del callback)
        {
            //Logik die etwas dauern kann. 

            //Callback wird immer zum schluss aufgerufen.
            callback("The Number is: " + (param1 + param2).ToString());
        }

        //Wenn Verarbeitung fertig ist, ruft der Callback diese Methode auf
        public static void DelegateMthod(string message)
        {
            Console.WriteLine(message);
        }
    }
}

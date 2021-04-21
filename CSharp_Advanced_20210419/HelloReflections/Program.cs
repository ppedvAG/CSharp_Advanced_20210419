using System;
using System.Reflection;

namespace HelloReflections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lade DLL in Arbeitsspeicher
            Assembly geladeneDll = Assembly.LoadFrom("TrumpTaschenrechner.dll");

            //Ermittle die Klassen Taschenrechner -> TrumpTaschenrechner.Taschenrecher
            Type trumpTaschenrechnerTyp = geladeneDll.GetType("TrumpTaschenrechner.Taschenrechner");

            //Erstelle einen Object-Instanz und zeige auf die Klasse -> TrumpTaschenrechner.Taschenrechner.
            object tr = Activator.CreateInstance(trumpTaschenrechnerTyp);

            //Ermittle Methode mithilfe von trumpTaschenrechnerTyp
            MethodInfo addInfo = trumpTaschenrechnerTyp.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32), typeof(Int32) });

            //Methode wird ausgeführt
            var result = addInfo.Invoke(tr, new object[] { 33, 22 });

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

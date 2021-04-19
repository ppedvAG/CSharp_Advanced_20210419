using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharp80
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await GebeZahlenAus();



            //Exkursus null-Typen

            int? zahl = null;

            float? floatNumber = null; 

            decimal? decimalNumber = null;

            string str = null;
            string str1 = string.Empty;

            if (string.IsNullOrEmpty(str1))
            {

            }

            Console.Write(floatNumber.Value + decimalNumber.ToString() + str);


            if (!zahl.HasValue)
                Console.WriteLine("Zahl ist (null) und hat keinen Wert");

            zahl = 123;


            if (zahl.HasValue)
                Console.WriteLine($"Zahl ist {zahl.Value}");



            //Verbatim-String 

            string myString = $"Die aktuelle Uhrzeit beträgt {DateTime.Now.ToString()}";
            string myOldAndBadString = "Die aktuelle Uhrzeit beträgt " + DateTime.Now.ToString(); //nicht performant. In Schleifen-Konstrukten ist addieren von Strings nicht performant

            myString = "Hallo Welt... \n ich benötige ein Tab-Sequenz \t nach einem Tab geht es weiter \t und weiter....";

            string filePath = "C:\\Windows\\Temp";

            string betterFilePath = @"C:\Windows\Temp";
        }


        //Diese Methode liefert ein Ergebnis-Stream aus.
        public static async IAsyncEnumerable<int> GenerierteZahlen()
        {
            for (int i = 0; i < 20; i++) //shortcut: for + tab + tab 
            {
                await Task.Delay(100);
                yield return i;
            }
        }

        public static async Task GebeZahlenAus()
        {
            await foreach (var zahl in GenerierteZahlen())
                Console.WriteLine(zahl);
        }
    }


    public interface ICar
    {
        string Brandt { get; set; } // -> public string Brandt
        string Typ { get; set; } // -> public string Typ
        DateTime ConstructYear { get; set; } // -> public  DateTime ConstructYear 

        void ShowPS();

        private int PS ()
        {
            return 120;
        }
    }

    public class Car : ICar
    {
        public string Brandt 
        { 
            get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Typ { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime ConstructYear { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void ShowPS()
        {
            ICar car = this;
        }
    }


    public interface IOldInterfaceRules //Altes interface->alle wird public
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }

    public interface INew80Interface
    {
        public void Hallo() //Default-Implementierung
        { 
            GetNumber();
            Console.WriteLine("Hallo Welt");
        }

        public virtual void GutenAbend()
        {
            GetNumber(); 
            Console.WriteLine("Hallo Welt");
        }

        private int GetNumber()
        {
            return 123;
        } //Wird für andere Default-Implementierungen verwendet

        public abstract void GutenMorgen();

        public void Wiederschauen();
    }

    public interface INew80InterfaceB : INew80Interface
    {
        void INew80Interface.GutenMorgen() //Aufrufbar
        {
            Console.WriteLine("INew80InterfaceB.GutenMorgen");
        }
    }

    public class New80Class : INew80Interface
    {
       

        public void Wiederschauen()
        {

        }

        public void GutenMorgen()
        {
            Console.WriteLine("TestMe.GutenMorgen");
        }

        public void TestMe()
        {
            INew80Interface myInterface = (INew80Interface)this;

            myInterface.Hallo(); //Aufruf einer Default-Methode
            myInterface.GutenAbend();
            myInterface.GutenMorgen();
        }

        
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_LockSample
{
    public class Konto
    {
        public decimal Kontostand { get; set; }

        private object lockObject = new object();

        public void Einzahlen(decimal betrag)
        {
            try
            {
                //Nur ein Thread darf diese Part verwenden
                lock (lockObject)
                {
                    Console.WriteLine($"Kontostand vor dem Einzahlen: {Kontostand}");
                    Kontostand += betrag;
                    Console.WriteLine($"Kontostand nach dem Einzahlen: {Kontostand}");
                }

            }
            catch(Exception ex)
            {

            }
        }

        public void Abheben(decimal betrag)
        { 
            try
            {
                //Nur ein Thread darf diese Part verwenden
                lock (lockObject)
                {
                    Console.WriteLine($"Kontostand vor dem Abheben: {Kontostand}");
                    Kontostand -= betrag;
                    Console.WriteLine($"Kontostand nach dem Abheben: {Kontostand}");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

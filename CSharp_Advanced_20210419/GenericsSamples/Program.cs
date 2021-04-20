using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericsSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generische Klassen, die in .NET Core vorkommen

            IList<string> strList = new List<string>(); //typisierte Liste
            strList.Add("eins");


            Hashtable hashtable = new Hashtable();
            hashtable.Add("string", 123123);
            hashtable.Add(Guid.NewGuid(), 123123);
            hashtable.Add(new DateTime(), new StringBuilder());


            IDictionary<Guid, string> dict = new Dictionary<Guid, string>();
            dict.Add(Guid.NewGuid(), "123453dfgsdfg");
            dict.Add(Guid.NewGuid(), "123453dfgsdfg");
            dict.Add(Guid.NewGuid(), "123453dfgsdfg");

            dict.Add(new KeyValuePair<Guid, string>(Guid.NewGuid(), "abcdefgh"));
            
            foreach (KeyValuePair<Guid, string> currenEntry in dict)
            {
                Console.WriteLine(currenEntry.Key.ToString());
                Console.WriteLine(currenEntry.Value);
            }


            DataStore<Guid> data = new DataStore<Guid>();
            data.AddOrUpdate(1, Guid.NewGuid());

            DataStore<int> data1 = new DataStore<int>();
            data.DisplayDefault<DateTime>();


            Console.ReadLine();
        }
    }

    public class DataStore<T>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item; 
        }

        public T GetData(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T);
        }

        public void DisplayDefault<DD>()
        {
            DD item = default(DD);
            Console.WriteLine($"Default value of {typeof(DD)} is {(item == null ? "null" : item.ToString())}.");
        }

    }
}

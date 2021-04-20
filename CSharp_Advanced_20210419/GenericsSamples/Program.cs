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
            ICollection<string> strCollection = new List<string>();

            List<string> strList2 = new List<string>();


            DoTo(strList);
            DoTo(strList2);

            //DoTo1(strList);
            DoTo1(strList2);

            ReadOnlyToDo(strList);
            ReadOnlyToDo(strList2);




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


        public static void ReadOnlyToDo(IEnumerable<string> readonlyArrary)
        {

        }


        public static void DoTo(IList<string> parameter)
        {
            
        }

        public static void Doto(IEnumerable<string> enumerabe)
        {

        }

        
        public static void DoTo1(List<string> parameter)
        {

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


    public abstract class BaseClass
    {
        public abstract void LoadList(IList<string> list);
        public abstract void LoadReadonlyList(IEnumerable<string> readList);
    }

    public interface IBase
    {
         void LoadList(IList<string> list);
         void LoadReadonlyList(IEnumerable<string> readList);
    }

    public class MyImplementionClass : BaseClass
    {
        public override void LoadList(IList<string> list)
        {
            throw new NotImplementedException();
        }


        //Wir machen aus einer Readonly Liste eine Read/Write Liste = -> hier wird die 3te SOLID Regel gebrochen 
        public override void LoadReadonlyList(IEnumerable<string> readList)
        {
            List<string> writeList = new List<string>();

            foreach (string currentString in readList)
            {
                writeList.Add(currentString);
            }

            //writeList arbeite mit dieser Liste weiter -> Brechen die regel von Liskov (Solid)


        }
    }

    public class MyImplementionClass2 : IBase
    {
        public void LoadList(IList<string> list)
        {
           
        }

        public void LoadReadonlyList(IEnumerable<string> readList)
        {
            //WAHRSCHEINLICH -> Würde man hier auch bei einer konventierung zu einer Read/Write die 3te Regel brechen. 
        }
    }
}

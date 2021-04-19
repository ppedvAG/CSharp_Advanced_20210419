using System;

namespace CSharp90
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassPerson classPerson = new(1, "Hannes");
            ClassPerson classPerson1 = new(1, "Hannes");

            Person person = new Person(1, "Hannes");
            Person person1 = new Person(1, "Hannes");

            // Vergleiche Referenztypen (Class)
            if (classPerson == classPerson1) //Ist es die selbe Speicheradresse(Referenz) 
                Console.WriteLine("classPerson == classPerson1");
            else
                Console.WriteLine("classPerson != classPerson1");


            if (classPerson.Equals(classPerson1)) 
            {
                Console.WriteLine("classPerson == classPerson1"); //Hier wurde allerdings ClassPerson.Equals überschrieben
            }
            else
                Console.WriteLine("classPerson != classPerson1");

            //Vergleich von Referenztypen (Record) -> Vergleich beläuft auf Werteebende (Vorimplementiert) 
            if (person == person1)
                Console.WriteLine("person == person1");
            else
                Console.WriteLine("person != person1");

            Console.WriteLine($"In REcords ist die Funktonalität GetHashCode per Default ausimplementiert. {person.GetHashCode}");

            //Flache Kopie + Neu Initialisierung für Name z.b 
            Person brother = person with { Name = "Andreas" }; // Ist auch Init-Konform 



            
            Console.ReadLine();
        }
    }

    public class ClassPerson
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public ClassPerson(int id, string name) //ctor +tab + tab -> shortcut für Konstruktor
        {
            this.Id = id;
            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj is not ClassPerson)
                return false;

            ClassPerson toCheck = (ClassPerson)obj;

            if (this.Id != toCheck.Id)
                return false;

            if (this.Name != toCheck.Name)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode(); //Hier müsste noch mehr implementiert sein. 
        }
    }

    public record Person
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public Person(int id, string name) //ctor +tab + tab -> shortcut für Konstruktor
        {
            this.Id = id;
            this.Name = name;
        }
    }

    public record Employee : Person
    {
        public int Salary { get; init; }

        public Employee(int id, string name, int salary)
           : base(id, name)
        {
            Salary = salary;
        }
    }

    public record Employee123
    {
        public int Salary { get; set; }

        public Employee123(int salary)
           
        {
            Salary = salary;
        }
    }

}

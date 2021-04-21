using System;
using System.Runtime.Serialization.Formatters.Binary; // BinaryFormatter
using System.IO; //Stream / StreamWriter / StreamReader

using System.Xml.Serialization; //XmlSerializer

using Newtonsoft.Json; //JsonConvert

using System.Threading.Tasks;

using SerializeSample.CSV;


namespace SerializeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Vorname = "Max",
                Nachname = "Mustermann",
                Alter = 64,
                Kontostand = 100_000
            };

            #region BinäreSerialisierung


            //SerializationException, wenn ein Fehler bei der Serialisierung entsteht. 
            BinaryFormatter formatter = new BinaryFormatter();

            //Zieldatei
            Stream stream = File.OpenWrite("Person.bin"); 
            formatter.Serialize(stream, person); //BinaryFormatter.Serialize -> obselete
            stream.Close();
            #endregion

            #region Binäre-Datei einlesen und Deserialisiern
            stream = File.OpenRead("Person.bin");
            Person geladenePerson = (Person)formatter.Deserialize(stream);//BinaryFormatter.Deserialize -> obselete
            stream.Close();
            #endregion


            #region XML schreiben
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();
            #endregion

            #region XML lesen
            stream = File.OpenRead("Person.xml");
            Person geladenePersonViaXML = (Person)xmlSerializer.Deserialize(stream);
            #endregion

            #region JSON Serialisierung

            string jsonString = JsonConvert.SerializeObject(person);
            Task task = File.WriteAllTextAsync("Person.json", jsonString);
            task.Wait();

            #endregion

            #region JSON Deserialsierung

            Person jsonPerson = JsonConvert.DeserializeObject<Person>(jsonString);
            #endregion


            #region CSV Schreiben
            person.Serialize("Person.csv");
            #endregion
            person = new Person();
            #region CSV Lesen
            person.Deserialize("Person.csv");
            #endregion
        }
    }

    [Serializable] //Für Binary
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        public int Alter { get; set; }

        [NonSerialized()] //Binary und JSON
        //Funktioniert nicht bei Properties, funktioniert nur bei Field (Class-Member, die Public sind) 
        public decimal Kontostand;
    }


    public class ABC
    {
        [StringLength(50)]
        public string Vorname { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

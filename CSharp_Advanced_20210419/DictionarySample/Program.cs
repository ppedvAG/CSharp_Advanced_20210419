using System;
using System.Collections.Generic;

namespace DictionarySample
{
    class Program
    {
        private static IDictionary<Guid, string> selected = new Dictionary<Guid, string>();

        static void Main(string[] args)
        {
            IDictionary<Guid, string> unselectedEntries = Auswahlliste();
        }


        static IDictionary<Guid, string> GetUnselectedEntries()
        {
            IDictionary<Guid, string> allDictionary = Auswahlliste();


            foreach (KeyValuePair<Guid, string> currentEntry in selected)
            {
                if (allDictionary.ContainsKey(currentEntry.Key))
                    allDictionary.Remove(currentEntry.Key);
            }

            return allDictionary;
        }
        static IDictionary<Guid,string> Auswahlliste ()
        {
            IDictionary<Guid, string> allEntries = new Dictionary<Guid, string>();
            allEntries.Add(Guid.NewGuid(), "Eintrag 1"); //wurde selektiert
            allEntries.Add(Guid.NewGuid(), "Eintrag 2");
            allEntries.Add(Guid.NewGuid(), "Eintrag 3"); //wurde selektiert
            allEntries.Add(Guid.NewGuid(), "Eintrag 4");
            allEntries.Add(Guid.NewGuid(), "Eintrag 5");

            return allEntries;
        }
    }
}

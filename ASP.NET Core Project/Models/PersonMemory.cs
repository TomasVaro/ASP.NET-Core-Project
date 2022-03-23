using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class PersonMemory
    {
        private static List<PersonModel> personList = new List<PersonModel>();
        private static int idCounter;
        public void SeedPersons()
        {
            PersonMemory personMemory = new PersonMemory();
            personMemory.CreatePerson("Nils", "123-456 78 90", "Stockholm");
            personMemory.CreatePerson("Lotta", "098-765 43 21", "Umeå");
            personMemory.CreatePerson("Kalle", "023-987 43 25", "Göteborg");
            personMemory.CreatePerson("Nils", "023-543 78 35", "Göteborg");
            personMemory.CreatePerson("Olle", "070-992 12 84", "Umeå");
            personMemory.CreatePerson("Lisa", "072-375 16 92", "Stockholm");
            personMemory.CreatePerson("Hans", "023-530 32 39", "Uppsala");
            personMemory.CreatePerson("Minerva", "123-937 33 94", "Stockholm");
            personMemory.CreatePerson("Ella", "131-729 38 66", "Göteborg");
        }

        public PersonModel CreatePerson(string name, string phone, string city)
        {
            PersonModel newPerson = new PersonModel(idCounter, name, phone, city);
            personList.Add(newPerson);
            idCounter++;
            return newPerson;
        }

        public bool DeletePerson(PersonModel person)
        {
            bool status = personList.Remove(person);
            return status;
        }

        public List<PersonModel> ReadPerson()
        {
            return personList;
        }

        public PersonModel ReadPerson(int id)
        {
            PersonModel targetPerson = personList.Find(p => p.PersonId == id);
            return targetPerson;
        }
    }
}

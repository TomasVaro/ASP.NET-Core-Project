using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class PersonEdit
    {
        private static List<Person> personList = new List<Person>();
        private static int idCounter;
        public void SeedPersons()
        {
            PersonEdit person = new PersonEdit();
            person.CreatePerson("Nils", "123-456 78 90", "Stockholm");
            person.CreatePerson("Lotta", "098-765 43 21", "Umeå");
            person.CreatePerson("Kalle", "023-987 43 25", "Göteborg");
            person.CreatePerson("Nils", "023-543 78 35", "Göteborg");
            person.CreatePerson("Olle", "070-992 12 84", "Umeå");
            person.CreatePerson("Lisa", "072-375 16 92", "Stockholm");
            person.CreatePerson("Hans", "023-530 32 39", "Uppsala");
            person.CreatePerson("Minerva", "123-937 33 94", "Stockholm");
            person.CreatePerson("Ella", "131-729 38 66", "Göteborg");
        }

        public Person CreatePerson(string name, string phone, string city)
        {
            Person newPerson = new Person(idCounter, name, phone, city);
            personList.Add(newPerson);
            idCounter++;
            return newPerson;
        }

        public bool DeletePerson(Person person)
        {
            bool status = personList.Remove(person);
            return status;
        }

        public List<Person> ReadPerson()
        {
            return personList;
        }

        public Person ReadPerson(int id)
        {
            Person targetPerson = personList.Find(p => p.PersonId == id);
            return targetPerson;
        }
    }
}

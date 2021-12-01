using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class PersonMemoryEF
    {
        private static List<PersonEF> personList = new List<PersonEF>();
        private static int idCounter;
        //public void SeedPersonsEF()
        //{
        //    PersonMemoryEF personMemoryEF = new PersonMemoryEF();
        //    personMemoryEF.CreatePersonEF("Nils", "123-456 78 90", "Stockholm");
        //    personMemoryEF.CreatePersonEF("Lotta", "098-765 43 21", "Umeå");
        //    personMemoryEF.CreatePersonEF("Kalle", "023-987 43 25", "Göteborg");
        //    personMemoryEF.CreatePersonEF("Nils", "023-543 78 35", "Göteborg");
        //    personMemoryEF.CreatePersonEF("Olle", "070-992 12 84", "Umeå");
        //    personMemoryEF.CreatePersonEF("Lisa", "072-375 16 92", "Stockholm");
        //    personMemoryEF.CreatePersonEF("Hans", "023-530 32 39", "Uppsala");
        //    personMemoryEF.CreatePersonEF("Minerva", "123-937 33 94", "Stockholm");
        //    personMemoryEF.CreatePersonEF("Ella", "131-729 38 66", "Göteborg");
        //}

        public PersonEF CreatePersonEF(string name, string phone, string city)
        {
            PersonEF newPerson = new PersonEF();
            //personList.Add(newPerson);

            // Här skall personen sparas till databasen
            //AppDbContext appDbContext = new AppDbContext();
            //appDbContext.People.Add(newPerson);
            idCounter++;
            return newPerson;
        }

        public bool DeletePersonEF(PersonEF person)
        {
            bool status = personList.Remove(person);
            return status;
        }

        public List<PersonEF> ReadPersonEF()
        {
            return personList;
        }

        public PersonEF ReadPersonEF(int id)
        {
            PersonEF targetPerson = personList.Find(p => p.PersonId == id);
            return targetPerson;
        }
    }
}

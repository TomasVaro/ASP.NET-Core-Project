using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    // Person data
    public class Person
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        public static List<Person> personList = new List<Person>();

        public static void CreateListOfPersons()
        {
            personList.AddRange(new List<Person>
            {
               new Person {Name = "Nils", PhoneNumber = "123-456 78 90", City = "Stockholm"},
               new Person {Name = "Lotta", PhoneNumber = "098-765 43 21", City = "Umeå"},
               new Person {Name = "Kalle", PhoneNumber = "123-987 43 25", City = "Göteborg"}
            });
        }

        //public static List<PersonViewModel> AddPeopleToList(PersonViewModel person)
        //{
        //    people.Add( new PersonViewModel { 
        //        Name = person.Name,
        //        PhoneNumber = person.PhoneNumber, 
        //        City = person.City });
        //    return people;
        //}
    }
}

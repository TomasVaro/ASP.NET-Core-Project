using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    // Use to prevent overposting and to use data annotations to validate inputs when creating new person.
    public class CreatePersonViewModel
    {
        static List<Person> people = new List<Person> { };
        public static List<Person> AddPeopleToList(Person person)
        {
            people.Add(new Person
            {
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                City = person.City
            });
            return people;
        }
    }
}

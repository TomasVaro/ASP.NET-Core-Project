using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    // Person data
    public class Person
    {
        private readonly int personId;
        public int PersonId { get { return personId; } }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        public Person(int id, string name, string phone, string city)
        {
            this.personId = id;
            Name = name;
            Phone = phone;
            City = city;
        }
    }
}

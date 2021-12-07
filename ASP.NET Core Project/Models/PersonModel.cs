using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    // Person data
    public class PersonModel
    {
        private readonly int personId;
        public int PersonId { get { return personId; } }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }

        public PersonModel(int id, string name, string phone, string city)
        {
            this.personId = id;
            Name = name;
            Phone = phone;
            City = city;
        }
    }
}

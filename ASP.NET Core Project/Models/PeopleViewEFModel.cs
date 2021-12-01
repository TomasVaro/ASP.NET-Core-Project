using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class PeopleViewEFModel : CreatePersonViewModel
    {
        public List<PersonEF> PersonListViewEF { get; set; }
        public string FilterString { get; set; }
        public PeopleViewEFModel()
        {
            PersonListViewEF = new List<PersonEF>();
        }
    }
}
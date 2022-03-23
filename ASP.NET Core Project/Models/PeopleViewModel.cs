using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    // Container for the information needed in people view
    public class PeopleViewModel : CreatePersonViewModel
    {
        public List<PersonModel> PersonListView { get; set; }
        public string FilterString { get; set; }
        public PeopleViewModel()
        {
            PersonListView = new List<PersonModel>();
        }
    }
}
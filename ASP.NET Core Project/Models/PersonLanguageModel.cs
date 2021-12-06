using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class PersonLanguageModel
    {
        public int PersonId { get; set; }
        public PersonModel Person { get; set; }

        public int LanguageId { get; set; }

        public LanguageModel Language { get; set; }
    }
}
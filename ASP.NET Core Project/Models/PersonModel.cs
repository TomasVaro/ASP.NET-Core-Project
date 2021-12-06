using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class PersonModel
    {
        [Key]
        public int PersonId { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("Phone")]
        [MaxLength(50)]
        public string Phone { get; set; }

        public int CityId { get; set; }
        public CityModel City { get; set; }

        public List<PersonLanguageModel> Languages { get; set; }
    }
}
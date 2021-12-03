using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class CityModel
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        [Column("City")]
        [MaxLength(50)]
        public string City { get; set; }

        public int CountryId { get; set; }
        public CountryModel Country { get; set; }

        public List<PersonModel> People { get; set; }
    }
}

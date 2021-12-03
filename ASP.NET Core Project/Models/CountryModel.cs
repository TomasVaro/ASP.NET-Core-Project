using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [Column("Country")]
        [MaxLength(50)]
        public string Country { get; set; }

        public List<CityModel> Cities { get; set; }
    }
}

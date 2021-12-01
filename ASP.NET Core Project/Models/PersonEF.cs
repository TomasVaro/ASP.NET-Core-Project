using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class PersonEF
    {
        [Key]
        [Column("PersonId")]
        public int PersonId { get; set; }

        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("Phone")]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [Column("City")]
        [MaxLength(50)]
        public string City { get; set; }
    }
}
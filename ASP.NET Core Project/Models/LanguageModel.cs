using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public class LanguageModel
    {
        [Key]
        public int LanguageId { get; set; }

        [Required]
        [Column("Language")]
        [MaxLength(50)]
        public string Language { get; set; }

        public List<PersonLanguageModel> Persons { get; set; }
    }
}

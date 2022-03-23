using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    // Use to prevent overposting and to use data annotations to validate inputs when creating new person.
    public class CreatePersonViewModel
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a Name"), MaxLength(50), MinLength(2)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a Phone number"), MaxLength(17), MinLength(8)]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter a City"), MaxLength(50), MinLength(1)]
        [Display(Name = "City")]
        public string City { get; set; }
    }
}
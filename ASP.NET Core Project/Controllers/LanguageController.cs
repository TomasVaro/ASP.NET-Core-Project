using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class LanguageController : Controller
    {
        private readonly AppDbContext _context;
        public LanguageController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ListOfLanguages()
        {
            List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            List<PersonModel> ListOfPersons = _context.People.ToList();
            List<PersonLanguageModel> ListOfPersonLanguages = _context.PersonLanguage.ToList();
            return View(ListOfLanguages);
        }
    }
}

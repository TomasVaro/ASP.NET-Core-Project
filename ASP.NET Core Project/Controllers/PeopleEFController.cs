using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class PeopleEFController : Controller
    {
        private readonly AppDbContext _context;
        public PeopleEFController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ListOfPeopleEF()
        {
            List<PersonModel> ListOfPersons = _context.People.ToList();
            List<CityModel> ListOfCities = _context.City.ToList();
            return View(ListOfPersons);
        }
        public IActionResult CreatePerson()
        {
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "City");
            return View();
        }
        [HttpPost]
        public IActionResult CreatePerson(PersonModel person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("ListOfPeopleEF");
            }
            return View();
        }
        public IActionResult AddLanguage()
        {
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "Language");
            ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddLanguage(PersonLanguageModel personLanguageModel)
        {
            if (ModelState.IsValid)
            {
                _context.PersonLanguage.Add(personLanguageModel);
                _context.SaveChanges();
                return RedirectToAction("ListOfPeopleEF");
            }
            return View();
        }
    }
}

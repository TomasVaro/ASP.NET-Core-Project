using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class PeopleEFController : Controller
    {
        private readonly AppDbContext _context;
        public PeopleEFController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ListOfPeopleEF()
        {
            List<PersonEFModel> ListOfPersons = _context.People.ToList();
            List<CityModel> ListOfCities = _context.City.ToList();
            List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            List<PersonLanguageModel> ListOfPersonLanguages = _context.PersonLanguage.ToList();
            List<CountryModel> Countries = _context.Country.ToList();
            return View(ListOfPersons);
        }
        public IActionResult AddPerson()
        {
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "City");
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "Language");
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(PersonEFModel person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("ListOfPeopleEF");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeletePerson(int id)
        {            
            _context.People.Remove(TargetPerson(id));
            _context.SaveChanges();
            return RedirectToAction("ListOfPeopleEF");
        }

        public IActionResult EditPerson(int id)
        {
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "City");
            PersonEFModel targetPerson = TargetPerson(id);
            List<CityModel> ListOfCities = _context.City.ToList();
            return View(targetPerson);
        }
        [HttpPost]
        public IActionResult EditChoosenPerson(PersonEFModel person)
        {
            List<PersonEFModel> ListOfPersons = _context.People.ToList(); 
            foreach (PersonEFModel p in ListOfPersons)
            {
                if (p.PersonId == person.PersonId)
                {
                    p.Name = person.Name;
                    p.Phone = person.Phone;
                    p.CityId = person.CityId;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("ListOfPeopleEF");
        }

        public PersonEFModel TargetPerson(int id)
        {
            List<PersonEFModel> ListOfPersons = _context.People.ToList();
            PersonEFModel targetPerson = new PersonEFModel();
            foreach (PersonEFModel p in ListOfPersons)
            {
                if (p.PersonId == id)
                {
                    targetPerson = p;
                }
            }
            return targetPerson;
        }
    }
}

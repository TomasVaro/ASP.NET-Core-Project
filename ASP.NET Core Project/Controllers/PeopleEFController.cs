using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            List<PersonEF> ListOfPersons = _context.People.ToList();
            return View(ListOfPersons);
        }
        public IActionResult CreatePerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePerson(PersonEF person)
        {
            if (ModelState.IsValid)
            {
                _context.People.Add(person);
                _context.SaveChanges();
                return RedirectToAction("ListOfPeopleEF");
            }
            return View();
        }
    }
}

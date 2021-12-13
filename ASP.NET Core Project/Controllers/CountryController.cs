using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CountryController : Controller
    {
        private readonly AppDbContext _context;
        public CountryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ListOfCountries()
        {
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            return View(ListOfCountries);
        }

        public IActionResult DeleteCountry(int id)
        {
            _context.Country.Remove(TargetCountry(id));
            _context.SaveChanges();
            return RedirectToAction("ListOfCountries");
        }

        public IActionResult EditCountry(int id)
        {
            CountryModel targetCountry = TargetCountry(id);
            return View(targetCountry);
        }
        [HttpPost]
        public IActionResult EditChoosenCountry(CountryModel countryChoosen)
        {
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            foreach (CountryModel c in ListOfCountries)
            {
                if (c.CountryId == countryChoosen.CountryId)
                {
                    c.Country = countryChoosen.Country;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("ListOfCountries");
        }

        public IActionResult AddCountry()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCountry(CountryModel countryToAdd)
        {
            _context.Country.Add(countryToAdd);
            _context.SaveChanges();
            return RedirectToAction("ListOfCountries");
        }

        public CountryModel TargetCountry(int id)
        {
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            CountryModel targetCountry = new CountryModel();
            foreach (CountryModel c in ListOfCountries)
            {
                if (c.CountryId == id)
                {
                    targetCountry = c;
                }
            }
            return targetCountry;
        }
    }
}

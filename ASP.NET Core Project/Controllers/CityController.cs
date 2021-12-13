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
    public class CityController : Controller
    {
        private readonly AppDbContext _context;
        public CityController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ListOfCities()
        {
            List<CityModel> ListOfCities = _context.City.ToList();
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            return View(ListOfCities);
        }

        public IActionResult DeleteCity(int id)
        {
            _context.City.Remove(TargetCity(id));
            _context.SaveChanges();
            return RedirectToAction("ListOfCities");
        }

        public IActionResult EditCity(int id)
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "Country");
            CityModel targetCity = TargetCity(id);
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            return View(targetCity);
        }
        [HttpPost]
        public IActionResult EditChoosenCity(CityModel cityChoosen)
        {
            List<CityModel> ListOfCities = _context.City.ToList();
            foreach (CityModel c in ListOfCities)
            {
                if (c.CityId == cityChoosen.CityId)
                {
                    c.City = cityChoosen.City;
                    c.CountryId = cityChoosen.CountryId;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("ListOfCities");
        }

        public IActionResult AddCity()
        {
            ViewData["CountryId"] = new SelectList(_context.Country, "CountryId", "Country");
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult AddCity(CityModel cityToAdd)
        {
            _context.City.Add(cityToAdd);
            _context.SaveChanges();
            return RedirectToAction("ListOfCities");
        }

        public CityModel TargetCity(int id)
        {
            List<CityModel> ListOfCities = _context.City.ToList();
            CityModel targetCity = new CityModel();
            foreach (CityModel c in ListOfCities)
            {
                if (c.CityId == id)
                {
                    targetCity = c;
                }
            }
            return targetCity;
        }
    }
}

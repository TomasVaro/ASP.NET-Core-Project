using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
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
            return View(ListOfCities);
        }
    }
}

using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
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
    }
}

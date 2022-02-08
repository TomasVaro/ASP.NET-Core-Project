using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class ReactController : Controller
    {
        private readonly AppDbContext _context;
        public ReactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public string GetPersons()
        {
            List<PersonEFModel> ListOfPersons = _context.People.ToList();
            List<string> names = _context.People.Select(p => p.Name).ToList();

            //List<CityModel> ListOfCities = _context.City.ToList();
            //List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            //List<PersonLanguageModel> ListOfPersonLanguages = _context.PersonLanguage.ToList();
            //List<CountryModel> Countries = _context.Country.ToList();

            //string JSONresult = JsonConvert.SerializeObject(ListOfPersons, Formatting.Indented,
            //    new JsonSerializerSettings
            //    {
            //        PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //    });


            string JSONresult = JsonConvert.SerializeObject(names);
            //Response.Write(JSONresult);


            //string result = JsonConvert.SerializeObject(DatatableToDictionary(ListOfPersons, "Title"), Newtonsoft.Json.Formatting.Indented);
            return (JSONresult);
        }
    }
}

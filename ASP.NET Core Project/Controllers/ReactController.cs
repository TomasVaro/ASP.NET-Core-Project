using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //List<PersonEFModel> ListOfPersons = _context.People.Include(p => p.City).Include(p => p.Languages).ToList();           
            //string json = JsonConvert.SerializeObject(ListOfPersons, Formatting.Indented,
            //    new JsonSerializerSettings
            //    {
            //        PreserveReferencesHandling = PreserveReferencesHandling.Objects
            //    });


            List<string> names = _context.People.Select(p => p.Name).ToList();
            string JSONresult = JsonConvert.SerializeObject(names);

            return (JSONresult);
        }


        public JsonResult PersonList()
        {
            List<PersonEFModel> ListOfPersons = _context.People.ToList();
            
            return Json(ListOfPersons);
        }



        public void PersonDetails(string name)
        {

        }
    }
}

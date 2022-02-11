using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public void PersonDetails(string name)
        {

        }




        public JsonResult PersonList()
        {
            List<PersonEFModel> ListOfPersons = _context.People.ToList();
            //List<PersonEFModel> ListOfPersons = _context.People.Include(p => p.City).Include(p => p.Languages).ToList();
            ViewData["CityId"] = new SelectList(_context.City, "CityId", "City");
            return Json(ListOfPersons);
        }

        public JsonResult AddEditPerson(PersonEFModel person)
        {
            try
            {
                if (person.PersonId == 0)
                {
                    PersonEFModel personObj = new PersonEFModel();
                    personObj.Name = person.Name;
                    personObj.Phone = person.Phone;
                    personObj.CityId = person.CityId;
                    //personObj.City = person.City;
                    //personObj.Languages = person.Languages;
                    _context.People.Add(personObj);
                    _context.SaveChanges();
                    return Json(new { status = "Success", Message = "Record has been saved" });
                }
            }
            catch{}
            return Json(new { status = "Error", Message = "Data not saved" });
        }
    }
}

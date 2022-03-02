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

        public JsonResult PersonList()
        {
            List<PersonEFModel> ListOfPersons = _context.People.ToList();
            return Json(ListOfPersons);
        }
        
        public JsonResult GetById(int id)
        {
            List<CountryModel> Countries = _context.Country.ToList();
            List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            List<PersonEFModel> ListOfPersons = _context.People.Include(p => p.City).Include(p => p.Languages).ToList();
            var PersonInfo = ListOfPersons.Where(x => x.PersonId == id).SingleOrDefault();
            return Json(PersonInfo);
        }

        [HttpPost]
        public JsonResult AddEditPerson(PersonEFModel data)
        {
            try
            {
                if (data.PersonId == 0)
                {
                    //Add Person
                    PersonEFModel personObj = new PersonEFModel();
                    personObj.Name = data.Name;
                    personObj.Phone = data.Phone;
                    personObj.CityId = data.CityId;
                    //personObj.City = data.City;
                    //personObj.Languages = data.Languages;
                    _context.People.Add(personObj);
                    //_context.SaveChanges();
                    return Json(new { status = "Success", Message = "Record has been saved" });
                }
                else
                {
                    //Edit Person
                    var Person = _context.People.Where(x => x.PersonId == data.PersonId).SingleOrDefault();
                    if(Person.PersonId > 0)
                    {
                        Person.Name = data.Name;
                        Person.Phone = data.Phone;
                        Person.CityId = data.CityId;
                        //_context.SaveChanges();
                        return Json(new { status = "Success", Message = "Record Updated Successfully!" });
                    }
                }
            }
            catch { }
            return Json(new { status = "Error", Message = "Data not saved" });
        }

        //[HttpPost]
        //public JsonResult AddPerson(PersonEFModel person)
        //{
        //    try
        //    {
        //        if (person.PersonId == 0)
        //        {
        //            //Add Person
        //            PersonEFModel personObj = new PersonEFModel();
        //            personObj.Name = person.Name;
        //            personObj.Phone = person.Phone;
        //            personObj.CityId = person.CityId;
        //            //personObj.City = data.City;
        //            //personObj.Languages = data.Languages;
        //            _context.People.Add(personObj);
        //            //_context.SaveChanges();
        //            return Json(new { status = "Success", Message = "Record has been saved" });
        //        }
        //        else
        //        {
        //            //Edit Person
        //            var Person = _context.People.Where(x => x.PersonId == person.PersonId).SingleOrDefault();
        //            if (Person.PersonId > 0)
        //            {
        //                Person.Name = person.Name;
        //                Person.Phone = person.Phone;
        //                Person.CityId = person.CityId;
        //                //_context.SaveChanges();
        //                return Json(new { status = "Success", Message = "Record Updated Successfully!" });
        //            }
        //        }
        //    }
        //    catch { }
        //    return Json(new { status = "Error", Message = "Data not saved" });
        //}
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Project.Models;

namespace ASP.NET_Core_Project.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            PersonMemory personMemory = new PersonMemory();
            List<Person> personList = personMemory.ReadPerson();
            return PartialView("_PeopleListAjaxPartial", personList);
        }
    }
}
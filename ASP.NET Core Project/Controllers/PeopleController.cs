using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class PeopleController : Controller
    {
        //public IActionResult Index()
        //{
            

        //    return View();
        //}
        public IActionResult ListOfPeople(List<Person> people)
        {
            if (Person.personList.Count < 1)
            {
                Person.CreateListOfPersons();
            }
            Person person = new Person();

            //foreach (Person p in people)
            //{
            //    person.Name = p.Name;
            //    person.PhoneNumber = p.PhoneNumber;
            //    person.City = p.City;
            //    return View(person);
            //}


            return View(person);
        }

        public IActionResult FilterPeople()
        {
            return View();
        }

        public IActionResult CreatePerson(Person person)
        {
            List<Person> people = CreatePersonViewModel.AddPeopleToList(person);            
            return RedirectToAction("ListOfPeople", people);
        }
    }
}

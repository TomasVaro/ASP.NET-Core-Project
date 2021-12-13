using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace ASP.NET_Core_Project.Controllers
{
    [Authorize]
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
            PeopleViewModel PeopleListViewModel = new PeopleViewModel() { PersonListView = personMemory.ReadPerson() };
            if (PeopleListViewModel.PersonListView.Count == 0 || PeopleListViewModel.PersonListView == null)
            {
                personMemory.SeedPersons();
            }
            List<PersonModel> personList = personMemory.ReadPerson();
            return PartialView("_PeopleListAjaxPartial", personList);
        }

        [HttpPost]
        public IActionResult FindPersonById(int personID)
        {
            PersonMemory personMemory = new PersonMemory();
            PersonModel personToFind = personMemory.ReadPerson(personID);
            List<PersonModel> personList = new List<PersonModel>();
            if (personToFind != null)
            {
                personList.Add(personToFind);
            }
            return PartialView("_PeopleListAjaxPartial", personList);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeletePersonById(int personID)
        {
            PersonMemory personMemory = new PersonMemory();
            PersonModel personToDelete = personMemory.ReadPerson(personID);
            bool success = false;
            if (personToDelete != null)
            {
                success = personMemory.DeletePerson(personToDelete);
            }
            if (success)
            {
                return StatusCode(200);
            }
            return StatusCode(404);
        }
    }
}
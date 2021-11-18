﻿using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult ListOfPeople()
        {
            PersonEdit personMemory = new PersonEdit();
            PeopleViewModel PeopleListViewModel = new PeopleViewModel() { PersonListView = personMemory.ReadPerson()};
            if (PeopleListViewModel.PersonListView.Count == 0 || PeopleListViewModel.PersonListView == null)
            {
                personMemory.SeedPersons();
            }
            return View(PeopleListViewModel);
        }

        [HttpPost]
        public IActionResult ListOfPeople(PeopleViewModel viewModel)
        {
            PersonEdit personMemory = new PersonEdit();
            viewModel.PersonListView.Clear();

            foreach (Person p in personMemory.ReadPerson())
            {
                if (p.Name.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase) ||
                    p.City.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    viewModel.PersonListView.Add(p);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel createPersonViewModel)
        {
            PeopleViewModel newViewModel = new PeopleViewModel();
            PersonEdit personMemory = new PersonEdit();
            if (ModelState.IsValid)
            {
                newViewModel.Name = createPersonViewModel.Name;
                newViewModel.Phone = createPersonViewModel.Phone;
                newViewModel.City = createPersonViewModel.City;
                newViewModel.PersonListView = personMemory.ReadPerson();

                personMemory.CreatePerson(createPersonViewModel.Name, createPersonViewModel.Phone, createPersonViewModel.City);
                ViewBag.Message = "Successfully added person";
                return View("ListOfPeople", newViewModel);
            }
            else
            {
                ViewBag.Message = "Failed to add person: " + ModelState.Values;
                return View("ListOfPeople", newViewModel);
            }
        }

        public IActionResult DeletePerson(int id)
        {
            PersonEdit personMemory = new PersonEdit();
            Person targetPerson = personMemory.ReadPerson(id);
            personMemory.DeletePerson(targetPerson);
            return RedirectToAction("ListOfPeople");
        }
    }
}
 
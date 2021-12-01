using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class PeopleEFController : Controller
    {
        private ModelBuilder modelBuilder;

        //private readonly appdbcontext _context;

        //public peopleefcontroller(appdbcontext context)
        //{
        //    _context = context;
        //}

        public IActionResult ListOfPeopleEF()
        {
            PersonMemoryEF personMemory = new PersonMemoryEF();
            PeopleViewEFModel PeopleListViewModel = new PeopleViewEFModel() { PersonListViewEF = personMemory.ReadPersonEF() };
            //if (PeopleListViewModel.PersonListViewEF.Count == 0 || PeopleListViewModel.PersonListViewEF == null)
            //{
            //    personMemory.OnModelCreating(modelBuilder);
            //}
            return View(PeopleListViewModel);
        }

        [HttpPost]
        public IActionResult ListOfPeopleEF(PeopleViewEFModel viewModel)
        {
            PersonMemoryEF personMemory = new PersonMemoryEF();
            viewModel.PersonListViewEF.Clear();

            foreach (PersonEF p in personMemory.ReadPersonEF())
            {
                if (p.Name.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase) ||
                    p.City.Contains(viewModel.FilterString, StringComparison.OrdinalIgnoreCase))
                {
                    viewModel.PersonListViewEF.Add(p);
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreatePersonEF(CreatePersonViewModel createPersonViewModel)
        {
            PeopleViewEFModel newViewModel = new PeopleViewEFModel();
            PersonMemoryEF personMemoryEF = new PersonMemoryEF();
            if (ModelState.IsValid)
            {
                newViewModel.Name = createPersonViewModel.Name;
                newViewModel.Phone = createPersonViewModel.Phone;
                newViewModel.City = createPersonViewModel.City;
                newViewModel.PersonListViewEF = personMemoryEF.ReadPersonEF();

                personMemoryEF.CreatePersonEF(createPersonViewModel.Name, createPersonViewModel.Phone, createPersonViewModel.City);
                ViewBag.Message = "Successfully added person";
                return View("ListOfPeopleEF", newViewModel);
            }
            else
            {
                ViewBag.Message = "Failed to add person: " + ModelState.Values;
                return View("ListOfPeopleEF", newViewModel);
            }
        }
    }
}

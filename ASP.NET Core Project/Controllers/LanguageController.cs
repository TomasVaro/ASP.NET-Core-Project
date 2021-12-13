using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    [Authorize]
    public class LanguageController : Controller
    {
        private readonly AppDbContext _context;
        public LanguageController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult ListOfLanguages()
        {
            List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            List<PersonEFModel> ListOfPersons = _context.People.ToList();
            List<PersonLanguageModel> ListOfPersonLanguages = _context.PersonLanguage.ToList();
            return View(ListOfLanguages);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteLanguage(int id)
        {
            _context.Language.Remove(TargetLanguge(id));
            _context.SaveChanges();
            return RedirectToAction("ListOfLanguages");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult EditLanguage(int id)
        {
            LanguageModel targetLanguage = TargetLanguge(id);
            return View(targetLanguage);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult EditLanguage(LanguageModel languageChoosen)
        {
            List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            foreach (LanguageModel l in ListOfLanguages)
            {
                if (l.LanguageId == languageChoosen.LanguageId)
                {
                    l.Language = languageChoosen.Language;
                }
            }
            _context.SaveChanges();
            return RedirectToAction("ListOfLanguages");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddLanguage()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddLanguage(LanguageModel languageToAdd)
        {
            _context.Language.Add(languageToAdd);
            _context.SaveChanges();
            return RedirectToAction("ListOfLanguages");
        }

        public IActionResult AddDeleteLanguagePerson()
        {
            ViewData["LanguageId"] = new SelectList(_context.Language, "LanguageId", "Language");
            ViewData["PersonId"] = new SelectList(_context.People, "PersonId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddDeleteLanguagePerson(PersonLanguageModel personLanguageModel)
        {
            List<PersonLanguageModel> ListOfPersonLanguages = _context.PersonLanguage.ToList();
            foreach (PersonLanguageModel pl in ListOfPersonLanguages)
            {
                if (pl.LanguageId == personLanguageModel.LanguageId && pl.PersonId == personLanguageModel.PersonId)
                {
                    _context.Entry(pl).State = EntityState.Detached;
                    _context.PersonLanguage.Remove(personLanguageModel);
                    _context.SaveChanges();
                    return RedirectToAction("ListOfLanguages");
                }
            }
            if (ModelState.IsValid)
            {
                _context.PersonLanguage.Add(personLanguageModel);
                _context.SaveChanges();
                return RedirectToAction("ListOfLanguages");
            }
            return View();
        }

        public LanguageModel TargetLanguge(int id)
        {
            List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            LanguageModel targetLanguage = new LanguageModel();
            foreach (LanguageModel l in ListOfLanguages)
            {
                if (l.LanguageId == id)
                {
                    targetLanguage = l;
                }
            }
            return targetLanguage;
        }
    }
}

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
        public JsonResult AddEditPerson([FromBody]PersonDTO data)
        {
            List<CountryModel> ListOfCountries = _context.Country.ToList();
            List<LanguageModel> ListOfLanguages = _context.Language.ToList();
            List<CityModel> ListOfCities = _context.City.Include(p => p.Country).ToList();
            PersonEFModel personObj = new PersonEFModel();
            LanguageModel languageObj = new LanguageModel();
            CountryModel countryObj = new CountryModel();
            CityModel cityObj = new CityModel();
            PersonLanguageModel personLanguageObj = new PersonLanguageModel();
            bool b = true;

            personObj.Name = data.Name;
            personObj.Phone = data.Phone;
            cityObj.City = data.City;
            countryObj.Country = data.Country;
            try
            {
                if (data.PersonId == 0)
                {
                    //Add Person
                    for (int i = 0; i < ListOfCities.Count(); i++)
                    {
                        if (ListOfCities[i].City.ToLower() == data.City.ToLower())
                        {
                            for(int j = 0; j < ListOfCountries.Count(); j++)
                            {
                                if (ListOfCountries[j].Country.ToLower() == data.Country.ToLower() &&
                                    ListOfCountries[j].CountryId == ListOfCities[i].CountryId)
                                {
                                    personObj.CityId = ListOfCities[i].CityId;
                                    b = false;
                                    break;
                                }
                                else if (j == ListOfCountries.Count() - 1 && b)
                                {
                                    _context.Country.Add(countryObj);
                                    _context.SaveChanges();

                                    List<CountryModel> NewListOfCountries = _context.Country.ToList();
                                    countryObj = NewListOfCountries.LastOrDefault();
                                    cityObj.CountryId = countryObj.CountryId;

                                    _context.City.Add(cityObj);
                                    _context.SaveChanges();

                                    List<CityModel> NewListOfCities = _context.City.Include(p => p.Country).ToList();
                                    cityObj = NewListOfCities.LastOrDefault();
                                    personObj.CityId = cityObj.CityId;
                                    b = false;
                                }
                            }
                        }
                        else if(i == ListOfCities.Count() - 1 && b == true)
                        {
                            for(int j = 0; j < ListOfCountries.Count(); j++)
                            {
                                if (ListOfCountries[j].Country.ToLower() == data.Country.ToLower())
                                {
                                    cityObj.CountryId = ListOfCountries[j].CountryId;
                                    break;
                                }
                                else if (j == ListOfCountries.Count() - 1)
                                {
                                    _context.Country.Add(countryObj);
                                    _context.SaveChanges();

                                    List<CountryModel> NewListOfCountries = _context.Country.ToList();
                                    countryObj = NewListOfCountries.LastOrDefault();
                                    cityObj.CountryId = countryObj.CountryId;
                                }
                            }
                            _context.City.Add(cityObj);
                            _context.SaveChanges();

                            List<CityModel> NewListOfCities = _context.City.Include(p => p.Country).ToList();
                            cityObj = NewListOfCities.LastOrDefault();
                            personObj.CityId = cityObj.CityId;
                        }
                    }
                    _context.People.Add(personObj);
                    _context.SaveChanges();

                    List<PersonEFModel> NewListOfPersons = _context.People.ToList();
                    personObj = NewListOfPersons.LastOrDefault();
                    personLanguageObj.PersonId = personObj.PersonId;
                    for (int i = 0; i < ListOfLanguages.Count(); i++)
                    {
                        if (ListOfLanguages[i].Language.ToLower() == data.Language.ToLower())
                        {
                            personLanguageObj.LanguageId = ListOfLanguages[i].LanguageId;
                            break;
                        }
                        else if (i == ListOfLanguages.Count() - 1)
                        {
                            languageObj.Language = data.Language;
                            _context.Language.Add(languageObj);
                            _context.SaveChanges();

                            List<LanguageModel> NewListOfLanguages = _context.Language.ToList();
                            languageObj = NewListOfLanguages.LastOrDefault();
                            personLanguageObj.LanguageId = languageObj.LanguageId;
                        }
                    }
                    _context.PersonLanguage.Add(personLanguageObj);
                    _context.SaveChanges();
                }
                else
                {
                    //Edit Person
                    personObj.PersonId = data.PersonId;
                    for (int i = 0; i < ListOfCities.Count(); i++)
                    {
                        if (ListOfCities[i].City.ToLower() == data.City.ToLower())
                        {
                            for(int j = 0; j < ListOfCountries.Count(); j++)
                            {
                                if (ListOfCountries[j].Country.ToLower() == data.Country.ToLower() &&
                                    ListOfCountries[j].CountryId == ListOfCities[i].CountryId)
                                {
                                    personObj.CityId = ListOfCities[i].CityId;
                                    b = false;
                                    break;
                                }
                                else if (j == ListOfCountries.Count() - 1 && b)
                                {
                                    _context.Country.Add(countryObj);
                                    _context.SaveChanges();

                                    List<CountryModel> NewListOfCountries = _context.Country.ToList();
                                    countryObj = NewListOfCountries.LastOrDefault();
                                    cityObj.CountryId = countryObj.CountryId;

                                    _context.City.Add(cityObj);
                                    _context.SaveChanges();

                                    List<CityModel> NewListOfCities = _context.City.Include(p => p.Country).ToList();
                                    cityObj = NewListOfCities.LastOrDefault();
                                    personObj.CityId = cityObj.CityId;
                                    b = false;
                                }
                            }
                        }
                        else if(i == ListOfCities.Count() - 1 && b == true)
                        {
                            for(int j = 0; j < ListOfCountries.Count(); j++)
                            {
                                if (ListOfCountries[j].Country.ToLower() == data.Country.ToLower())
                                {
                                    cityObj.CountryId = ListOfCountries[j].CountryId;
                                    break;
                                }
                                else if (j == ListOfCountries.Count() - 1)
                                {
                                    _context.Country.Add(countryObj);
                                    _context.SaveChanges();

                                    List<CountryModel> NewListOfCountries = _context.Country.ToList();
                                    countryObj = NewListOfCountries.LastOrDefault();
                                    cityObj.CountryId = countryObj.CountryId;
                                }
                            }
                            _context.City.Add(cityObj);
                            _context.SaveChanges();

                            List<CityModel> NewListOfCities = _context.City.Include(p => p.Country).ToList();
                            cityObj = NewListOfCities.LastOrDefault();
                            personObj.CityId = cityObj.CityId;
                        }
                    }
                    _context.People.Update(personObj);
                    _context.SaveChanges();

                    List<PersonEFModel> NewListOfPersons = _context.People.ToList();
                    personObj = NewListOfPersons.LastOrDefault();
                    personLanguageObj.PersonId = personObj.PersonId;
                    for (int i = 0; i < ListOfLanguages.Count(); i++)
                    {
                        if (ListOfLanguages[i].Language.ToLower() == data.Language.ToLower())
                        {
                            personLanguageObj.LanguageId = ListOfLanguages[i].LanguageId;
                            break;
                        }
                        else if (i == ListOfLanguages.Count() - 1)
                        {
                            languageObj.Language = data.Language;
                            _context.Language.Add(languageObj);
                            _context.SaveChanges();

                            List<LanguageModel> NewListOfLanguages = _context.Language.ToList();
                            languageObj = NewListOfLanguages.LastOrDefault();
                            personLanguageObj.LanguageId = languageObj.LanguageId;
                        }
                    }
                    _context.PersonLanguage.Add(personLanguageObj);
                    _context.SaveChanges();
                }
            }
            catch { }
            return Json(new { status = "Error", Message = "Data not saved" });
        }
    }
}

using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FeverCheck()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FeverCheck(string temperature)
        {
            if (temperature != null)
            {
                ViewBag.Message = Utilities.CheckFever(temperature);
            }
            return View();
        }
    }
}

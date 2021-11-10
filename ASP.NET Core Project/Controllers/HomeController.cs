using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Welcome = "Welcome to my homepage!";
            return View();
        }
        public IActionResult About()
        {
            //Containing information about yourself (CV, for example)
            ViewBag.About = "My Resume in Swedish";
            return View();
        }
        public IActionResult Contact()
        {
            //Containing your contact information (Use fake info if you want).
            ViewBag.Contact = "My contact information";
            return View();
        }
        public IActionResult Projects()
        {
            //Containing the GitHub links to your assignments you have finished with a small description about them.
            ViewBag.Projects = "My Assignments";
            return View();
        }
    }
}

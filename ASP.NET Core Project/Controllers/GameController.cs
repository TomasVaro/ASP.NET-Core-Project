using ASP.NET_Core_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Controllers
{
    public class GameController : Controller
    {
        public IActionResult NumberGuessing()
        {
            if (HttpContext.Session.GetInt32("RndNr") == null || HttpContext.Session.GetInt32("RndNr") == 0)
            {
                int rndNr = Utilities.RndNr();
                HttpContext.Session.SetInt32("RndNr", rndNr);
                ViewBag.Counter = "0";
            }
            return View();
        }
        [HttpPost]
        public IActionResult NumberGuessing(int guessedNr)
        {
            if (guessedNr != 0)
            {
                int rndNr = (int)HttpContext.Session.GetInt32("RndNr");
                string[] message = Utilities.CheckNumber(guessedNr, rndNr);
                if (message[2] == "EndGame")
                {
                    HttpContext.Session.SetInt32("RndNr", 0);
                    NumberGuessing();
                }
                ViewBag.Message = message[0];
                ViewBag.Counter = message[1];
            }
            else
            {
                ViewBag.Message = "You must enter a number 1-100. Please try again!";
            }
            return View();
        }
    }
}
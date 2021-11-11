using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Project.Models
{
    public static class Utilities
    {
        public static string CheckFever(string temperature)
        {
            string message = "";
            float temp = float.Parse(temperature, CultureInfo.InvariantCulture.NumberFormat);
            if (temp < 35)
            {
                message = "You have hypothermia!";
            }
            else if (temp >= 35 && temp < 36.5)
            {
                message = "You have a low body temperature.";
            }
            else if (temp >= 36.5 && temp <= 37.5)
            {
                message = "You have a normal body temperature.";
            }
            else if (temp > 37.5 && temp < 38)
            {
                message = "You are subfebrile!";
            }
            else if (temp >= 38 && temp < 40)
            {
                message = "You have a fever!";
            }
            else
            {
                message = "You have a high fever!!";
            }
            return message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(string filter, int page = 1)
        {
            using (var db = new AutoContext())
            {
                ViewData["Page"] = page;
                object cars;
                if (string.IsNullOrEmpty(filter))
                {
                    cars = db.Car
                        .OrderByDescending(b => b.CarYear)
                        .ToList();
                } else
                {
                    string[] filters = filter.Split('-');
                    ViewData["Filter"] = filters[0];
                    if (filters.Length > 1)  // Car filter exists
                    {
                        cars = db.Car
                            .Where(b => b.CarManufacturer.Equals(filters[0]) && b.CarName.Equals(filters[1]))
                            .OrderByDescending(b => b.CarYear)
                            .ToList();
                    }
                    else                     // Not filtered by car
                    {               
                        cars = db.Car
                            .Where(b => b.CarManufacturer.Equals(filters[0]))
                            .OrderByDescending(b => b.CarYear)
                            .ToList();
                    }
                }
                return View(cars);
            }
        }
        // GET: Home/About/
        public IActionResult About()
        {
            return View();
        }

        // GET: Home/Contact/
        public IActionResult Contact()
        {
            ViewData["Message"] = "You can find us at:";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

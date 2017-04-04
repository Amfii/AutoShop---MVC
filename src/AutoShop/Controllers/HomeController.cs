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
                    cars = db.Car
                        .Where(b => b.CarManufacturer.Equals(filter))
                        .OrderByDescending(b => b.CarYear)
                        .ToList();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AutoShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string filter = "All")
        {
            using (var db = new AutoContext())
            {
                var cars = db.Car
                    .OrderByDescending(b => b.CarYear)
                    .ToList();
                var manufacturers = db.Manufacturer
                    .OrderBy(b => b.ManufacturerName)
                    .ToList();
                ViewData["Cars"] = cars;
                ViewData["Manufacturers"] = manufacturers;
            }
            ViewData["Shop Name"] = "AutoList";
            ViewData["Filter"] = filter;

            return View();
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

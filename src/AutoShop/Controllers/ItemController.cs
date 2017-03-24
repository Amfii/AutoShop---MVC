using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace AutoShop.Controllers
{
    public class ItemController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ItemController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index(int itemId = 0)
        {
            using (var db = new AutoContext())
            {
                var car = db.Car
                    .Where(b => b.CarID == itemId).ToList();
                if (car != null && car.Count > 0) {     // car is in database
                    ViewData["Car"] = car[0];
                    IEnumerable<string> imageNames;     // car images
                    try {   // Get all car images
                        imageNames = Directory.EnumerateFiles(_hostingEnvironment.WebRootPath + ("/images/cars/" + car[0].CarID + "/")).Select(file => Path.GetFileName(file));
                        ViewData["CarImages"] = imageNames;
                    } catch
                    {
                        imageNames = null;              // car has no images
                        ViewData["CarImages"] = imageNames;
                    }
                }
            }
            return View();
        }
    }
}

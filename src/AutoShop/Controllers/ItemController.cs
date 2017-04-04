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

        public IActionResult Index(int? itemId)
        {
            if (itemId == null)
            {
                return NotFound();
            }

            using (var db = new AutoContext())
            {
                var car = db.Car
                    .SingleOrDefault(b => b.CarID == itemId);

                if (car == null)
                {
                    return NotFound();
                }

                IEnumerable<string> imageNames;     // car images
                try {   // Get all car images
                    imageNames = Directory.EnumerateFiles(_hostingEnvironment.WebRootPath + ("/images/cars/" + car.CarID + "/")).Select(file => Path.GetFileName(file));
                    ViewData["CarImages"] = imageNames;
                } catch {
                    imageNames = null;              // car has no images
                    ViewData["CarImages"] = imageNames;
                }

                return View(car);
            }
        }
    }
}

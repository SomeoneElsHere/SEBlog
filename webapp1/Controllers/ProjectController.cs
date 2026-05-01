using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp1.Models;

namespace webapp1.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Chaosmod()
        {
            return View();
        }
        public IActionResult MipsMap()
        {
            return View();
        }

        public IActionResult sleeveColor()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Download(string file)
        {
            return File("/lib/Download/"+file, "application/zip");
        }
    }
}

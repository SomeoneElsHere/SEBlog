using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webapp1.Models;

namespace webapp1.Controllers
{
    public class MiscController : Controller
    {
        public IActionResult Alarm()
        {
            return View();
        }
        public IActionResult AAO()
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

using Krouzek_MS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Krouzek_MS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Fotogalerie()
        {
            return View();
        }
        public IActionResult ONas()
        {
            return View();
        }
        public IActionResult omalovanky()
        {
            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
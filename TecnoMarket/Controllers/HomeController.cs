using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TecnoMarket.Models;

namespace TecnoMarket.Controllers
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
        [HttpPost]
        public IActionResult Index(string nombre)
        {
            return RedirectToAction(nameof(Privacy),new { nombre });
        }

        public IActionResult Privacy(string nombre)
        {
            return View("Privacy",nombre);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
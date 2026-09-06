using Microsoft.AspNetCore.Mvc;
using PLM.Models;
using System.Diagnostics;

namespace PLM.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lock()
        {
            return RedirectToAction(nameof(Lockscreen));
        }

        public IActionResult Lockscreen()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Unlock()
        {
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

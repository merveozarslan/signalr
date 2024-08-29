using Microsoft.AspNetCore.Mvc;
using SIGNALR_APP.Models;
using System.Diagnostics;

namespace SIGNALR_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

          public IActionResult ProductsPage()
      {
            return View();
        } 

        public IActionResult OrdersPage()
        {
            return View();
        }
        public IActionResult SalesPage()
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

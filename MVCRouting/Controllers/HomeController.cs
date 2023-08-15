using Microsoft.AspNetCore.Mvc;
using MVCRouting.Data;
using MVCRouting.Models;
using System.Diagnostics;

namespace MVCRouting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("",Order = 1)]
        [Route("Anasayfa", Order = 2)]
        public IActionResult Index()
        {
            return View(Db.Bolgeler().ToList());
        }

        [Route("Gizlilik")]
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
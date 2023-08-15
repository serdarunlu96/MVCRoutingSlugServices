using Microsoft.AspNetCore.Mvc;
using MVCRouting.Data;
using MVCRouting.Models;
using MVCRouting.Services;

namespace MVCRouting.Controllers
{
    public class TurkiyeController : Controller
    {
        private readonly UrlService _urlService;
        public TurkiyeController(UrlService urlService)
        {
               _urlService= urlService;
        }

        [Route("bolge/{slug}")]
        public IActionResult Bolgeler(string slug)
        {
           Bolge? bolge = Db.Bolgeler().FirstOrDefault(b => _urlService.URLFriendly(b.BolgeAd) == slug);

            if (bolge == null)
            {
                return NotFound();
            }

            List<Sehir> sehirler = Db.Sehirler().Where(s => s.BolgeId == bolge.Id).ToList();

            var vm = new BolgelerViewModel()
            {
                Bolge = bolge,
                Sehirler = sehirler
            };

            return View(vm);
        }
    }
}

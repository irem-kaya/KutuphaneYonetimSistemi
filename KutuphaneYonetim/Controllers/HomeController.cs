using KutuphaneYonetim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace KutuphaneYonetim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KutuphaneContext _context; 
        public HomeController(ILogger<HomeController> logger, KutuphaneContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var kitaplar = _context.Kitaplar.ToList();
            return View("~/Views/Kitap/Listele.cshtml", kitaplar);
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
        public IActionResult Hakkimizda()
        {
            return View();
        }
        [HttpPost]
        public IActionResult BizeUlasin(string adSoyad, string email, string mesaj)
        {
            if (string.IsNullOrWhiteSpace(adSoyad) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(mesaj))
            {
                ViewBag.Hata = "Lütfen tüm alanlarý doldurun.";
                return View();
            }

            // Burada formdan gelen veriyi iþleyebilirsiniz. (Veritabanýna kaydetme, e-posta gönderme vb.)
            TempData["Mesaj"] = "Mesajýnýz baþarýyla gönderildi. En kýsa sürede size geri dönüþ yapýlacaktýr.";
            return RedirectToAction("BizeUlasin"); // Form gönderildikten sonra ayný sayfaya yönlendirme.
        }

        [HttpGet]
        public IActionResult BizeUlasin()
        {
            return View();
        }
    }
}

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
                ViewBag.Hata = "L�tfen t�m alanlar� doldurun.";
                return View();
            }

            // Burada formdan gelen veriyi i�leyebilirsiniz. (Veritaban�na kaydetme, e-posta g�nderme vb.)
            TempData["Mesaj"] = "Mesaj�n�z ba�ar�yla g�nderildi. En k�sa s�rede size geri d�n�� yap�lacakt�r.";
            return RedirectToAction("BizeUlasin"); // Form g�nderildikten sonra ayn� sayfaya y�nlendirme.
        }

        [HttpGet]
        public IActionResult BizeUlasin()
        {
            return View();
        }
    }
}

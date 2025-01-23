using Microsoft.AspNetCore.Mvc;
using KutuphaneYonetim.Models; 
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace KutuphaneYonetim.Controllers
{
    public class KullaniciController : Controller
    {
        
        private readonly ILogger<KullaniciController> _logger;
        private readonly KutuphaneContext _context;

        public KullaniciController(ILogger<KullaniciController> logger, KutuphaneContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Listele()
        {
            var kullanicilar = _context.Kullanicilar
                .Where(k => k.Rol != "Yonetici") // Admin hariç
                .Include(k => k.OduncIslemleri)
                .ThenInclude(o => o.Kitap)
                .ToList();

            return View(kullanicilar);
        }
        

        [HttpPost]
        public JsonResult FavorilereEkle(int kitapId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Giriş yapmanız gerekiyor." });
            }

            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value);

            // Favori zaten eklenmiş mi kontrol et
            var mevcutFavori = _context.Favoriler.FirstOrDefault(f => f.KullaniciID == userId && f.KitapID == kitapId);
            if (mevcutFavori != null)
            {
                return Json(new { success = false, message = "Kitap zaten favorilerinizde." });
            }

            // Yeni favori ekle
            var yeniFavori = new Favori
            {
                KullaniciID = userId,
                KitapID = kitapId
            };
            _context.Favoriler.Add(yeniFavori);
            _context.SaveChanges();

            return Json(new { success = true });
        }


        [HttpPost]
        public JsonResult FavorilerdenCikar(int kitapId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json(new { success = false, message = "Giriş yapmanız gerekiyor." });
            }

            var userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value);

            var favori = _context.Favoriler.FirstOrDefault(f => f.KullaniciID == userId && f.KitapID == kitapId);
            if (favori == null)
            {
                return Json(new { success = false, message = "Favori bulunamadı." });
            }

            _context.Favoriler.Remove(favori);
            _context.SaveChanges();

            return Json(new { success = true });
        }

        public IActionResult Favori()
        {
            // Kullanıcı giriş yapmış mı kontrol et
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Giris", "Hesap"); // Giriş sayfasına yönlendir
            }

            // Kullanıcı ID'sini al
            var userId = User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value;

            // Kullanıcıya ait favori kitapları çek
            var favoriler = _context.Favoriler
                .Where(f => f.KullaniciID == int.Parse(userId))
                .Include(f => f.Kitap) // Favori kitapla ilişkili kitap bilgilerini al
                .ToList();

            return View(favoriler);
        }


        public IActionResult KitapListesi()
        {
            var userId = User.Identity.IsAuthenticated
                ? User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value
                : null;

            if (userId != null)
            {
                int kullaniciId = int.Parse(userId);

                var favoriKitaplar = _context.Favoriler
                    .Where(f => f.KullaniciID == kullaniciId)
                    .Select(f => f.KitapID)
                    .ToList();

                ViewBag.FavoriKitaplar = favoriKitaplar;
            }
            else
            {
                ViewBag.FavoriKitaplar = new List<int>(); // Kullanıcı giriş yapmamışsa boş liste
            }

            var kitaplar = _context.Kitaplar.ToList();
            return View(kitaplar);
        }



        [HttpPost]
        public IActionResult FavoriDurumGuncelle(int kitapId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "KullaniciID")?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int kullaniciIdInt))
            {
                return Json(new { success = false, message = "Kullanıcı kimliği geçerli değil." });
            }

            var favori = _context.Favoriler
                .FirstOrDefault(f => f.KullaniciID == kullaniciIdInt && f.KitapID == kitapId);

            if (favori == null)
            {
                // Favorilere ekleme işlemi
                _context.Favoriler.Add(new Favori
                {
                    KullaniciID = kullaniciIdInt,
                    KitapID = kitapId,
                    EklenmeTarihi = DateTime.Now
                });
                _context.SaveChanges();

                return Json(new { success = true, isFavori = true });
            }
            else
            {
                // Favorilerden çıkarma işlemi
                _context.Favoriler.Remove(favori);
                _context.SaveChanges();

                return Json(new { success = true, isFavori = false });
            }
        }
        [HttpPost]
        public IActionResult PasifYap(int kullaniciId)
        {
            // Kullanıcıyı veritabanından bul
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.KullaniciID == kullaniciId);

            if (kullanici != null)
            {
                // Kullanıcıyı pasif yap
                kullanici.Durum = false;
                _context.SaveChanges();

                return Json(new { success = true, message = "Kullanıcı başarıyla pasif hale getirildi." });
            }

            // Eğer kullanıcı bulunamazsa
            return Json(new { success = false, message = "Kullanıcı bulunamadı." });
        }





    }
}

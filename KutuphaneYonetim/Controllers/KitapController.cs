using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KutuphaneYonetim.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneYonetim.Controllers
{
    public class KitapController : Controller
    {
        private readonly KutuphaneContext _context;

        public KitapController(KutuphaneContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Ekle(Kitap yeniKitap, IFormFile? resim)
        {
            ModelState.Remove("ResimUrl"); 

            if (resim != null)
            {
                var dosyaAdi = Path.GetFileName(resim.FileName);
                var dosyaYolu = Path.Combine("wwwroot/images", dosyaAdi);

                using (var stream = new FileStream(dosyaYolu, FileMode.Create))
                {
                    await resim.CopyToAsync(stream);
                }

                yeniKitap.ResimUrl = $"/images/{dosyaAdi}";
            }

            _context.Kitaplar.Add(yeniKitap);
            await _context.SaveChangesAsync();

            return RedirectToAction("Basari", new { id = yeniKitap.KitapID });
        }


        [HttpGet]
        public IActionResult Basari(int id)
        {
            var kitap = _context.Kitaplar.FirstOrDefault(k => k.KitapID == id);

            if (kitap == null)
            {
                TempData["Hata"] = "Kitap bulunamadı!";
                return RedirectToAction("Listele");
            }

            return View(kitap);
        }

        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Guncelle(int id)
        {
            var kitap = _context.Kitaplar.FirstOrDefault(k => k.KitapID == id);
            if (kitap == null)
                return NotFound();

            return View(kitap);
        }

        
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Guncelle(int id, Kitap guncellenenKitap, IFormFile? yeniResim)
        {
            ModelState.Remove("ResimUrl");

            var mevcutKitap = await _context.Kitaplar.FindAsync(id);
            if (mevcutKitap == null)
            {
                TempData["Hata"] = "Kitap bulunamadı.";
                return RedirectToAction("Listele");
            }

            mevcutKitap.KitapAdi = guncellenenKitap.KitapAdi;
            mevcutKitap.Yazar = guncellenenKitap.Yazar;
            mevcutKitap.Yayinevi = guncellenenKitap.Yayinevi;
            mevcutKitap.Tur = guncellenenKitap.Tur;
            mevcutKitap.YayimYili = guncellenenKitap.YayimYili;
            mevcutKitap.MusaitMi = guncellenenKitap.MusaitMi;

            if (yeniResim != null)
            {
                var dosyaAdi = Path.GetFileName(yeniResim.FileName);
                var dosyaYolu = Path.Combine("wwwroot/images", dosyaAdi);

                using (var stream = new FileStream(dosyaYolu, FileMode.Create))
                {
                    await yeniResim.CopyToAsync(stream);
                }

                mevcutKitap.ResimUrl = $"/images/{dosyaAdi}";
            }

            _context.Kitaplar.Update(mevcutKitap);
            await _context.SaveChangesAsync();

            TempData["Mesaj"] = "Kitap başarıyla güncellendi.";
            return RedirectToAction("Listele");
        }

        [HttpPost]
        public IActionResult Sil(int kitapId)
        {
            var kitap = _context.Kitaplar.FirstOrDefault(k => k.KitapID == kitapId);

            if (kitap == null)
            {
                return Json(new { success = false, message = "Kitap bulunamadı." });
            }

            try
            {
                _context.Kitaplar.Remove(kitap);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Hata oluştu: " + ex.Message });
            }
        }




        [HttpGet]
        public IActionResult Ara(string searchKeyword)
        {
            if (string.IsNullOrEmpty(searchKeyword))
            {
                var kitaplar = _context.Kitaplar.ToList();
                return PartialView("_KitapListePartial", kitaplar);
            }

            var aramaSonucu = _context.Kitaplar
                .Where(k => k.KitapAdi.Contains(searchKeyword) || k.Yazar.Contains(searchKeyword)) 
                .ToList();

            return PartialView("_KitapListePartial", aramaSonucu);
        }


        [HttpGet]
        public IActionResult Detay(int id)
        {
            var kitap = _context.Kitaplar.FirstOrDefault(k => k.KitapID == id);

            if (kitap == null)
                return NotFound();

            return View(kitap);
        }

        public IActionResult Listele()
        {
            var kitaplar = _context.Kitaplar.ToList();

            // Eğer kitaplar null ya da boşsa kontrol edin
            if (kitaplar == null || !kitaplar.Any())
            {
                TempData["Mesaj"] = "Henüz eklenmiş kitap bulunmamaktadır.";
                return RedirectToAction("Listele", "Kitap"); // Ana sayfaya yönlendirme
            }

            return View(kitaplar);
        }


        public IActionResult Kesfet()
        {
            return View();
        }
        


        [Authorize(Policy = "KullaniciOnly")]
        public IActionResult OduncAlinanlar()
        {
            var kullaniciIdClaim = User.FindFirst("KullaniciID")?.Value;
            if (string.IsNullOrEmpty(kullaniciIdClaim))
            {
                return RedirectToAction("Giris", "Hesap");
            }

            int kullaniciId = int.Parse(kullaniciIdClaim);

            var oduncListesi = _context.OduncIslemler
                .Include(o => o.Kitap)
                .Include(o => o.Kullanici)
                .Where(o => o.KullaniciID == kullaniciId)
                .ToList();

            return View(oduncListesi);
        }
    }
}

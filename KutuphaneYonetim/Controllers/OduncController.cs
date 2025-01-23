using KutuphaneYonetim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KutuphaneYonetim.Controllers
{
    
    public class OduncController : Controller
    {
        private readonly KutuphaneContext _context;

        public OduncController(KutuphaneContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult IadeEt(int id)
        {
            var oduncIslem = _context.OduncIslemler.FirstOrDefault(o => o.IslemID == id);
            if (oduncIslem == null)
            {
                TempData["HataMesaji"] = "İade edilecek işlem bulunamadı.";
                return RedirectToAction("OduncAlinanlar");
            }

            oduncIslem.IadeTarihi = DateTime.Now;

            int maxGun = 14;
            decimal gunlukCeza = 1.0m;
            int gecikmeGun = (DateTime.Now - oduncIslem.AlisTarihi).Days - maxGun;
            oduncIslem.CezaTutar = gecikmeGun > 0 ? gecikmeGun * gunlukCeza : 0;

            var kitap = _context.Kitaplar.FirstOrDefault(k => k.KitapID == oduncIslem.KitapID);
            if (kitap != null)
            {
                kitap.MusaitMi = true;
            }

            _context.SaveChanges();
            TempData["BasariMesaji"] = "Kitap başarıyla iade edildi.";
            return RedirectToAction("OduncAlinanlar");
        }

        [HttpGet]
        public IActionResult Listele()
        {
            var kitaplar = _context.Kitaplar.ToList();
            return View(kitaplar);
        }

        [Authorize(Roles = "Kullanici")]
        [HttpPost]
        public IActionResult OduncAl(int kitapID)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Giris", "Hesap");
            }

            var kitap = _context.Kitaplar.FirstOrDefault(k => k.KitapID == kitapID);
            if (kitap == null || !kitap.MusaitMi)
            {
                TempData["HataMesaji"] = "Kitap uygun değil veya bulunamadı.";
                return RedirectToAction("Listele");
            }

            var kullaniciID = int.Parse(User.FindFirst("KullaniciID").Value);

            var oduncIslem = new OduncIslem
            {
                KullaniciID = kullaniciID,
                KitapID = kitapID,
                AlisTarihi = DateTime.Now,
                IadeTarihi = null,
                CezaTutar = 0
            };

            kitap.MusaitMi = false;
            _context.OduncIslemler.Add(oduncIslem);
            _context.SaveChanges();

            TempData["BasariMesaji"] = "Kitap başarıyla ödünç alındı!";
            return RedirectToAction("OduncAlinanlar");
        }


        public IActionResult OduncAlinanlar()
        {
            
            int kullaniciId = int.Parse(User.FindFirst("KullaniciID").Value);

            var oduncListesi = _context.OduncIslemler
                .Where(o => o.KullaniciID == kullaniciId)
                .Include(o => o.Kitap)
                .ToList();

            int maxGun = 14; 
            decimal gunlukCeza = 1.0m; 
            decimal toplamCeza = 0; 
            int cezaSayisi = 0; 

          
            foreach (var odunc in oduncListesi)
            {
                if (!odunc.IadeTarihi.HasValue) 
                {
                    int gecikmeGun = (DateTime.Now - odunc.AlisTarihi).Days - maxGun; 
                    odunc.CezaTutar = gecikmeGun > 0 ? gecikmeGun * gunlukCeza : 0;

                    if (odunc.CezaTutar > 0)
                    {
                        toplamCeza += odunc.CezaTutar.Value;
                        cezaSayisi++;
                    }
                }
                else if (odunc.CezaTutar > 0)
                {
                    toplamCeza += odunc.CezaTutar.Value;
                    cezaSayisi++;
                }
            }

            var kullanici = _context.Kullanicilar.Find(kullaniciId);
            if (kullanici != null)
            {
                kullanici.UyariSayisi = cezaSayisi; 
                _context.SaveChanges(); 
            }

            int toplamUyariHakki = 5; 
            int kalanUyariHakki = toplamUyariHakki - cezaSayisi;

            ViewBag.ToplamCeza = toplamCeza;
            ViewBag.CezaSayisi = cezaSayisi;
            ViewBag.KalanUyariHakki = kalanUyariHakki > 0 ? kalanUyariHakki : 0;

            return View(oduncListesi);
        }



    }

}


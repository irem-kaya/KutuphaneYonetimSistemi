using KutuphaneYonetim.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KutuphaneYonetim.Controllers
{
    public class HesapController : Controller
    {
        private readonly KutuphaneContext _context;

        public HesapController(KutuphaneContext context)
        {
            _context = context;
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris(string kullaniciAdi, string sifre)
        {
            var kullanici = _context.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi && k.Sifre == sifre);
            if (kullanici != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
                    new Claim("KullaniciID", kullanici.KullaniciID.ToString()), 
                    new Claim(ClaimTypes.Role, kullanici.Rol)
                };

                var identity = new ClaimsIdentity(claims, "CookieAuth");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("CookieAuth", principal);

                return RedirectToAction("Index", "Ana"); 
            }

            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        public async Task<IActionResult> Cikis()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Giris");
        }

        
        public IActionResult Hata(string mesaj)
        {
            ViewBag.HataMesaji = mesaj;
            return View();
        }

        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit(string kullaniciAdi, string sifre)
        {
            var mevcutKullanici = _context.Kullanicilar.FirstOrDefault(k => k.KullaniciAdi == kullaniciAdi);
            if (mevcutKullanici != null)
            {
                ViewBag.Hata = "Bu kullanıcı adı zaten alınmış.";
                return View();
            }

            var yeniKullanici = new Kullanici
            {
                KullaniciAdi = kullaniciAdi,
                Sifre = sifre,
                Rol = "Kullanici", 
                Durum = true, 
                UyariSayisi = 0 
            };

            _context.Kullanicilar.Add(yeniKullanici);
            _context.SaveChanges();

            TempData["KayitBasarili"] = "Kayıt başarılı! Lütfen giriş yapın.";
            return RedirectToAction("Giris", "Hesap");
        }

    }
}

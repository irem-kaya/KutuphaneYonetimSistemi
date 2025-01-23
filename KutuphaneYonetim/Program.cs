using KutuphaneYonetim.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database baðlantýsý
builder.Services.AddDbContext<KutuphaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC desteði
builder.Services.AddControllersWithViews();

// Authentication ve Authorization ayarlarý
builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
{
    options.LoginPath = "/Hesap/Giris"; // Giriþ yapýlmamýþsa yönlendirme
    options.AccessDeniedPath = "/Hesap/ErisimEngellendi"; // Yetki eksikliðinde yönlendirme
});

builder.Services.AddAuthorization(options =>
{
    // Yonetici rolü için politika
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Yonetici"));

    // Kullanýcý rolü için politika
    options.AddPolicy("KullaniciOnly", policy => policy.RequireRole("Kullanici"));

    // Genel Kullanýcý politikasý
    options.AddPolicy("Kullanici", policy => policy.RequireRole("Kullanici"));
});


var app = builder.Build();

// Hata ayarlarý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS yönlendirme ve statik dosyalar
app.UseHttpsRedirection();
app.UseStaticFiles();

// Routing ve yetkilendirme middleware'leri
app.UseRouting();
app.UseAuthentication(); // Kimlik doðrulama
app.UseAuthorization();  // Yetkilendirme

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulama çalýþtýrma
app.Run();

using KutuphaneYonetim.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database ba�lant�s�
builder.Services.AddDbContext<KutuphaneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVC deste�i
builder.Services.AddControllersWithViews();

// Authentication ve Authorization ayarlar�
builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
{
    options.LoginPath = "/Hesap/Giris"; // Giri� yap�lmam��sa y�nlendirme
    options.AccessDeniedPath = "/Hesap/ErisimEngellendi"; // Yetki eksikli�inde y�nlendirme
});

builder.Services.AddAuthorization(options =>
{
    // Yonetici rol� i�in politika
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Yonetici"));

    // Kullan�c� rol� i�in politika
    options.AddPolicy("KullaniciOnly", policy => policy.RequireRole("Kullanici"));

    // Genel Kullan�c� politikas�
    options.AddPolicy("Kullanici", policy => policy.RequireRole("Kullanici"));
});


var app = builder.Build();

// Hata ayarlar�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS y�nlendirme ve statik dosyalar
app.UseHttpsRedirection();
app.UseStaticFiles();

// Routing ve yetkilendirme middleware'leri
app.UseRouting();
app.UseAuthentication(); // Kimlik do�rulama
app.UseAuthorization();  // Yetkilendirme

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulama �al��t�rma
app.Run();

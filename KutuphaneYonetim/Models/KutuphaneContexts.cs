using Microsoft.EntityFrameworkCore;

namespace KutuphaneYonetim.Models
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext(DbContextOptions<KutuphaneContext> options) : base(options) { }

        public DbSet<Kullanici> Kullanicilar { get; set; }

        public DbSet<Kitap> Kitaplar { get; set; }

        public DbSet<OduncIslem> OduncIslemler { get; set; }

        public DbSet<Favori> Favoriler { get; set; }

       
        
    }
}

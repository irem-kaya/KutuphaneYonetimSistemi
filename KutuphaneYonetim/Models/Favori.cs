namespace KutuphaneYonetim.Models
{
    public class Favori
    {
        public int FavoriID { get; set; }
        public int KullaniciID { get; set; }
        public int KitapID { get; set; }
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
        public Kitap Kitap { get; set; }
    }
}

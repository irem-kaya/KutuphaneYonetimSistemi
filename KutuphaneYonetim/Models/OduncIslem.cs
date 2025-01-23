using System.ComponentModel.DataAnnotations;

namespace KutuphaneYonetim.Models
{
    public class OduncIslem
    {
        [Key]
        public int IslemID { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }
        public int KitapID { get; set; }
        public Kitap Kitap { get; set; }
        public DateTime AlisTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }
        public decimal? CezaTutar { get; set; }
        public string KullaniciAdi => Kullanici?.KullaniciAdi ?? "Kullanıcı Yok";
        public string KitapAdi => Kitap?.KitapAdi ?? "Kitap Yok";
        public int UyariSayisi => Kullanici?.UyariSayisi ?? 0;
        public string Durum
        {
            get
            {
                if (IadeTarihi == null)
                {
                    return AlisTarihi.AddDays(14) < DateTime.Now ? "Gecikmiş" : "Devam Ediyor";
                }
                return "Tamamlandı";
            }
        }
    }

}

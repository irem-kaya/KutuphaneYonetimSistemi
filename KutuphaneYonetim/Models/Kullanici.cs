using System.ComponentModel.DataAnnotations;

namespace KutuphaneYonetim.Models
{
    public enum KullaniciRol
    {
        Yonetici,
        Kullanici
    }
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }

        [Required]
        [StringLength(50)]
        public string KullaniciAdi { get; set; } 

        [Required]
        [StringLength(20)]
        public string Sifre { get; set; } 

        [Required]
        public string Rol { get; set; } 

        public bool Durum { get; set; } = true;
        public int UyariSayisi { get; set; }

        public ICollection<OduncIslem> OduncIslemleri { get; set; }
       

    }
}

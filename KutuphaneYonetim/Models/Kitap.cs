using System.ComponentModel.DataAnnotations;


namespace KutuphaneYonetim.Models
{
    public class Kitap
    {
        [Key]
        public int KitapID { get; set; }
        [Required(ErrorMessage = "ISBN alanı gereklidir.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Kitap Adı gereklidir.")]
        [StringLength(100)]
        public string KitapAdi { get; set; }
        
        [Required(ErrorMessage = "Yazar alanı gereklidir.")]
        [StringLength(100)]
        public string Yazar { get; set; }

        [Required(ErrorMessage = "Yayın Evi alanı gereklidir.")]
        [StringLength(100)]
        public string Yayinevi { get; set; }

        [Required(ErrorMessage = "Tür alanı gereklidir.")]
        [StringLength(50)]
        public string Tur { get; set; }

        [Required(ErrorMessage = "Yayın Yılı gereklidir.")]
        [Range(1800, 2100)]
        public int YayimYili { get; set; } 

        
        public string ResimUrl { get; set; }

        public bool MusaitMi { get; set; } = true;

         public virtual ICollection<OduncIslem> OduncIslemleri { get; set; }
        public ICollection<Favori> Favoriler { get; set; }

    }
}

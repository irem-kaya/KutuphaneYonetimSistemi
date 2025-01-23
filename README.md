# Kütüphane Yönetim Sistemi

Kütüphane Yönetim Sistemi, bir kütüphanenin kullanıcı yönetimi, kitap ödünç verme işlemleri ve kitap yönetimi gibi işlevlerini etkin bir şekilde gerçekleştirmek için tasarlanmış bir web uygulamasıdır. Bu proje, kullanıcı dostu arayüzü ve dinamik özellikleri ile hem kullanıcıların hem de yöneticilerin ihtiyaçlarını karşılamayı hedefler.

---

## 🎯 **Projenin Özellikleri**

### Kullanıcı İşlevleri:
1. **Kayıt Ol ve Giriş Yap**:
   - Kullanıcılar, sisteme kayıt olabilir ve giriş yaparak kendi profillerine erişebilir.
   - Şifre ve kullanıcı adı doğrulaması.

2. **Kitaplara Göz At**:
   - Kullanıcılar, tüm kitapları listeleyebilir.
   - Kitaplar hakkında detaylı bilgi görüntüleyebilir.

3. **Kitap Ödünç Alma ve İade**:
   - Kullanıcılar, uygun kitapları ödünç alabilir.
   - Geçmiş ödünç alma kayıtları ve ceza bilgileri izlenebilir.

4. **Favori Kitaplar**:
   - Kitaplar, favorilere eklenebilir ve favori listesi görüntülenebilir.

### Yönetici İşlevleri:
1. **Kitap Yönetimi**:
   - Kitap ekleme, güncelleme ve silme işlemleri yapılabilir.
   - Kitap detayları (ISBN, yazar, yayın yılı, tür vb.) düzenlenebilir.

2. **Kullanıcı Yönetimi**:
   - Kullanıcıların durumu (aktif/pasif) görüntülenebilir.


3. **Ödünç Alma Takibi**:
   - Kullanıcıların aktif ve geçmiş ödünç alma işlemleri görüntülenebilir.
   - Gecikme cezaları ve iade durumları kontrol edilebilir.

---

## 🚀 **Kullanım Rehberi**

### 1. **Projenin Çalıştırılması**:
- Proje dosyalarını indirip bir geliştirme ortamında açın (Visual Studio gibi).
- Gerekli bağımlılıkları yükleyin (ör. Entity Framework, Bootstrap).
- Veritabanı yapılandırmasını tamamlayın ve `update-database` komutunu çalıştırarak veritabanını oluşturun.
- Projeyi `F5` ile çalıştırarak yerel sunucuda başlatın.

### 2. **Giriş ve Kayıt İşlemleri**:
- Yeni kullanıcı kaydı oluşturmak için "Kayıt Ol" seçeneğini kullanın.
- Mevcut bir kullanıcı hesabıyla giriş yapmak için "Giriş Yap" seçeneğini kullanın.

### 3. **Kitap Yönetimi**:
- Admin panelinden kitap ekleme, güncelleme ve silme işlemleri yapılabilir.

### 4. **Kullanıcı Yönetimi**:
- Kullanıcılar, aktif/pasif duruma getirilebilir.
- Pasif durumdaki kullanıcıların sisteme erişimi engellenir.

---

## 📸 **Proje Görselleri**

### Ana Sayfa
Kullanıcıların sisteme giriş yaptıktan sonra karşılaştığı hoş geldiniz ekranı.

![Ana Sayfa](link_to_image)

### Kitap Listesi
Kütüphanede mevcut kitapların listesi.

![Kitap Listesi](![Ekran görüntüsü 2025-01-23 122416](https://github.com/user-attachments/assets/4bb34136-2909-462e-b44c-fa7139719a94)
)

### Kullanıcı Listesi
Adminlerin tüm kullanıcıları görebildiği ve durumlarını değiştirebildiği liste.

![Kullanıcı Listesi](link_to_image)

### Kitap Detayları ve Ödünç Alma
Kitapların detaylı bilgileri ve ödünç alma işlemleri.

![Kitap Detayları](link_to_image)

---

## 🛠️ **Teknik Bilgiler**
- **Dil ve Teknolojiler**:
  - ASP.NET Core MVC
  - Entity Framework Core
  - JavaScript & jQuery
  - Bootstrap 5
- **Veritabanı**:
  - Microsoft SQL Server
- **Frontend**:
  - HTML5, CSS3

---

## 📜 **Geliştirici Notları**
- Proje, kullanıcı dostu bir deneyim sunmak için modern bir tasarımla geliştirildi.
- Veritabanı güvenliği ve veri doğrulama mekanizmaları uygulanmıştır.
- Geliştirilmeye açık alanlar: Mobil uyumluluk, API entegrasyonu, daha gelişmiş filtreleme.

---

## 💡 **Gelecek Planlar**
- Kullanıcılar için kitap değerlendirme ve yorum sistemi.
- API desteği ile mobil uygulama entegrasyonu.
- Yönetici paneline istatistiksel raporlama eklenmesi.

---

## 📬 **İletişim**
Eğer proje hakkında herhangi bir sorunuz veya öneriniz varsa, lütfen benimle iletişime geçmekten çekinmeyin.

---

**Not:** Görselleri yükledikten sonra bağlantıları **[link_to_image]** ile değiştirin ve projeyi GitHub'da paylaşabilirsiniz!

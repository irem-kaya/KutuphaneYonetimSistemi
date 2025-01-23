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
- Ödünç işlemleri için giriş yapmak zorunludur.

### 3. **Kitap Yönetimi**:
- Admin panelinden kitap ekleme, güncelleme ve silme işlemleri yapılabilir.

### 4. **Kullanıcı Yönetimi**:
- Kullanıcıların geçmiş ve şimdiki ödünç işlemleri görüntülenebilir.
  
### 5. **Gelişmiş Arama**
- Yazar ve kitap adına göre arama yapılabilir.

---

## 📸 **Proje Görselleri**

### Giriş Yap ve Kayit Ol Ekranları
![Ekran görüntüsü 2025-01-23 130731](https://github.com/user-attachments/assets/6ac3596f-16f3-4afc-b1f7-482a1619b43a)
![Ekran görüntüsü 2025-01-23 130801](https://github.com/user-attachments/assets/0b9037cb-0e26-4226-914d-8124bb761f97)

## Kullanici Sayfalari

### Ana Sayfa
Kullanıcıların sisteme giriş yaptıktan sonra karşılaştığı hoş geldiniz ekranı.
![Ekran görüntüsü 2025-01-23 122911](https://github.com/user-attachments/assets/52b27ce4-3d84-4ab9-854d-8bc707889315)

#### Kitaplara Göz At
![Ekran görüntüsü 2025-01-23 123002](https://github.com/user-attachments/assets/03d34913-7ba0-4577-b9b1-6731e600a49e)

### Kitap Detayları, Ödünç Alma ve Gecikme Cezaları 
Kitapların detaylı bilgileri ve ödünç alma işlemleri.
![image](https://github.com/user-attachments/assets/d0b8c1cc-d5a3-4790-a324-0ba20874cc88)
![Ekran görüntüsü 2025-01-23 123205](https://github.com/user-attachments/assets/86657f10-e0b5-4982-9b1f-1e936c037787)
![image](https://github.com/user-attachments/assets/b626bdb8-13c5-428b-8620-fd03ecbde03b)


### Hakkımızda Sayfası
![Ekran görüntüsü 2025-01-23 123602](https://github.com/user-attachments/assets/5d35d245-2acd-4ad4-aa23-0cd0af4483a6)

### Bize Ulaşın Sayfası
![image](https://github.com/user-attachments/assets/c2c5d37d-e3f8-44bc-a03a-c5126db1260f)

### Favorileme ve Favorileri Görüntüleme
Kullanıcının favorilediği kitaplar listesi.
![Ekran görüntüsü 2025-01-23 123321](https://github.com/user-attachments/assets/a9d126b3-c20c-48c8-a080-03d0ab5b1187)
![Ekran görüntüsü 2025-01-23 123500](https://github.com/user-attachments/assets/f3d46bc0-eb28-4869-9054-2d1cbb81d84a)

## Admin Sayfaları 
### Ana Sayfa
Sisteme giriş yaptıktan sonra karşılaştığı hoş geldiniz ekranı.
![image](https://github.com/user-attachments/assets/1ef6f907-1251-4279-b610-94074472cbaf)

### Kitap Ekleme Paneli
![image](https://github.com/user-attachments/assets/39fcfbd6-6182-4968-b1bd-d69cf82ee6ec)
![image](https://github.com/user-attachments/assets/0667359e-8b50-4349-8463-d0fd6d50680d)
![image](https://github.com/user-attachments/assets/93baa4a4-2124-49d4-a12f-e15866739cb8)

### Kitapları Yönet Paneli
![image](https://github.com/user-attachments/assets/f9e6e0c8-a534-497d-a472-ba163cc707f2)

### Kullanicilari Yönet Paneli
![image](https://github.com/user-attachments/assets/6416af51-a262-4cc3-bd1e-9f61aabb9a06)

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

### Veritabanı Yapısı
![Ekran görüntüsü 2025-01-23 134618](https://github.com/user-attachments/assets/fbf043f4-40c4-4502-b790-a61595107936)


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


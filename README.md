# FlightRezervation Uygulaması
**FlightRezervation uygulaması, uçak rezervasyonu yapılabilecek bir ASP.NET MVC projesidir. Bu uygulama kullanıcıların uçak ve güzergah kayıtlarını yapmalarına, rezervasyon oluşturmalarına ve bilet satın almalarına olanak sağlar.**
  <hr/>
  
# **Özellikler**
### 1.MVC Yapısı Kullanıldı:
Proje ASP.NET Core MVC yapısını kullanarak oluşturuldu.

### 2.Annotation Kullanımı ve Configuration:
Projedeki her tablo için ayrı ayrı yapılandırma dosyaları oluşturuldu.

### 3.Migration:
Migration yapıldıktan sonra, veritabanı değişikliklerinin sürekli olarak güncellenmesi sağlandı. Program.cs dosyasında bazı ayarlamalar yapıldı ve uygulama her başlatıldığında veritabanı otomatik olarak güncellenir.

### 4.Admin ve Kullanıcı Rolleri:
 Sistemde Admin ve Kullanıcı olmak üzere iki farklı rol bulunmaktadır. Kullanıcılar rollere göre farklı yetkilere sahiptir.
 
### 5.Kimlik Doğrulama (Authentication):
Cookie tabanlı kimlik doğrulama sistemi kullanıldı. Eğer kullanıcı giriş yapmamışsa, diğer sayfalara erişmeye çalıştığında otomatik olarak Login sayfasına yönlendirilir.

### 6.Çok Dilli Destek (Localization):
Projede Localization yapısı kullanıldı. Sistem, kullanıcının dilini otomatik algılar ve uygulama o dilde çalışır. Ek olarak, uygulama dil seçeneklerini değiştirme imkanı sunar.

![Türkçe](https://github.com/tarikdemir4/FlightReservation.MVC/blob/main/FlightReservation/FlightReservation.MVC/wwwroot/pictures/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-09-18%20155422.png)

![İngilizce](https://github.com/tarikdemir4/FlightReservation.MVC/blob/main/FlightReservation/FlightReservation.MVC/wwwroot/pictures/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-09-18%20163323.png)
### 7.Kayıt ve Giriş (Register ve Login Sayfaları):
Kullanıcılar, SignIn ve SignOut işlemlerini Cookie tabanlı yaparak sisteme giriş ve çıkış yapabilir.
![Kayıt Formu](https://github.com/tarikdemir4/FlightReservation.MVC/blob/main/FlightReservation/FlightReservation.MVC/wwwroot/pictures/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-09-18%20162015.png)
![Giriş Formu](https://github.com/tarikdemir4/FlightReservation.MVC/blob/main/FlightReservation/FlightReservation.MVC/wwwroot/pictures/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-09-18%20161955.png)

### 8.Repository Pattern:
Repository Pattern kullanılarak uygulamanın daha okunaklı hale gelmesi ve kompleks yapıların azaltılması sağlandı. 

### 9.Uçak Ekleme:

Uçak bilgileri kayıt edilerek, sistemde kullanılabilir uçakların listesi oluşturulur.
![Uçak Ekleme](https://github.com/tarikdemir4/FlightReservation.MVC/blob/main/FlightReservation/FlightReservation.MVC/wwwroot/pictures/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-09-18%20162904.png)

### 10.Güzergah  Ekleme:
Kullanıcılar, uçaklara atanacak güzergahları sisteme ekleyebilir. Bu güzergahlar daha sonra uçaklara atanır.
![Güzergah Ekleme](https://github.com/tarikdemir4/FlightReservation.MVC/blob/main/FlightReservation/FlightReservation.MVC/wwwroot/pictures/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-09-18%20155500.png)

### 11.Bilet Seçimi ve Satın Alma:
Kullanıcılar, güzergahları arayıp bilet seçimi yapabilir ve bilet satın alabilir. Satın alma işlemi tamamlandığında, kullanıcıya bir bilet sayfası sunulur.
![Güzergah Ekleme](https://github.com/tarikdemir4/FlightReservation.MVC/blob/main/FlightReservation/FlightReservation.MVC/wwwroot/pictures/Ekran%20g%C3%B6r%C3%BCnt%C3%BCs%C3%BC%202024-09-18%20155614.png)
  <hr/>

# Proje Nasıl Çalışır?
Uygulama açıldığında, kullanıcılar giriş yapabilir veya kayıt olabilir.
Admin panelinden uçak ve güzergah kayıtları yapılabilir.
Güzergahlar oluşturulduktan sonra uçaklar bu güzergahlara atanabilir.
Kullanıcılar bilet arayarak, uygun uçuşları bulabilir ve bilet satın alabilir.
Kullanıcı giriş yapmamışsa, giriş sayfasına yönlendirilir.
Proje çok dilli destekle çalışmaktadır. Kullanıcı dilediği dili seçerek uygulamayı o dilde kullanabilir.

  <hr/>

# Kullanılan Teknolojiler  <br/>

1.ASP.NET Core MVC  <br/>
2.Entity Framework Core  <br/>
3.SQL Server  <br/>
4.Repository Pattern  <br/>
5.Authentication & Authorization  <br/>
6.Localization (Çok Dilli Destek)  <br/>

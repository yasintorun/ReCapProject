# Recap Project - Araç Kiralama Sistemi

Bu proje Engin Demiroğ hocanın C# ve Angular kampı boyunca geliştirilen __Araç Kiralama Sistemidir__.

<br>
<br>

## 📌Başlangıç

Katmanlı mimari yapısı ile hazırlanan, EntityFramework kullanarak veritabanı işlemlerinin halledildiği, .Net Core Web Api ile çalışan bir backend projesidir.
Proje, __Solid Prensiblerine ve Design Pattern kurallarına__ uygun hazırlanmıştır. 

<br>
<br>

## Veritabanı

Projede veritabanı olarak mssql kullanılmıştır. Proje localDb ile çalışmaktadır. LocalDb veritabanını Visual Studio programı içerisindeki SQL Server Object Explorer penceresi ile oluşturabiliriz. New Query diyerek verilen sql dosyasını çalıştırabilirsiniz.

📄 [RecapProject.sql](https://github.com/yasintorun/ReCapProject/blob/main/RecapProject.sql)

<br>
<br>

### Veritabanı Tabloları
Projede kullanılan tüm tablolar aşağıdaki fotoğrafta gözüktüğü gibidir.
<br>
![Database Er!](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/tables.png)

<br>
<br>

## 📚 Katmanlar

Proje katmanli mimari kulanılarak hazırlanmıştır. Temel 5 katmanımız bulunmaktadır. Bu katmanlar __Entities, DataAccess, Business, Core ve WebApi__ katmanlarıdır.<br>
Çoğu katmanda yer alan iki ana klasör bulunmaktadır. Bunlar __Abstract__ ve __Concrete__ klasörleridir. <br>
__Abstract:__ Soyut nesnelerinin tutulduğu klasördür.<br>
__Concrete:__ Soyut nesnelerden türeyen somut nesnelerin tutulduğu klasördür.<br>

<br>
<br>

### Entities Katmanı
Veritabanındaki tabloların karşılığı bu katmanda tutuluyor. Her bir tablo için bir entity oluşturmamız gerekiyor. Ayrıca __Dto__(Data Transfer Object) ile çaşitli entityleri kapsayan kendi nesnelerimizi oluşturabiliyoruz.<br>

![Entity Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/entities.JPG)

<br>
<br>

### DataAccess Katmanı
Veritabanı CRUD (Ekleme, Okuma, Güncelleme ve Silme) işlemlerini EntityFramework kullanarak bu katmanda hallediyoruz. Bu katman Core ve Entity katmanını referans alır. Diğer katmanlardan referans almaz.

![DataAccess Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/dataAccess.JPG)

<br>
<br>

### Business Katmanı 
Bu katman, uygulama katmanı(Web Api) ile DataAccess katmanı arasındaki veri işleme olayını gerçekleştirir. Bir nevi ikisi arasında köprü görevi görür. Bu katmanın önemli kısmı ise tüm doğrulama ve veri kontolünü gerçekleştirmesidir. <br>
Bu katmanda __Abstact, Concrete, Adapters, DependencyResolvers, ValidationRules ve Constant__ klasörleri bulunmaktadır. <br>

__Adapters:__ Dış servisleri projeye entegre ettiğimiz klasördür. Örneğin, kullanıcı Findeks puanını sorgulama işlemi burada gerçekleşir.<br>

__DependencyResolvers:__ Projedeki IoC yönetimi burada yer almaktadır. Yani tüm instance yönetimi bu klasörde yer almaktadır. Projede AutoFac kütüphanesi kullanılmıştır. 

__ValidationRules:__ Verileri kontrol ettiğimiz klasördür. Burada nesnenin verisinin ne olduğu, neleri alabileceklerini tanımlıyoruz. Örneğin bir arabanın fiyatı boş olamaz ve günlük fiyatı 0 ile 10.000 arasında olabilir.

__Constants:__ Bu klasörde business katmanında kullandığımız değişmeyen değerleri tutuyoruz. Örneğin; Messages sınıfı. 

![Business Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/business_1.JPG) <br>
![Business Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/business_2.JPG)

### Core Katmanı
Bu katman, projeden bağımsız olarak projenin ana çekirdek kısımlarını oluşturuyor. __Bu katman asla diğer katmanları referans almaz.__ Bu katmanı istediğimiz herhangi bir projede hiç değişiklik yapmadan aynen kullanabiliriz. <br>
Bu katmanda, __Aspects, CrossCuttingConcerns, DataAccess, Entities, Extensions, Utilities ve DependencyResolver__ klasörleri yer almaktadır. 

__Aspects:__ Cache, performance, Transaction ve validation işlemlerinin yani AOP işlemlerinin yapıldığı klasördür.

__CrossCuttingConcers:__ CCC işlemlerinin yapıldığı klasördür. Cache ve validation işlemleri bulunur.

__DataAccess:__ Bu katmanda DataAccess katmanında yer alan Temel interface yapıları ve EntityFramework için genel Base sınıf bulunmaktadır. 

__Entities:__ Birbirinden bağımsız tüm projelerde yer alacak genel interface ve ana sınıflar bulunmaktadır. 

__Extensions:__ Kullandığımız hazır sistemlere ek özelliklerin eklendiği klasördür.

__DependencyResolver:__ Core katmanında yer alan sistemlerin instance yönetimini sağladığımız klasördür.

__Utilities:__ Core katmanının belkide en önemli kısmı bu diyebiliriz. Tüm alt araçların yer aldığı bu klasörde, __Helper sınıflar, Interceptors, IoC, Results ve Security__ klasörleri bulunmaktadır. Bu klasörleri kısaca açıklar isek;<br>
&nbsp;&nbsp;&nbsp;&nbsp; __Helpers:__ Tüm projelerde yer alacabilecek yardımcı sınıfların yer aldığı klasördür.<br>
&nbsp;&nbsp;&nbsp;&nbsp; __Interceptors:__ AOP yapısının kurulduğu ve Attributelerin yönetildiği yerdir.<br>
&nbsp;&nbsp;&nbsp;&nbsp; __IoC:__ IoC yapısının yer aldığı yerdir.<br>
&nbsp;&nbsp;&nbsp;&nbsp; __Results:__ Bu klasörde uygulama boyunca verilerin yönetebilmeyi kolaylaştıran sınıflar yer almaktadır.Verinin bilgisi, mesaj bilgisi veya dönen verinin success bilgisini içerir. <br>
&nbsp;&nbsp;&nbsp;&nbsp; __Security:__ Jwt yapısının yer aldığı klasördür.

![Business Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/core_1.JPG) <br>
![Business Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/core_2.JPG) <br>
![Business Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/core_3.JPG)

<br>
<br>

### Web Api
Bu katman, .Net Core Web Api projesi olarak inşa edilmiştir. Bu katmanda yazdığımız servisleri api olarak dışarı aktarıyoruz. Bu katmanda controller klasörü bulunmaktadır. Bu klasörde oluşturduğumuz tüm controller yer almaktadır. Tüm kontrollerdeki ortak olan işlemler olduğu için __ResponseControllerBase__ abstract sınıfı yazılmıştır. Tüm controller'lar bu sınıftan türetilmiştir.

![Business Katmanı](https://raw.githubusercontent.com/yasintorun/ReCapProject/main/ScreenShots/webApi.JPG)

<br>
<br>
<br>

__Yasin Torun 2021__
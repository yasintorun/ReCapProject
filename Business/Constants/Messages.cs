using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Genel Mesajlar.


        //Genel hata mesajları
        public static string ErrorOccurred = "Hata oluştu";

        //Brand messages
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string BrandGot = "Marka getirildi.";
        public static string BrandUpdated = "Marka güncellendi.";

        //Car messages
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi.";
        public static string CarListed = "Arabalar listelendi.";
        public static string CarGot = "Araba getirildi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarListedByColor = "Arabalar renge göre listelendi";
        public static string CarListedByBrand = "Arabalar markaya göre listelendi.";
        public static string CarListedInDetail = "Arabalar detaylı listelendi.";

        //Car Error messages
        public static string CarNameAtLeast2Char = "Araba adı en az 2 karakter olabilir.";
        public static string CarDailyPriceNotZero ="Arabanın günlük kirası sıfırdan düşük olamaz.";


        //Color messages
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorListed = "Renk listelendi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorGot = "Renk getirildi";


        //User messages
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserListed = "Kullanıcılar listelendi.";
        public static string UserGot = "Kullanıcı getirildi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        

        //Customer messages
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerListed = "Müşteriler listelendi.";
        public static string CustomerGot = "Müşteri getirildi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";


        //Rental messages
        public static string RentalAdded = "Araba Kiralandı.";
        public static string RentalDeleted = "Araba teslim edildi.";
        public static string RentalListed = "Araba kiraları listelendi.";
        public static string RentalGot = "Araba kiralama bilgileri getirildi.";
        public static string RentalUpdated = "Araba kiralama bilgileri güncellendi.";
        public static string RentalGetCarId = "Araba kira bilgisi getirildi";


        public static string NoCarRentalInfo = "Araba kira bilgisi bulunmuyor.";
        public static string CarRented = "Araba zaten kiralanmış.";

        //Car Image messages
        public static string CarImageUpdated = "Araba fotoğrafları güncellendi.";
        public static string CarImageListed = "Araba fotoğrafları listelendi.";
        public static string CarImageGot = "Araba fotoğrafı getirildi";
        public static string CarImageDeleted = "Araba fotoğrafı silindi";
        public static string CarImageAdded = "Araba fotoğrafı eklendi";
        public static string ImageLimitExceded = "En fazla 5 adet Fotoğraf koyabilirsiniz.";
        public static string CarImagesGetByCar = "Araba fotografları listelendi";
        
        //auth
        public static string AuthorizationDenied = "Erişim engellendi";
        public static string UserRegistered = "Kayıt başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated = "Token oluşturuldu";


        public static string CreditCardAdded = "Kredi kartı kaydedildi";
        public static string CreditCardDeleted = "Kredi kartı silindi";
        public static string CreditCardListed = "Kredi kartları listelendi";
        public static string CreditCardGot = "Kredi kartı getirildi";
        public static string CreditCardUpdated = "Kredi kartı güncellendi";

        public static string PaySuccess = "Ödeme başarılı";
        public static string PaymentListed = "Tüm ödeme bilgileri listelendi";
    }
}

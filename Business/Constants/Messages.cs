using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Genel Mesajlar.


        //Genel hata mesajları
        internal static string ErrorOccurred = "Hata oluştu";

        //Brand messages
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string BrandGot = "Marka getirildi.";
        public static string BrandUpdated = "Marka güncellendi.";

        //Car messages
        internal static string CarAdded = "Araba eklendi";
        internal static string CarDeleted = "Araba silindi.";
        internal static string CarListed = "Arabalar listelendi.";
        internal static string CarGot = "Araba getirildi.";
        internal static string CarUpdated = "Araba güncellendi.";
        internal static string CarListedByColor = "Arabalar renge göre listelendi";
        internal static string CarListedByBrand = "Arabalar markaya göre listelendi.";
        internal static string CarListedInDetail = "Arabalar detaylı listelendi.";

        //Car Error messages
        public static string CarNameAtLeast2Char = "Araba adı en az 2 karakter olabilir.";
        internal static string CarDailyPriceNotZero ="Arabanın günlük kirası sıfırdan düşük olamaz.";


        //Color messages
        internal static string ColorAdded = "Renk eklendi";
        internal static string ColorDeleted = "Renk silindi";
        internal static string ColorListed = "Renk listelendi";
        internal static string ColorUpdated = "Renk güncellendi";
        internal static string ColorGot = "Renk getirildi";


        //User messages
        internal static string UserAdded = "Kullanıcı eklendi.";
        internal static string UserDeleted = "Kullanıcı silindi.";
        internal static string UserListed = "Kullanıcılar listelendi.";
        internal static string UserGot = "Kullanıcı getirildi.";
        internal static string UserUpdated = "Kullanıcı güncellendi.";
        

        //Customer messages
        internal static string CustomerAdded = "Müşteri eklendi";
        internal static string CustomerDeleted = "Müşteri silindi.";
        internal static string CustomerListed = "Müşteriler listelendi.";
        internal static string CustomerGot = "Müşteri getirildi.";
        internal static string CustomerUpdated = "Müşteri güncellendi.";


        //Rental messages
        internal static string RentalAdded = "Araba Kiralandı.";
        internal static string RentalDeleted = "Araba teslim edildi.";
        internal static string RentalListed = "Araba kiraları listelendi.";
        internal static string RentalGot = "Araba kiralama bilgileri getirildi.";
        internal static string RentalUpdated = "Araba kiralama bilgileri güncellendi.";
        internal static string RentalGetCarId = "Araba kira bilgisi getirildi";


        internal static string NoCarRentalInfo = "Araba kira bilgisi bulunmuyor.";
        internal static string CarRented = "Araba zaten kiralanmış.";

        //Car Image messages
        internal static string CarImageUpdated = "Araba fotoğrafları güncellendi.";
        internal static string CarImageListed = "Araba fotoğrafları listelendi.";
        internal static string CarImageGot = "Araba fotoğrafı getirildi";
        internal static string CarImageDeleted = "Araba fotoğrafı silindi";
        internal static string CarImageAdded = "Araba fotoğrafı eklendi";
        internal static string ImageLimitExceded = "En fazla 5 adet Fotoğraf koyabilirsiniz.";
        internal static string CarImagesGetByCar = "Araba fotografları listelendi";
    }
}

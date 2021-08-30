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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string GetByIdNull = "Bu ID'ye sahip kayıt bulunmuyor.";
        public static string GetAllError = "Veriye erişilemedi.";
        public static string Added = "Veri başarıyla eklendi.";
        public static string Updated = "Veri başarıyla güncellendi.";
        public static string Deleted = "Veri başarıyla silindi.";
        public static string AddedError = "Veri eklenemedi.";
        public static string DeletedError = "Veri silinemedi.";
        public static string UpdatedError = "Veri güncellenemedi.";
        public static string EmptyData = "Bu kategoride kayıt bulunmamaktadır.";

        public static string ProductAdded   = "Ürün başarıyla eklendi";
        public static string ProductDeleted = "Ürün başarıyla silindi";
        public static string ProductUpdated = "Ürün başarıyla güncellendi";

        public static string BrandAdded   = "Marka başarıyla eklendi";
        public static string BrandDeleted = "Marka başarıyla silindi";
        public static string BrandUpdated = "Marka başarıyla güncellendi";

        public static string CarAdded   = "Araba başarıyla eklendi";
        public static string CarAddedError = "Araba eklenemedi";
        public static string CarDeleted = "Araba başarıyla silindi";
        public static string CarDeletedError = "Araba silinemedi";
        public static string CarUpdated = "Araba başarıyla güncellendi";
        public static string CarUpdatedError = "Araba güncellenemedi";
        public static string CarGetAllError = "Araba listesine erişilemedi";
        public static string CarDailyPriceInvalid = "Lütfen geçerli fiyat giriniz.";
        public static string CarGetByIdNull = "Bu ID'ye sahip araç bulunmuyor.";
        public static string CarGetBrandByIdNull = "Bu markaya sahip araç bulunmuyor.";
        public static string CarGetByColorIdNull = "Bu renkte araç bulunmuyor.";
        public static string NoCar = "Sistemde kayıtlı araç bulunmuyor.";

        public static string RentalGetAllError = "Kiralama listesine erişilemedi"; 
        public static string CarRental = "Araç zaten şuanda kirada.";
        public static string RentalAdded = "Araç kiraya verildi.";
        public static string RentalDeleted = "Kayıt başarıyla silindi";
        public static string RentalUpdated = "Kayıt başarıyla güncellendi";
        public static string RentalDeletedError = "Kayıt silinemedi.";
        public static string RentalUpdatedError = "Kayıt güncellenemedi";
        public static string RentalCarGetByIdNull = "Bu araca sahip kayıt bulunmuyor.";
        public static string NoRental = "Kirada araç bulunmuyor.";

        public static string ColorAdded   = "Renk başarıyla eklendi";
        public static string ColorDeleted = "Renk başarıyla silindi";
        public static string ColorUpdated = "Renk başarıyla güncellendi";

        public static string UserAdded   = "Kullanıcı başarıyla eklendi";
        public static string UserDeleted = "Kullanıcı başarıyla silindi";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi";

        //public static string UserNotFound = "Kullanıcı bulunamadı";
        //public static string PasswordError = "Şifre hatalı";
        //public static string SuccessfulLogin = "Sisteme giriş başarılı";
        //public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        //public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        //public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        //public static string AuthorizationDenied = "Yetkiniz yok";
        //public static string ProductNameAlreadyExists = "Ürün ismi zaten mevcut";
    }
}

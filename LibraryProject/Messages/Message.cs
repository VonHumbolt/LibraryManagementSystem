using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Messages
{
    public static class Message
    {
        public static string AddedMessage = "Başarıyla eklendi!";

        public static string DeletedMessage = "Silindi";

        public static string UpdatedMessage = "Güncellendi";

        public static string AuthorizationDenied = "Yetkilendirme Başarısız";

        public static string TokenCreated = "Access Token Oluşturuldu";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Email veya parola hatalı!";

        public static string RegisteredMessage = "Kayıt işlemi başarılı";

        public static string UserAlreadyExists = "Kullanıcı zaten oluşturulmuş";

        public static string UserBooksLimitIsFull = "Üzgünüz. Bir kullanıcı en fazla 5 kitap alabilir.";

        public static string ExtensionSuccess = "Kitabın süresi uzatılmıştır.";

        public static string BorrowSuccess = "İşlem Başarılı! Lütfen ödünç aldığınız kitapları süresinde teslim ediniz.";

        public static string SuccessfullyReturnedBook = "Kitap iade işlemi başarılı";

        public static string BookIsAlreadyAddedInList = "Kitap zaten okuma listenizde ekli";

        public static string BookAddedIntoReadingList = "Kitap Okuma Listesine Eklendi";

        public static string BookDeletedInReadingList = "Kitap Listeden çıkarıldı";
    }
}

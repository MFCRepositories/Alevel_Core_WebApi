using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Constans
{
    /// <summary>
    /// Magic Striglerin yönetilmesi için kullanılacak.
    /// </summary>
    public static class Message
    {
        public static string AddSuccess { get; set; } = "Ekleme İşlemi Başarılı!!!";
        public static string DeleteSuccess { get; set; } = "Silme İşlemi Başarılı!!!";
        public static string UpdateSuccess { get; set; } = "Güncelleme İşlemi Başarılı!!!";
        public static string GetSuccess { get; set; } = "Listeleme İşlemi Başarılı!!!";

        public static string AddError { get; set; } = "Ekleme İşlemi Sırasında Hata!!!";
        public static string DeleteError { get; set; } = "Silme İşlemi Sırasında Hata!!!";
        public static string UpdateError { get; set; } = "Güncelleme İşlemi Sırasında Hata!!!";
        public static string GetError { get; set; } = "Listeleme İşlemi Sırasında Hata!!!";

        public static string AddInfo { get; set; } = "Ekleme İşlemi Bilgi!!!";
        public static string DeleteInfo { get; set; } = "Silme İşlemi Bilgi!!!";
        public static string UpdateInfo { get; set; } = "Güncelleme İşlemi Bilgi!!!";
        public static string GetInfo { get; set; } = "Listeleme İşlemi Bilgi!!!";

        public static string DeleteNotFound { get; set; } = "Silinecek Nesne Bulunamadı!!!";
        public static string UpdateNotFound { get; set; } = "Güncellenecek Nesne Bulunamdı!!!";
        public static string GetNotFound { get; set; } = "Nesne Bulunamadı!!!";
    }
}

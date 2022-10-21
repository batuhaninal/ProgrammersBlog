using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.Utilities
{
    public static class Messages
    {
        public static class Category
        {
            public static string NotFound(bool isPlural = false)
            {
                if (isPlural) return "Hic kategori bulunamadi";
                return "Boyle bir kategori bulunamadi";
            }

            public static string Add(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla eklenmistir.";
            }

            public static string Update(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla guncellenmistir.";
            }

            public static string Delete(string categoryName)
            {
                return $"{categoryName} adli kategori basariyla silinmistir.";
            }

            public static string HardDelete(string categoryName)
            {
                return $"{categoryName} adli kategori veritabanindan basariyla silinmistir.";
            }
        }

        public static class Article
        {
            public static string NotFound(bool isPlural = false)
            {
                if (isPlural) return "Hic makale bulunamadi";
                return "Boyle bir makale bulunamadi";
            }
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ProgrammersBlog.Entities.Concrete;

namespace ProgrammersBlog.Mvc.Areas.Admin.Models
{
    public class ArticleUpdateViewModel
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Baslik")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alani {1} karakterden buyuk olmamalidir.")]
        [MinLength(2, ErrorMessage = "{0} alani {1} karakterden kucuk olmamalidir")]
        public string Title { get; set; }

        [DisplayName("Icerik")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        [MinLength(2, ErrorMessage = "{0} alani {1} karakterden kucuk olmamalidir")]
        public string Content { get; set; }

        [DisplayName("Kucuk Resim Ekle")]
        public IFormFile? ThumbnailFile { get; set; }

        [DisplayName("Kucuk Resim")]
        public string? Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Yazar Adi")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} alani {1} karakterden buyuk olmamalidir.")]
        [MinLength(1, ErrorMessage = "{0} alani {1} karakterden kucuk olmamalidir")]
        public string SeoAuthor { get; set; }

        [DisplayName("Makale Aciklamasi")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        [MaxLength(150, ErrorMessage = "{0} alani {1} karakterden buyuk olmamalidir.")]
        [MinLength(1, ErrorMessage = "{0} alani {1} karakterden kucuk olmamalidir")]
        public string SeoDescription { get; set; }

        [DisplayName("Makale Etiketler")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} alani {1} karakterden buyuk olmamalidir.")]
        [MinLength(5, ErrorMessage = "{0} alani {1} karakterden kucuk olmamalidir")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        public int CategoryId { get; set; }
        public IList<Category>? Categories { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} alani bos gecilmemelidir.")]
        public bool IsActive { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}

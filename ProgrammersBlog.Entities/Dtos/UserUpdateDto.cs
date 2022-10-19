using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [DisplayName("Kullanici Adı")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(3, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        public string UserName { get; set; }

        [DisplayName("E-Posta Adresi")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(10, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DisplayName("Telefon Numarasi")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(13, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(13, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim Ekle")]
        [DataType(DataType.Upload)]
        public IFormFile? PictureFile { get; set; }

        [DisplayName("Resim")]
        public string? Picture { get; set; }
    }
}

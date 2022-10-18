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
    public class UserAddDto
    {
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

        [DisplayName("Sifre")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Telefon Numarasi")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(13, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(13, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DisplayName("Resim")]
        [Required(ErrorMessage = "Lutfen bir {0} seciniz.")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string? Picture { get; set; }
    }
}

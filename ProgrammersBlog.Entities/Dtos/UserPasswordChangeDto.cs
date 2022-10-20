using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class UserPasswordChangeDto
    {
        [DisplayName("Suanki Sifreniz")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("Yeni Sifreniz")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Yeni Sifrenizin Tekrari")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(5, ErrorMessage = "{0} {1} kucuk olmamalidir.")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Girmis oldugunuz yeni sifreniz ile yeni sifrenizin tekrar alanlari birbiriyle uyusmalidir.")]
        public string RepeatPassword { get; set; }
    }
}

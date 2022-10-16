using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int CategoryId { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(2, ErrorMessage = "{0} {1} az olmamalidir.")]
        public string Name { get; set; }

        [DisplayName("Kategori Aciklamasi")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(2, ErrorMessage = "{0} {1} az olmamalidir.")]
        public string Description { get; set; }

        [DisplayName("Kategori Ozel Not Alani")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden buyuk olmamalidir.")]
        [MinLength(2, ErrorMessage = "{0} {1} az olmamalidir.")]
        public string Note { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        public bool IsActive { get; set; }

        [DisplayName("Silindi mi?")]
        [Required(ErrorMessage = "{0} boş gecilmemelidir.")]
        public bool IsDeleted { get; set; }
    }
}

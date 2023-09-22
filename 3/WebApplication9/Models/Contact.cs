using System.ComponentModel.DataAnnotations;
using System;

namespace WebApplication9.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        [Required(ErrorMessage = "Doğum Tarihi alanı gereklidir.")]
        public DateTime BirthDate { get; set; }

        [Range(0, 120, ErrorMessage = "Yaş 0 ile 120 arasında olmalıdır.")]
        [Required(ErrorMessage = "Yaş alanı gereklidir.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Şehir alanı gereklidir.")]
        public string City { get; set; }
    }
}

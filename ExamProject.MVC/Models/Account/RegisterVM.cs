
using System.ComponentModel.DataAnnotations;

namespace ExamProject.MVC.Models.Account
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "İsim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        [Display(Name ="Adınız")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        [MaxLength(50, ErrorMessage = "50 karakterden fazla olmaz")]
        [Display(Name = "Soyadınız")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        [EmailAddress(ErrorMessage ="Geçerli bir mail adresi giriniz!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Şifre belirleniz gerekmektedir!")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Şifreniz birbiriyle uyuşmuyor!")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Onay")]
        public string ConfirmPassword { get; set; }
    }
}

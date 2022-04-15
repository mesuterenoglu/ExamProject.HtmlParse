

using System.ComponentModel.DataAnnotations;

namespace ExamProject.MVC.Models.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Soyisim girişi zorunludur!")]
        [EmailAddress(ErrorMessage = "Geçerli bir mail adresi giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre belirleniz gerekmektedir!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Shop.Controllers
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Adres email jest wymagany.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
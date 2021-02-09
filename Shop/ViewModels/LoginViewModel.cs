using System.ComponentModel.DataAnnotations;

namespace Shop.Controllers
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email address required.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required.")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
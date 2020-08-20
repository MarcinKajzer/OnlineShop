using System.ComponentModel.DataAnnotations;

namespace Shop.Controllers
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public bool rememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
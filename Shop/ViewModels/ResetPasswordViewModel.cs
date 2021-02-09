using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter a new password..")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password.")]
        [Compare(nameof(Password), ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public string Token { get; set; }
    }
}

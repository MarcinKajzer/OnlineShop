using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Podaj nowe hasło.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Potwierdź hasło.")]
        [Compare(nameof(Password), ErrorMessage = "Hasła muszą do siebie pasować")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        public string Token { get; set; }
    }
}

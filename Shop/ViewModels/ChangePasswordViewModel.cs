using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Podaj obecne hasło.")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Podaj nowe hasło.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Potwierdź hasło.")]
        [Compare(nameof(NewPassword), ErrorMessage = "Hasła muszą do siebie pasować")]
        public string ConfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Pole imię jest wymagane.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pole nazwisko jest wymagane.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Adres email jest wymagany.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Powtórz hasło.")]
        [Compare(nameof(Password), ErrorMessage ="Hasła muszą do siebie pasować.")]
        public string ConfirmPassword { get; set; }
    }
}

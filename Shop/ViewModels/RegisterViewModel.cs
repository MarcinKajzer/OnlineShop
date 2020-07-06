using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First name is required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email is required.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        [Compare(nameof(Password), ErrorMessage ="These field does not match.")]
        public string ConfirmPassword { get; set; }

    }
}

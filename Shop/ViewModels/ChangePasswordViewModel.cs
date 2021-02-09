using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class ChangePasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Current password required.")]
        public string CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "New password required")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password.")]
        [Compare(nameof(NewPassword), ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}

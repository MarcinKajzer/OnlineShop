using Shop.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "First name required.")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name required.")]
        [MaxLength(50)]
        public string LastName { get; set; }

        public AdressDTO Adress { get; set; }
    }
}

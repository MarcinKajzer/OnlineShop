using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class UpdateProductViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Prica required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public double? Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public double? NewPrice { get; set; }


        [Required(ErrorMessage = "Product name required.")]
        [MinLength(20, ErrorMessage = "Minimum length is 20 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Opis produktu jest wymagany.")]
        [MinLength(50, ErrorMessage = "Minimum length is 50 characters.")]
        [MaxLength(1000, ErrorMessage = "Maximum length is 1000 characters.")]
        public string Description { get; set; }

        [MaxLength(50)]
        public string ImageName { get; set; }

        public bool IsArchived { get; set; }
        public bool IsDiscounted { get; set; }

        [Required]
        public Color Color { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Category Category { get; set; }

        
        public IFormFile Image { get; set; }


        [Required]
        public List<SizeInfoDTO> Sizes { get; set; }
    }
}

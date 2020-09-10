using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class CreateProductViewModel
    {
        public CreateProductViewModel()
        {
            foreach (Size size in Enum.GetValues(typeof(Size)))
            {
                Sizes.Add(new SizeInfoDTO() { Size = size, Quantity = 0 });
            }
        }

        [Required(ErrorMessage = "Product name required.")]
        [MinLength(20, ErrorMessage = "Minimum length is 20 characters.")]
        [MaxLength(100, ErrorMessage = "Maximum length is 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description required")]
        [MinLength(50, ErrorMessage = "Minimum length is 50 characters.")]
        [MaxLength(1000, ErrorMessage = "Maximum length is 1000 characters.")]
        public string Description { get; set; }

        [MaxLength(50)]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public double? Price { get; set; }

        
        [Required]
        public Color Color { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Image required.")]
        public IFormFile Image { get; set; }


        [Required]
        public List<SizeInfoDTO> Sizes { get; set; } = new List<SizeInfoDTO>();


    }
}

using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Nazwa produktu jest wymagana.")]
        [MinLength(20, ErrorMessage = "Minimalna długość to 20 znaków.")]
        [MaxLength(100, ErrorMessage = "Maksymalna długość to 100 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Opis produktu jest wymagany.")]
        [MinLength(50, ErrorMessage = "Minimalna długość to 50 znaków.")]
        [MaxLength(1000, ErrorMessage = "Maksymalna długość to 1000 znaków.")]
        public string Description { get; set; }

        [MaxLength(50)]
        public string ImageName { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(0, double.MaxValue, ErrorMessage = "Cena musi być wartością dodatnią.")]
        public double? Price { get; set; }

        
        [Required]
        public Color Color { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane.")]
        public IFormFile Image { get; set; }


        [Required]
        public List<SizeInfoDTO> Sizes { get; set; }
    }
}

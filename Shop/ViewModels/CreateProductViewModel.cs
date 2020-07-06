﻿using Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class CreateProductViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Prace is required.")]
        public double Price { get; set; }

        [MaxLength(1000, ErrorMessage = "Maximum length is 1000 characters")]
        public string Description { get; set; }

        [Required]
        public Color Color { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        public Category Category { get; set; }

    }
}
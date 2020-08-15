﻿using Microsoft.AspNetCore.Http;
using Shop.Common;
using Shop.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }

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
        public List<SizeInfoDTO> Sizes { get; set; }

        [Required]
        public Category Category { get; set; }
        public bool IsArchived { get; set; }
        public bool IsOverpriced { get; set; }
        public double NewPrice { get; set; }
        public IFormFile Image  { get; set; }
    }
}
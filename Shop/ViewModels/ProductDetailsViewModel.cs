using Shop.Common;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public Gender Gender { get; set; }
        public List<SizeInfoDTO> Sizes { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
    }
}

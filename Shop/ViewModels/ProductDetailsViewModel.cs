using Shop.Common;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public double Price { get; set; }
        public double? NewPrice { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public bool IsFavourite { get; set; }
        public bool IsOverpriced { get; set; }

        public Color Color { get; set; }
        public Gender Gender { get; set; }
        public Category Category { get; set; }

        public List<SizeInfoDTO> Sizes { get; set; }


        public double Discount => NewPrice.HasValue ? 100 - (double)NewPrice / Price * 100 : 0;

        public string FormatedDiscount => Discount.ToString("0");
        public string FormatedPrice => Price.ToString("0.00");
        public string FormatedNewPrice => NewPrice.HasValue ? ((double)NewPrice).ToString("0.00") : string.Empty;
        public string ImagePath => "/products-images/" + Image + ".jpg";
    }
}

using Shop.Common;
using Shop.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class CartItem
    {
        public CartItem() { }
        
        public CartItem(AddProductToCartViewModel model)
        {
            Id = model.Id;
            Name = model.Name;
            Price = model.Price;
            Image = model.Image;
            Size = model.SelectedSize;
            Quantity = model.Quantity;
        }

        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }

        public Size Size{ get; set; }
         

        public double Amount => Price * Quantity;
        public string FormatedPrice => Price.ToString("0.00");
        public string FormatedAmount => Amount.ToString("0.00");
        public string ImagePath => "/products-images/" + Image + ".jpg";
    }
}

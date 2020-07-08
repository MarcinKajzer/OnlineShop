using Entities;

namespace Shop.Models
{
    public class CartItem
    {
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}

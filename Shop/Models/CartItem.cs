using Shop.Common;

namespace Shop.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Size Size{ get; set; }
        public int Quantity { get; set; }
    }
}

using System.Collections.Generic;

namespace Shop.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}

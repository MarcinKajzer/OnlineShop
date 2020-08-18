using System.Collections.Generic;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double TotalAmount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public double TotalAmount { get; set; }
    }
}

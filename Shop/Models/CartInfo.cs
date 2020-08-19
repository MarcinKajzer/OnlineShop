using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class CartInfo
    {
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }
}

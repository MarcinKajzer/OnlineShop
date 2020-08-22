using Entities;
using Shop.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Entities
{
    public class ProductInfo
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }


        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Size SelectedSize { get; set; }
    }
}

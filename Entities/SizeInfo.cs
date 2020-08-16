using Shop.Common;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class SizeInfo
    {
        [Key]
        public int Id { get; set; }
        
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }

        [Required]
        public Size Size { get; set; }

        public virtual Product Product { get; set; }
    }
}

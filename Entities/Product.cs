using Shop.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [MaxLength(1000)]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [Required]
        public Color Color { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public virtual List<Size> Sizes { get; set; }
        [Required]
        public Category Category { get; set; }
        public bool isArchived { get; set; }
        
        public int Quantity { get; set; }

    }
}

using Shop.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }


        [Required]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        [Range(0, double.MaxValue)]
        public double? NewPrice { get; set; }


        [Required]
        [MinLength(20)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Required]
        [MinLength(50)]
        [MaxLength(1000)]
        [Column(TypeName = "varchar(1000)")]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Image { get; set; }


        public bool IsArchived { get; set; }
        public bool IsDiscounted { get; set; }


        [Required]
        public Color Color { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public Category Category { get; set; }

        [Required]
        public virtual List<SizeInfo> Sizes { get; set; }
    }
}

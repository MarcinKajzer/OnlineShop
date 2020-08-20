using Shop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double TotalAmount { get; set; }
        public bool IsSent { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }


        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual List<ProductInfo> Products { get; set; }
    }
}

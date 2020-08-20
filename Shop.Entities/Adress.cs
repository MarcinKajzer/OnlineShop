using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Entities
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string City { get; set; }
        public string Street { get; set; }

        [Required]
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }

    }
}

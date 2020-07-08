using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ProductModel
    {
        // maybe to many properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public Gender Gender { get; set; }
        public List<SizeModel> Sizes { get; set; }
        public Category Category { get; set; }
    }
}

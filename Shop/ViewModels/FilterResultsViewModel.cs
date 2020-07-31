using Shop.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class FilterResultsViewModel
    {
        //validation
        public double MinPrice { get; set; } = 0;
        public double MaxPrice { get; set; } = 1000;
        public List<ColorCheckboxModel> ColorCheckboxes { get; set; }
        public List<SizeCheckboxModel> SizeCheckboxes { get; set; }
        public bool IsOverpriced { get; set; }
        public Gender Gender { get; set; }
        public Category Category { get; set; }
        //sortBy
    }
}

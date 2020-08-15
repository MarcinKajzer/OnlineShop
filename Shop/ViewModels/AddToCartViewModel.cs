using Shop.Common;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class AddToCartViewModel
    {
        public int Id { get; set; }
        public List<SizeInfoDTO> Sizes { get; set; }
        public Size SelectedSize { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}

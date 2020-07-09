using Shop.Common;

namespace Shop.Models
{
    public class SizeModel
    {
        public int Id { get; set; }
        public SizeEnum Name { get; set; }
        public int Quantity { get; set; }
        public bool ExistsInDB { get; set; }
    }
}

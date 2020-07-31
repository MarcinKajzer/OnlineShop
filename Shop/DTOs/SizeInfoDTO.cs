using Shop.Common;

namespace Shop.Models
{
    public class SizeInfoDTO
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }
        public bool ExistsInDB { get; set; }
    }
}

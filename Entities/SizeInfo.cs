using Shop.Common;

namespace Entities
{
    public class SizeInfo
    {
        public int Id { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}

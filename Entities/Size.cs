using Shop.Common;

namespace Entities
{
    public class Size
    {
        public int Id { get; set; }
        public SizeEnum Name { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}

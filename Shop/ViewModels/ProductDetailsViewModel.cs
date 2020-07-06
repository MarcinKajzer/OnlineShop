using Entities.Enums;

namespace Shop.ViewModels
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        public Gender Gender { get; set; }
        public Size Size { get; set; }
        public Category Category { get; set; }
    }
}

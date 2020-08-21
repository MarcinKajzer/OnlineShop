using System.ComponentModel.DataAnnotations;

namespace Shop.Entities
{
    public class Adress
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        public string Street { get; set; }
        
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}

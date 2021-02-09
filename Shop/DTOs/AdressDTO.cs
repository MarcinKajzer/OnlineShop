using System.ComponentModel.DataAnnotations;

namespace Shop.DTOs
{
    public class AdressDTO
    {
        [Required]
        public string PostCode { get; set; }
        [Required]
        public string City { get; set; }
        public string Street { get; set; }

        [Required]
        public int BuildingNumber { get; set; }
        public int FlatNumber { get; set; }
    }
}

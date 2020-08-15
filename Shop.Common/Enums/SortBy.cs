using System.ComponentModel.DataAnnotations;

namespace Shop.Common.Enums
{
    public enum SortBy
    {
        [Display(Name = "Cena rosnąco")]
        PriceAscending,

        [Display(Name = "Cena malejąco")]
        PriceDescending
    }
}

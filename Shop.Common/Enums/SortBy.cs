using System.ComponentModel.DataAnnotations;

namespace Shop.Common.Enums
{
    public enum SortBy
    {
        [Display(Name = "Price ascending")]
        PriceAscending,

        [Display(Name = "Price descending")]
        PriceDescending
    }
}

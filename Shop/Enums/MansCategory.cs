using System.ComponentModel.DataAnnotations;

namespace Shop.Enums
{
    public enum MansCategory
    {
        [Display(Name = "Bluzy")]
        Blouse,
        [Display(Name = "Swetry")]
        Sweater,
        [Display(Name = "Koszulki")]
        Tshirt,
        [Display(Name = "Kurtki")]
        Jacket,
        [Display(Name = "Koszule")]
        Shirt,
        [Display(Name = "Spodnie")]
        Trousers,
        [Display(Name = "Spodenki")]
        Shorts,
        [Display(Name = "Marynarki")]
        Marine,
        [Display(Name = "Czapki")]
        Cap,
        [Display(Name = "Akcesoria")]
        Accesories,
    }
}

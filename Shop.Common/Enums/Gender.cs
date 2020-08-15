using System.ComponentModel.DataAnnotations;

namespace Shop.Common
{
    public enum Gender
    {
        [Display(Name = "Kobieta")]
        Womens = 0,
        [Display(Name = "Mężczyzna")]
        Mens = 1
    }
}

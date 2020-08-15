using System.ComponentModel.DataAnnotations;

namespace Shop.Common
{
    public enum Color
    {
        [Display(Name = "Biały")]
        White = 0,
        [Display(Name = "Szary")]
        Gray = 1,
        [Display(Name = "Czarny")]
        Black = 2,
        [Display(Name = "Zielony")]
        Green = 3,
        [Display(Name = "Żółty")]
        Yellow = 4,
        [Display(Name = "Czerwony")]
        Red = 5,
        [Display(Name = "Fioletowy")]
        Purple = 6,
        [Display(Name = "Niebieski")]
        Blue = 7,
        [Display(Name = "Różowy")]
        Pink = 8,
        [Display(Name = "Inny")]
        Other = 9
    }
}

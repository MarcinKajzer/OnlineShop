using Microsoft.AspNetCore.Identity;
using Shop.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Column(TypeName = "Varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Column(TypeName = "Varchar(50)")]
        public string LastName { get; set; }

        public virtual Adress Adress { get; set; }
        public virtual List<Product> Favourites { get; set; }
    }
}

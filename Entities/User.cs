using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User : IdentityUser
    {
        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        public string LastName { get; set; }

    }
}

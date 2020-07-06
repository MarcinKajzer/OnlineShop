﻿using Microsoft.AspNetCore.Identity;
using System;

namespace Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

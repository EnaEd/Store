﻿using Microsoft.AspNetCore.Identity;
using System;

namespace Store.DataAccessLayer.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefreshToken { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}

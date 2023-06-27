﻿using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace EasyCash.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int TwoFactorCode { get; set; }

        // Nav Props 
        public List<CustomerAccount> CustomerAccounts { get; set; }
    }
}

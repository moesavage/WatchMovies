using System;
using Microsoft.AspNetCore.Identity;

namespace WatchMovies.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}


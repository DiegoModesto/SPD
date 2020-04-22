using Microsoft.AspNetCore.Identity;
using System;

namespace SPD.Api.Authentication.Business.Model
{
    public class UserEntity : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool FullfilmentComplete { get; set; }
    }
}

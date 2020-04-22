using Microsoft.AspNetCore.Identity;
using System;

namespace SPD.Api.Authentication.Business.Model
{
    public class UserLoginEntity : IdentityUserLogin<Guid> { }
}

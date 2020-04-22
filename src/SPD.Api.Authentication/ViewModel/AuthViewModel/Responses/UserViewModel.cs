using System;

namespace SPD.Api.Authentication.ViewModel.AuthViewModel.Responses
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}

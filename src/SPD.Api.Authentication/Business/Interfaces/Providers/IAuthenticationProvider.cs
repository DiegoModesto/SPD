using SPD.Api.Authentication.ViewModel.AuthViewModel;
using SPD.Api.Authentication.ViewModel.AuthViewModel.Responses;
using System.Threading.Tasks;

namespace SPD.Api.Authentication.Business.Interfaces.Providers
{
    public interface IAuthenticationProvider
    {
        Task<(bool IsSuccess, UserViewModel user, string ErrorMessage)> SignInUserAsync(LoginViewModel model);
        Task<(bool IsSuccess, UserViewModel user, string ErrorMessage)> SignUpUserAsync(RegisterViewModel model);
    }
}

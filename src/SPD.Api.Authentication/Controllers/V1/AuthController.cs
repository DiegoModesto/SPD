using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPD.Api.Authentication.Installer;
using SPD.Api.Authentication.Providers;
using SPD.Api.Authentication.ViewModel.AuthViewModel;
using System.Threading.Tasks;

namespace SPD.Api.Authentication.Controllers.V1
{
    [Authorize]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationProvider _authProvider;

        public AuthController(AuthenticationProvider authProvider)
        {
            this._authProvider = authProvider;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Auth.SignIn)]
        public async Task<IActionResult> SingIn([FromBody] LoginViewModel model)
        {
            var (IsSuccess, UserViewModel, ErrorMessage) = await _authProvider.SignInUserAsync(model);

            return IsSuccess
                ? Ok(UserViewModel)
                : Ok(ErrorMessage);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Auth.SignUp)]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var (IsSuccess, UserViewModel, ErrorMessage) = await _authProvider.SignUpUserAsync(model);

            return IsSuccess 
                ? Ok(UserViewModel) 
                : Ok(ErrorMessage);
        }
    }
}

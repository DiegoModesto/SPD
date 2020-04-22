using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SPD.Api.Authentication.Business.DataBase;
using SPD.Api.Authentication.Installer;
using SPD.Api.Authentication.Business.Interfaces.Providers;
using SPD.Api.Authentication.Business.Model;
using SPD.Api.Authentication.ViewModel.AuthViewModel;
using SPD.Api.Authentication.ViewModel.AuthViewModel.Responses;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SPD.Api.Authentication.Providers
{
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private readonly UserManager<UserEntity> _userMgr;
        private readonly SignInManager<UserEntity> _signMgr;

        private readonly AuthorizationDbContext _dbContext;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AuthenticationProvider(
            UserManager<UserEntity> userMgr,
            SignInManager<UserEntity> signMgr,
            AuthorizationDbContext dbContext, 
            AppSettings appSettings,
            IMapper mapper)
        {
            this._userMgr = userMgr;
            this._signMgr = signMgr;
            this._appSettings = appSettings;

            this._dbContext = dbContext;
            this._mapper = mapper;
        }

        public async Task<(bool IsSuccess, UserViewModel user, string ErrorMessage)> SignInUserAsync(LoginViewModel model)
        {
            try
            {
                var user = model.UserName.IndexOf('@') > 0
                    ? await _userMgr.FindByEmailAsync(model.UserName)
                    : await _userMgr.FindByNameAsync(model.UserName);

                if (user == null)
                    return (false, null, "User/Password does not match");

                var signInResult = await _signMgr.CheckPasswordSignInAsync(user, model.Password, false);
                if (signInResult.Succeeded)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.UniqueName, model.UserName)
                    };

                    var token = new JwtSecurityToken(
                            issuer: _appSettings.JwtIssue,
                            audience: _appSettings.JwtAudience,
                            claims: claims,
                            expires: DateTime.UtcNow.AddMinutes(60),
                            signingCredentials: credentials
                    );

                    var results = new UserViewModel
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        UserName = model.UserName,
                        ExpirationDate = token.ValidTo
                    };

                    return (true, results, null);
                }

                return (false, null, "User/Password does not match");
            }
            catch (Exception e)
            {
                return (false, null, e.Message);
            }
        }

        public async Task<(bool IsSuccess, UserViewModel user, string ErrorMessage)> SignUpUserAsync(RegisterViewModel model)
        {
            var userEntity = _mapper.Map<RegisterViewModel, UserEntity>(model);

            try
            {
                var isEmailAvailable = await _userMgr.FindByEmailAsync(userEntity.Email);
                if (isEmailAvailable != null)
                    return (false, null, "Email is exist");

                var createdUser = await _userMgr.CreateAsync(userEntity, model.Password);

                //var result = _mapper.Map<UserEntity, UserViewModel>(createdUser);

                return (true, null, null);
            }
            catch (Exception e)
            {
                return (false, null, e.Message);
            }
        }        
    }
}

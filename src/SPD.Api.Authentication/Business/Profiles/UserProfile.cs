using SPD.Api.Authentication.Business.Model;
using SPD.Api.Authentication.ViewModel.AuthViewModel;
using SPD.Api.Authentication.ViewModel.AuthViewModel.Responses;

namespace SPD.Api.Authentication.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, UserEntity>();
            CreateMap<UserEntity, UserViewModel>();
        }
    }
}

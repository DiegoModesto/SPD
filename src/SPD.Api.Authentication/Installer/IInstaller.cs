using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SPD.Api.Authentication.Installer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}

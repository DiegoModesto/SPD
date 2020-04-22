using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SPD.Api.Authentication.Business.DataBase;
using SPD.Api.Authentication.Business.Filters;
using SPD.Api.Authentication.Business.Interfaces.Providers;
using SPD.Api.Authentication.Business.Model;
using SPD.Api.Authentication.Providers;
using System;
using System.Text;

namespace SPD.Api.Authentication.Installer
{
    public class ApiInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = new AppSettings();
            configuration.Bind(nameof(appSettings), appSettings);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.JwtKey)),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                RequireExpirationTime = true
            };

            this.InstallCors(services);
            this.InstallFilters(services);
            this.InstallIdentity(services);
            this.InstallDbContext(services, appSettings);
            this.InstallAuthentication(services, tokenValidationParameters);
            
            services
                .Configure<AppSettings>(configuration)
                .AddSingleton(appSettings)
                .AddSingleton(tokenValidationParameters)
                .AddScoped<AuthenticationProvider>(); ;
        }

        private void InstallCors(IServiceCollection services)
        {
            //Setting CORS and origin requests
            services
                .AddCors(x =>
                {
                    x.AddPolicy("AllowReactJs",
                        builder =>
                        {
                            builder
                                .WithOrigins("http://localhost:3000", "https://localhost:3001")
                                .AllowAnyOrigin()
                                .AllowAnyMethod();
                        });
                });
        }
        private void InstallFilters(IServiceCollection services)
        {
            services
                .AddMvc(opt =>
                {
                    opt.EnableEndpointRouting = false;
                    opt.Filters.Add<ValidationFilter>();
                })
                .AddFluentValidation(mvcConf => mvcConf.RegisterValidatorsFromAssemblyContaining<Startup>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }
        private void InstallAuthentication(IServiceCollection services, TokenValidationParameters tokenValidationParameters)
        {
            services
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddCookie(x =>
                {
                    x.SlidingExpiration = true;
                })
                .AddJwtBearer(x =>
                {
                    x.SaveToken = true;
                    x.TokenValidationParameters = tokenValidationParameters;
                });
        }
        private void InstallIdentity(IServiceCollection services)
        {
            services
                .AddIdentity<UserEntity, RoleEntity>(opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<AuthorizationDbContext>()
                .AddDefaultTokenProviders();
        }
        private void InstallDbContext(IServiceCollection services, AppSettings appSettings)
        {
            services
                .AddDbContext<AuthorizationDbContext>(cfg =>
                {
                    cfg.UseNpgsql(appSettings.ConString);
                });
        }
    }
}

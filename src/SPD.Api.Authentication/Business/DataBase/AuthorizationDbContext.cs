using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SPD.Api.Authentication.Business.Model;
using SPD.Api.Authentication.Business.Model.Configuration;
using System;

namespace SPD.Api.Authentication.Business.DataBase
{
    public class AuthorizationDbContext : IdentityDbContext<
            UserEntity,
            RoleEntity,
            Guid,
            UserClaimEntity,
            UserRoleEntity,
            UserLoginEntity,
            RoleClaimEntity,
            UserTokenEntity
        >
    {
        #region [Seed objects]
        //private UserManager<UserEntity> userMgr = new UserManager<UserEntity>();
        private class SeedObject
        {
            public Guid RoleId { get; set; }
            public string RoleName { get; set; }
            public SeedUser[] seedUsers { get; set; }

            public class SeedUser
            {
                public Guid Id { get; set; }
                public string Name { get; set; }
                public string Email { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string OpenPassword { get; set; }
            }
        }

        private readonly SeedObject[] seedData = new SeedObject[] {
            new SeedObject {
                RoleId = Guid.NewGuid(),
                RoleName = "Owner",

                seedUsers = new SeedObject.SeedUser[]
                {
                    new SeedObject.SeedUser
                    {
                        Id = Guid.NewGuid(),
                        Name = "diego.modesto",
                        Email = "diego.modesto@company.com",
                        FirstName = "Diego",
                        LastName = "Modesto",
                        OpenPassword = "@123Mudar"
                    }
                }
            },
            new SeedObject {
                RoleId = Guid.NewGuid(),
                RoleName = "Administrator",

                seedUsers = new SeedObject.SeedUser[]
                {
                    new SeedObject.SeedUser
                    {
                        Id = Guid.NewGuid(),
                        Name = "samuel.souza",
                        Email = "samuel.souza@company.com",
                        FirstName = "Samuel",
                        LastName = "Souza",
                        OpenPassword = "@123Mudar"
                    }
                }
            },
            new SeedObject { RoleId = Guid.NewGuid(), RoleName = "Manager" },
            new SeedObject { RoleId = Guid.NewGuid(), RoleName = "Editor" },
            new SeedObject {
                RoleId = Guid.NewGuid(),
                RoleName = "Buyer",

                seedUsers = new SeedObject.SeedUser[]
                {
                    new SeedObject.SeedUser
                    {
                        Id = Guid.NewGuid(),
                        Name = "user.buyer",
                        Email = "user.buyer@company.com",
                        FirstName = "User",
                        LastName = "Buyer",
                        OpenPassword = "@123Mudar"
                    }
                }
            },
            new SeedObject { RoleId = Guid.NewGuid(), RoleName = "Business" },
            new SeedObject {
                RoleId = Guid.NewGuid(),
                RoleName = "Seller",

                seedUsers = new SeedObject.SeedUser[]
                {
                    new SeedObject.SeedUser
                    {
                        Id = Guid.NewGuid(),
                        Name = "user.seller",
                        Email = "user.Seller@company.com",
                        FirstName = "User",
                        LastName = "Seller",
                        OpenPassword = "@123Mudar"
                    }
                }
            },
            new SeedObject { RoleId = Guid.NewGuid(), RoleName = "Subscriber" }
        };
        #endregion

        public AuthorizationDbContext(DbContextOptions<AuthorizationDbContext> opts) : base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<UserEntity>();
            base.OnModelCreating(builder);

            #region [Configuration]
            builder.ApplyConfiguration(new RoleClaimEntityConfiguration());
            builder.ApplyConfiguration(new RoleEntityConfiguration());
            builder.ApplyConfiguration(new UserClaimEntityConfiguration());
            builder.ApplyConfiguration(new UserEntityConfiguration());
            builder.ApplyConfiguration(new UserLoginEntityConfiguration());
            builder.ApplyConfiguration(new UserRoleEntityConfiguration());
            builder.ApplyConfiguration(new UserTokenEntityConfiguration());
            #endregion

            #region [Seed Data]
            foreach (SeedObject data in seedData)
            {

                builder.Entity<RoleEntity>()
                .HasData(new RoleEntity
                {
                    Id = data.RoleId,
                    Name = data.RoleName,
                    NormalizedName = data.RoleName
                });

                if (data.seedUsers != null && data.seedUsers.Length > 0)
                {
                    foreach (var user in data.seedUsers)
                    {
                        var appUser = new UserEntity
                        {
                            Id = user.Id,
                            UserName = user.Name,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName
                        };
                        appUser.PasswordHash = hasher.HashPassword(appUser, user.OpenPassword);

                        builder.Entity<UserEntity>()
                            .HasData(appUser);


                        builder.Entity<UserRoleEntity>()
                            .HasData(
                                new UserRoleEntity
                                {
                                    RoleId = data.RoleId,
                                    UserId = user.Id
                                });
                    }
                }
            }
            #endregion
        }
    }
}

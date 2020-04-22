using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SPD.Api.Authentication.Business.Model.Configuration
{
    public class UserClaimEntityConfiguration : IEntityTypeConfiguration<UserClaimEntity>
    {
        public string TableName
        {
            get { return "UserClaim"; }
        }
        public void Configure(EntityTypeBuilder<UserClaimEntity> builder)
        {
            builder.ToTable(TableName)
                .HasKey(x => x.Id);
        }
    }
}

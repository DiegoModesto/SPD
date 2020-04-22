using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPD.Api.Authentication.Business.Model.Configuration
{
    public class RoleClaimEntityConfiguration : IEntityTypeConfiguration<RoleClaimEntity>
    {
        public string TableName
        {
            get { return "RolesClaim"; }
        }

        public void Configure(EntityTypeBuilder<RoleClaimEntity> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(x => x.Id);
        }
    }
}

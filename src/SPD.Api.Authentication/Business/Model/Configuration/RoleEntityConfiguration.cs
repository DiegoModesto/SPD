using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPD.Api.Authentication.Business.Model.Configuration
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public string TableName
        {
            get { return "Roles"; }
        }
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(x => x.Id);
        }
    }
}

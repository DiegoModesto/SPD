using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPD.Api.Authentication.Business.Model.Configuration
{
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRoleEntity>
    {
        public string TableName
        {
            get { return "UsersRole"; }
        }
        public void Configure(EntityTypeBuilder<UserRoleEntity> builder)
        {
            builder
                .ToTable(TableName);
        }
    }
}

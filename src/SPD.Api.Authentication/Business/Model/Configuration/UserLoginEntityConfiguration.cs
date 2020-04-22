using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPD.Api.Authentication.Business.Model.Configuration
{
    public class UserLoginEntityConfiguration : IEntityTypeConfiguration<UserLoginEntity>
    {
        public string TableName
        {
            get { return "UsersLogin"; }
        }
        public void Configure(EntityTypeBuilder<UserLoginEntity> builder)
        {
            builder.ToTable(TableName);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPD.Api.Authentication.Business.Model.Configuration
{
    public class UserTokenEntityConfiguration : IEntityTypeConfiguration<UserTokenEntity>
    {
        public string TableName
        {
            get { return "UsersToken"; }
        }
        public void Configure(EntityTypeBuilder<UserTokenEntity> builder)
        {
            builder
                .ToTable(TableName);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SPD.Api.Authentication.Business.Model.Configuration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public string TableName
        {
            get { return "Users"; }
        }
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(x => x.Id);
        }
    }
}

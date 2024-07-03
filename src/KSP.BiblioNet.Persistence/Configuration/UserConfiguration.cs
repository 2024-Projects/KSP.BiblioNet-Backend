using KSP.BiblioNet.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSP.BiblioNet.Persistence.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<UserEntity> entityBuilder)
        {

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Address).HasMaxLength(255);

            entityBuilder.HasMany(x => x.UserRoles)
                         .WithOne(x => x.User)
                         .HasForeignKey(x => x.UserId);

            entityBuilder.HasMany(x => x.Loans)
                         .WithOne(x => x.User)
                         .HasForeignKey(x => x.UserId);

        }
    }
}

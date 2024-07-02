using KSP.BiblioNet.Domain.Entities.Loan;
using KSP.BiblioNet.Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Persistence.Configuration
{
    public class UserRoleConfiguration
    {
        public UserRoleConfiguration(EntityTypeBuilder<UserRoleEntity> entityBuilder)
        {

            entityBuilder.HasKey(x => new { x.UserId, x.RoleId });

            entityBuilder.HasOne(x => x.User)
                         .WithMany(x => x.UserRoles)
                         .HasForeignKey(x => x.UserId);

            entityBuilder.HasOne(x => x.Role)
                         .WithMany(x => x.UserRoles)
                         .HasForeignKey(x => x.RoleId);
        }
    }
}

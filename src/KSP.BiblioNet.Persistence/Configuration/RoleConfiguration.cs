using KSP.BiblioNet.Domain.Entities.Role;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Persistence.Configuration
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<RoleEntity> entityBuilder)
        {

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.RoleName).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).HasMaxLength(255);

            entityBuilder.HasMany(x => x.UserRoles)
                         .WithOne(x => x.Role)
                         .HasForeignKey(x => x.RoleId);

            entityBuilder.HasData(
                new RoleEntity { Id = 1, RoleName = "Admin", Description = "Administrador del sistema" },
                new RoleEntity { Id = 2, RoleName = "Librarian", Description = "Bibliotecario" },
                new RoleEntity { Id = 3, RoleName = "Member", Description = "Usuario registrado" },
                new RoleEntity { Id = 4, RoleName = "Guest", Description = "Invitado" }
            );

        }
    }
}

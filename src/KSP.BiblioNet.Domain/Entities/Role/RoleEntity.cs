using KSP.BiblioNet.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Domain.Entities.Role
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; } // Relación con UserRoles
    }
}

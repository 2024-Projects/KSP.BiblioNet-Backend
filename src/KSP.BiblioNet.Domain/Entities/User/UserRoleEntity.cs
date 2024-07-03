using KSP.BiblioNet.Domain.Entities.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Domain.Entities.User
{
    public class UserRoleEntity
    {
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }
    }
}

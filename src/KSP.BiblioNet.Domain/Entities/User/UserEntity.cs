using KSP.BiblioNet.Domain.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Domain.Entities.User
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; } // Relación con UserRoles
        public ICollection<LoanEntity> Loans { get; set; } // Relación con préstamos
    }
}

using KSP.BiblioNet.Domain.Entities.Book;
using KSP.BiblioNet.Domain.Entities.Loan;
using KSP.BiblioNet.Domain.Entities.Role;
using KSP.BiblioNet.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase
{
    public interface IDataBaseService
    {
        DbSet<BookEntity> Books { get; set; }
        DbSet<LoanEntity> Loans { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<RoleEntity> Roles { get; set; }
        DbSet<LoanBookEntity> LoanBooks { get; set; }
        DbSet<UserRoleEntity> UserRoles { get; set; }

        Task<bool> SaveAsync();
    }
}

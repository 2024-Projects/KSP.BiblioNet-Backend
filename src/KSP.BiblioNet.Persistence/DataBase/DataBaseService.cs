using KSP.BiblioNet.Application.DataBase;
using KSP.BiblioNet.Domain.Entities.Book;
using KSP.BiblioNet.Domain.Entities.Loan;
using KSP.BiblioNet.Domain.Entities.Role;
using KSP.BiblioNet.Domain.Entities.User;
using KSP.BiblioNet.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Persistence.DataBase
{
    public class DataBaseService : DbContext, IDataBaseService
    {
        public DataBaseService(DbContextOptions options) : base(options) { }

        public DbSet<BookEntity> Books { get; set; }
        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<LoanBookEntity> LoanBooks { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }

        public async Task<bool> SaveAsync() {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder) {
            new BookConfiguration(modelBuilder.Entity<BookEntity>());
            new LoanConfiguration(modelBuilder.Entity<LoanEntity>());
            new LoanBookConfiguration(modelBuilder.Entity<LoanBookEntity>());
            new RoleConfiguration(modelBuilder.Entity<RoleEntity>());
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new UserRoleConfiguration(modelBuilder.Entity<UserRoleEntity>());
        }

    }
}

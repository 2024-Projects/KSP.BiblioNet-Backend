using KSP.BiblioNet.Domain.Entities.Loan;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Persistence.Configuration
{
    public class LoanConfiguration
    {
        public LoanConfiguration(EntityTypeBuilder<LoanEntity> entityBuilder)
        {

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.LoanDate).IsRequired();
            entityBuilder.Property(x => x.ExpectedReturnDate).IsRequired();
            entityBuilder.Property(x => x.ActualReturnDate).IsRequired(false);
            entityBuilder.Property(x => x.Status).IsRequired().HasConversion<string>();

            entityBuilder.HasOne(x => x.User)
                         .WithMany(x => x.Loans)
                         .HasForeignKey(x => x.UserId);

            entityBuilder.HasMany(x => x.LoanBooks)
                         .WithOne(x => x.Loan)
                         .HasForeignKey(x => x.LoanId);

        }
    }
}

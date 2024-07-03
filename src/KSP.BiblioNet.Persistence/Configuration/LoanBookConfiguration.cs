using KSP.BiblioNet.Domain.Entities.Loan;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Persistence.Configuration
{
    public class LoanBookConfiguration
    {
        public LoanBookConfiguration(EntityTypeBuilder<LoanBookEntity> entityBuilder)
        {


            entityBuilder.HasKey(x => new { x.LoanId, x.BookId });

            entityBuilder.HasOne(x => x.Loan)
                         .WithMany(x => x.LoanBooks)
                         .HasForeignKey(x => x.LoanId);

            entityBuilder.HasOne(x => x.Book)
                         .WithMany(x => x.LoanBooks)
                         .HasForeignKey(x => x.BookId);


        }
    }
}

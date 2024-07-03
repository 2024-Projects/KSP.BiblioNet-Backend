using KSP.BiblioNet.Domain.Entities.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KSP.BiblioNet.Persistence.Configuration
{
    public class BookConfiguration
    {
        public BookConfiguration(EntityTypeBuilder<BookEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.Author).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.ISBN).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.AvailableCopies).IsRequired();
            entityBuilder.Property(x => x.Genre).HasMaxLength(100);
            entityBuilder.Property(x => x.PublicationDate).HasColumnType("date");

            entityBuilder.HasMany(x => x.LoanBooks)
                         .WithOne(x => x.Book)
                         .HasForeignKey(x => x.BookId);

        }
    }
}

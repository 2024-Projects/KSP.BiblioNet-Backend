using KSP.BiblioNet.Domain.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Domain.Entities.Book
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int AvailableCopies { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
        public ICollection<LoanBookEntity> LoanBooks { get; set; } // Relación con LoanBooks
    }
}

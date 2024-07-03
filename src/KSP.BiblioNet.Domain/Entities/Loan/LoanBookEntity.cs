using KSP.BiblioNet.Domain.Entities.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Domain.Entities.Loan
{
    public class LoanBookEntity
    {
        public int LoanId { get; set; }
        public LoanEntity Loan { get; set; }
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
    }
}

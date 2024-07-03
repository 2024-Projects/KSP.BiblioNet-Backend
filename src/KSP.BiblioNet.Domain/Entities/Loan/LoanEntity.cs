using KSP.BiblioNet.Domain.Entities.User;
using KSP.BiblioNet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Domain.Entities.Loan
{
    public class LoanEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public LoanStatus Status { get; set; } // Campo para el estado del préstamo
        public UserEntity User { get; set; }
        public ICollection<LoanBookEntity> LoanBooks { get; set; } // Relación con LoanBooks
    }
}

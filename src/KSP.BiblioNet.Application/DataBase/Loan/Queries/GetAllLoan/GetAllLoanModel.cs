using KSP.BiblioNet.Domain.Entities.Loan;
using KSP.BiblioNet.Domain.Entities.User;
using KSP.BiblioNet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Queries.GetAllLoan
{
    public class GetAllLoanModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public string Status { get; set; }
        public UserModel User { get; set; }
        public List<BookModel> Books { get; set; }
    }

    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

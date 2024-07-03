using KSP.BiblioNet.Domain.Enums;

namespace KSP.BiblioNet.Application.DataBase.Loan.Commands.UpdateLoan
{
    public class UpdateLoanModel
    {
        public int Id { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
    }
}

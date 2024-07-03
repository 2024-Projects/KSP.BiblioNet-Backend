using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan
{
    public class CreateLoanModel
    {
        public int UserId { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public List<int> BookIds { get; set; }
    }
}

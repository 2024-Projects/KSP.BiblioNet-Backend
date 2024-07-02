using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan
{
    public interface ICreateLoanCommand
    {
        Task<CreateLoanModel> Execute(CreateLoanModel model);
    }
}

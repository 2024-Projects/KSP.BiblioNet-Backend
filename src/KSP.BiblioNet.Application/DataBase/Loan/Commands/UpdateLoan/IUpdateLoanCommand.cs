using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Commands.UpdateLoan
{
    public interface IUpdateLoanCommand
    {
        Task<UpdateLoanModel> Execute(UpdateLoanModel model);
    }
}

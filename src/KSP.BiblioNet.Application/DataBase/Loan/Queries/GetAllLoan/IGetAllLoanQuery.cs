using KSP.BiblioNet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Queries.GetAllLoan
{
    public interface IGetAllLoanQuery
    {
        Task<PagedResult<GetAllLoanModel>> Execute(int pageNumber, int pageSize);
    }
}

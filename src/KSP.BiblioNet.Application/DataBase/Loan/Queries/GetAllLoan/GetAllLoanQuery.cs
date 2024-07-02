using AutoMapper;
using KSP.BiblioNet.Application.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Queries.GetAllLoan
{
    public class GetAllLoanQuery: IGetAllLoanQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetAllLoanQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

       
        public async Task<PagedResult<GetAllLoanModel>> Execute(int pageNumber, int pageSize)
        {
            var totalItems = await _dataBaseService.Loans.CountAsync();
            var listEntity = await _dataBaseService.Loans
                            .Include(l => l.User)
                            .Include(l => l.LoanBooks)
                                .ThenInclude(lb => lb.Book)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            var models = _mapper.Map<List<GetAllLoanModel>>(listEntity);

            foreach (var model in models)
            {
                var loanEntity = listEntity.FirstOrDefault(l => l.Id == model.Id);
                if (loanEntity != null)
                {
                    model.User = _mapper.Map<UserModel>(loanEntity.User);
                    model.Books = loanEntity.LoanBooks.Select(lb => _mapper.Map<BookModel>(lb.Book)).ToList();
                }
            }

            return new PagedResult<GetAllLoanModel>
            {
                Items = models,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

    }
}

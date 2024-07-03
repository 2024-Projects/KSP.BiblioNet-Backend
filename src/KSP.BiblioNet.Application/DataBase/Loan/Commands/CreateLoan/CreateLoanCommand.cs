using AutoMapper;
using KSP.BiblioNet.Domain.Entities.Loan;
using KSP.BiblioNet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan
{
    public class CreateLoanCommand : ICreateLoanCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateLoanCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateLoanModel> Execute(CreateLoanModel model)
        {
            var loanEntity = _mapper.Map<LoanEntity>(model);
            loanEntity.LoanDate = DateTime.Now;

            loanEntity.LoanBooks = new List<LoanBookEntity>();
            foreach (var bookId in model.BookIds)
            {
                loanEntity.LoanBooks.Add(new LoanBookEntity
                {
                    BookId = bookId,
                    Loan = loanEntity
                });
            }

            await _dataBaseService.Loans.AddAsync(loanEntity);
            await _dataBaseService.SaveAsync();

            return model;
        }
    }
}

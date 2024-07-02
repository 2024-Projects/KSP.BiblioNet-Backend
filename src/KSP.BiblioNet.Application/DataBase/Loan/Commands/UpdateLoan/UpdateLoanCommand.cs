using AutoMapper;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan;
using KSP.BiblioNet.Domain.Entities.Loan;
using KSP.BiblioNet.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.DataBase.Loan.Commands.UpdateLoan
{
    public class UpdateLoanCommand: IUpdateLoanCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public UpdateLoanCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<UpdateLoanModel> Execute(UpdateLoanModel model)
        {
            var loanEntity = await _dataBaseService.Loans
                .Include(l => l.LoanBooks)
                .FirstOrDefaultAsync(l => l.Id == model.Id);

            if (loanEntity == null)
            {
                throw new Exception("Préstamo no encontrado");
            }

            _mapper.Map(model, loanEntity);

            _dataBaseService.Loans.Update(loanEntity);
            await _dataBaseService.SaveAsync();

            return model;

        }
    }
}

using FluentValidation;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.UpdateLoan;
using KSP.BiblioNet.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.Validators.Loan
{
    public class UpdateLoanValidator : AbstractValidator<UpdateLoanModel>
    {
        public UpdateLoanValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("El campo no puede ser nulo").GreaterThan(0);
     
            RuleFor(x => x.ExpectedReturnDate)
            .NotNull().WithMessage("La fecha no puede ser nula")
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("La fecha debe ser hoy o una fecha futura");

        }
    }
}

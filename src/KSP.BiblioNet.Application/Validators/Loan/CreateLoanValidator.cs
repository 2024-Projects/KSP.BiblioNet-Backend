using FluentValidation;
using KSP.BiblioNet.Application.DataBase.Loan.Commands.CreateLoan;

namespace KSP.BiblioNet.Application.Validators.Loan
{
    public class CreateLoanValidator : AbstractValidator<CreateLoanModel>
    {
        public CreateLoanValidator() 
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("El campo no puede ser nulo").GreaterThan(0);
            
            RuleFor(x => x.BookIds)
            .NotNull().WithMessage("La lista de BookIds no puede ser nula")
            .Must(bookIds => bookIds != null && bookIds.Count > 0).WithMessage("La lista debe contener al menos un BookId")
            .ForEach(bookId => bookId.GreaterThan(0).WithMessage("Cada BookId debe ser mayor que cero"));
            
            RuleFor(x => x.ExpectedReturnDate)
            .NotNull().WithMessage("La fecha no puede ser nula")
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("La fecha debe ser hoy o una fecha futura");

        }
    }
}

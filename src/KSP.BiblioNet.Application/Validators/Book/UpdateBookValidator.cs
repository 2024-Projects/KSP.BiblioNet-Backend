using FluentValidation;
using KSP.BiblioNet.Application.DataBase.Book.Commands.UpdateBook;

namespace KSP.BiblioNet.Application.Validators.Book
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookModel>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("El campo no puede ser nulo").GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(200);
            RuleFor(x => x.Author).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(100);
            RuleFor(x => x.ISBN).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
            RuleFor(x => x.AvailableCopies).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo");
        }
    }
}

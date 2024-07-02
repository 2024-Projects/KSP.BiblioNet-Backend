using FluentValidation;
using KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUser;

namespace KSP.BiblioNet.Application.Validators.User
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserModel>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("El campo no puede ser nulo").GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
            RuleFor(x => x.Address).MaximumLength(255);
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
        }
    }
}

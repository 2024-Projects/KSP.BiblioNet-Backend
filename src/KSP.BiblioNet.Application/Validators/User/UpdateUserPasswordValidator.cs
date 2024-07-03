using FluentValidation;
using KSP.BiblioNet.Application.DataBase.User.Commands.UpdateUserPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.Validators.User
{
    public class UpdateUserPasswordValidator: AbstractValidator<UpdateUserPasswordModel>
    {
        public UpdateUserPasswordValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("El campo no puede ser nulo").GreaterThan(0);
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
        }
    }
}

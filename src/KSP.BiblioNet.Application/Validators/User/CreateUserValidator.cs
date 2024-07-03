using FluentValidation;
using KSP.BiblioNet.Application.DataBase.User.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.Validators.User
{
    public class CreateUserValidator: AbstractValidator<CreateUserModel>
    {
        public CreateUserValidator()
        {
            RuleFor(x=> x.UserName).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
            RuleFor(x=> x.Name).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
            RuleFor(x=> x.Password).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(15);
            RuleFor(x=> x.Address).MaximumLength(255);
            RuleFor(x=> x.Email).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
        }
    }
}



using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.Validators.User
{
    public class GetUserByUserNameAndPasswordValidator: AbstractValidator<(string, string)>
    {
        public GetUserByUserNameAndPasswordValidator()
        {
            RuleFor(x => x.Item1).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
            RuleFor(x => x.Item2).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(15);

        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSP.BiblioNet.Application.Validators.Book
{
    public class GetBookByISBNValidator : AbstractValidator<string>
    {
        public GetBookByISBNValidator()
        {
            RuleFor(x => x).NotEmpty().NotNull().WithMessage("El campo no puede ser nulo").MaximumLength(50);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Domain.DTO;

namespace VideoGameApp.Domain.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Usuario).NotNull();
            RuleFor(x => x.Usuario).NotEmpty();
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Domain.DTO;

namespace VideoGameApp.Domain.Validators
{
    public class RegistroUsuarioDtoValidator : AbstractValidator<RegistroUsuarioDto>
    {
        public RegistroUsuarioDtoValidator()
        {
            RuleFor(x => x.NombreUsuario).NotNull();
            RuleFor(x => x.NombreUsuario).NotEmpty();
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Domain.DTO;

namespace VideoGameApp.Domain.Validators
{
    public class VideojuegoDtoValidator : AbstractValidator<VideojuegoDto>
    {
        public VideojuegoDtoValidator()
        {
            
        }
    }
}

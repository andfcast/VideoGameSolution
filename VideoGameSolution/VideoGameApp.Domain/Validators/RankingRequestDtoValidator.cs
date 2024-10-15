using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Domain.DTO;

namespace VideoGameApp.Domain.Validators
{
    public class RankingRequestDtoValidator : AbstractValidator<RankingRequestDto>
    {
        public RankingRequestDtoValidator()
        {
            RuleFor(x => x.NumeroTop).NotNull();
            RuleFor(x => x.NumeroTop).NotEmpty();
            RuleFor(x => x.NumeroTop).GreaterThan(0);
            RuleFor(x => x.NumeroTop).LessThanOrEqualTo(20);
        }
    }
}

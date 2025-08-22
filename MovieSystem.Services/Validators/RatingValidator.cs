using FluentValidation;
using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Validators
{
    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            RuleFor(r => r.RatingScore).InclusiveBetween(1, 5);
        }
    }
}

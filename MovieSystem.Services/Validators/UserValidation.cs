using FluentValidation;
using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().Length(2, 50);
            RuleFor(u => u.LastName).NotEmpty().Length(2, 50);
            RuleFor(u => u.Email).EmailAddress();
        }
    }
}

using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Password).NotNull().MinimumLength(6);
            RuleFor(u => u.Firstname).NotNull().MinimumLength(3);
            RuleFor(u => u.Lastname).NotNull().MinimumLength(2);
        }
    }
}

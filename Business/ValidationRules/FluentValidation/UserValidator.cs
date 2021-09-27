using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.FirstName).NotNull().NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).NotNull().NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
        }
    }
}

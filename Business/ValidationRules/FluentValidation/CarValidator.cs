using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotNull().NotEmpty();
            RuleFor(c => c.DailyPrice).LessThan(1000000);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            

            RuleFor(c => c.Description).NotNull().NotEmpty();
            RuleFor(c => c.Description).MaximumLength(500);
            RuleFor(c => c.Description).MinimumLength(20);
        }
    }
}
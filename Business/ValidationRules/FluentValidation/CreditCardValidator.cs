using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CardName).NotNull().NotEmpty();
            RuleFor(c => c.CardName).MinimumLength(4);

            RuleFor(c => c.CardNumber).NotNull().NotEmpty();
            RuleFor(c => c.CardNumber).Length(16, 16);

            RuleFor(c => c.CVV).NotNull().NotEmpty();
            RuleFor(c => c.CVV).Length(3, 4);


            RuleFor(c => c.ExpirationDate).NotNull().NotEmpty();
        }
    }
}

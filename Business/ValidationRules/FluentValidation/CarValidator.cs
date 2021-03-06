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
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(50).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(150).When(c => c.BrandId == 3);
            RuleFor(c => c.ModelYear).NotEmpty();
        }
    }
}

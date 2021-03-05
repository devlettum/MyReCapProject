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
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);

            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThan(200).When(c => c.BrandId == 6);//Tesla için
            RuleFor(c => c.CarName).Must(StartWithT).When(c => c.BrandId == 6).WithMessage("Bu model için adı T ile başlamalı");
            RuleFor(b => b.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
        }

        private bool StartWithT(string arg)
        {
            return arg.StartsWith("T");
        }
    }
}

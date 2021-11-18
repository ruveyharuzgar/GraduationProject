using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MagnetValidator : AbstractValidator<Magnet>
    {
        public MagnetValidator()
        {
            RuleFor(m => m.Quantity).NotEmpty();
            RuleFor(m => m.UnitPrice).NotEmpty();
            RuleFor(m => m.UnitPrice).GreaterThan(0);
        }
    }
}

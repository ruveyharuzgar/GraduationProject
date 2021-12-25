using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class MagnetImageValidator:AbstractValidator<MagnetImage>
    {
        public MagnetImageValidator()
        {
            RuleFor(m => m.MagnetId).NotEmpty();
        }
    }
}

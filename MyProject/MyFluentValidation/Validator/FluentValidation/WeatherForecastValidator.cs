using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFluentValidation.Api.Validator.FluentValidation
{
    public class WeatherForecastValidator : AbstractValidator<WeatherForecast>
    {
        public WeatherForecastValidator()
        {
            RuleFor(p => p.TemperatureC).NotEmpty().WithMessage("Buralar hep boş");
            RuleFor(p => p.Summary).Length(5);
        }
    }
}

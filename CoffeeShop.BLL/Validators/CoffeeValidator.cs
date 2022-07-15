using CoffeeShop.BLL.Models;
using FluentValidation;

namespace CoffeeShop.BLL.Validators
{
    internal class CoffeeValidator : AbstractValidator<Coffee>
    {
        public CoffeeValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().Length(1, 30).WithMessage("{PropertyName} length error");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("{PropertyName} error");
        }
    }
}

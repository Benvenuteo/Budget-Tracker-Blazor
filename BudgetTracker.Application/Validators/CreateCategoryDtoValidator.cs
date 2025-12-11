using BudgetTracker.Shared.DTOs;
using FluentValidation;

namespace BudgetTracker.Application.Validators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nazwa kategorii jest wymagana.")
                .MaximumLength(50).WithMessage("Nazwa kategorii zbyt długa.");

            RuleFor(x => x.ColorHex)
                .Matches("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$")
                .WithMessage("Niepoprawny format koloru (wymagany HEX, np. #FF0000).");
        }
    }
}

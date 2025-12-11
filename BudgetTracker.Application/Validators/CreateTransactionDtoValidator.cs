using BudgetTracker.Shared.DTOs;
using FluentValidation;

namespace BudgetTracker.Application.Validators
{
    public class CreateTransactionDtoValidator : AbstractValidator<CreateTransactionDto>
    {
        public CreateTransactionDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Opis jest wymagany.")
                .MaximumLength(200).WithMessage("Opis nie może być dłuższy niż 200 znaków.");

            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Kwota musi być większa od zera.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Należy wybrać kategorię.");

            RuleFor(x => x.Date)
                .LessThanOrEqualTo(DateTime.Now.AddDays(1)).WithMessage("Nie można dodawać transakcji z przyszłości.");
        }
    }
}

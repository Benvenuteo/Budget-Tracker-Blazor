using BudgetTracker.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace BudgetTracker.Shared.DTOs
{
    public class CreateTransactionDto
    {
        [Required(ErrorMessage = "Opis jest wymagany")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Kwota musi być większa od 0")]
        public decimal Amount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Kategoria jest wymagana")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz kategorię")]
        public int CategoryId { get; set; }

        public TransactionType Type { get; set; } = TransactionType.Expense;
    }
}

using BudgetTracker.Shared.Enums;

namespace BudgetTracker.Core.Domain
{
    public class Transaction : BaseEntity
    {
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        public TransactionType Type { get; set; }

        // Klucz obcy do kategorii
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        // Id użytkownika z systemu Identity (Guid jako string)
        public string UserId { get; set; } = string.Empty;
    }
}

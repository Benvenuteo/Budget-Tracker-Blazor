namespace BudgetTracker.Core.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string ColorHex { get; set; } = "#000000";

        public string UserId { get; set; } = string.Empty;

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}

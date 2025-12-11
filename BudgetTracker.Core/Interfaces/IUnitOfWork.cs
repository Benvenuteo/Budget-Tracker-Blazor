using BudgetTracker.Core.Domain;

namespace BudgetTracker.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Transaction> Transactions { get; }
        IGenericRepository<Category> Categories { get; }

        Task<int> CompleteAsync();
    }
}

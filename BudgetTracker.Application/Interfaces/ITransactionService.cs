using BudgetTracker.Shared.DTOs;

namespace BudgetTracker.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDto>> GetUserTransactionsAsync(string userId);
        Task<TransactionDto> CreateTransactionAsync(CreateTransactionDto dto, string userId);
        Task DeleteTransactionAsync(int id, string userId);
    }
}

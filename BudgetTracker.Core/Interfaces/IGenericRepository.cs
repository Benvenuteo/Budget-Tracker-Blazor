using BudgetTracker.Core.Domain;
using System.Linq.Expressions;

namespace BudgetTracker.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate, string includeProperties = "");

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}

using BudgetTracker.Core.Domain;
using BudgetTracker.Core.Interfaces;
using BudgetTracker.Infrastructure.Data;

namespace BudgetTracker.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BudgetDbContext _context;

        private IGenericRepository<Transaction>? _transactions;
        private IGenericRepository<Category>? _categories;

        public UnitOfWork(BudgetDbContext context)
        {
            _context = context;
        }

        // Lazy loading repozytoriów
        public IGenericRepository<Transaction> Transactions
        {
            get
            {
                if (_transactions == null)
                {
                    _transactions = new GenericRepository<Transaction>(_context);
                }
                return _transactions;
            }
        }

        public IGenericRepository<Category> Categories
        {
            get
            {
                return _categories ??= new GenericRepository<Category>(_context);
            }
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

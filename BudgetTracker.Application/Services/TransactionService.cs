using AutoMapper;
using BudgetTracker.Application.Interfaces;
using BudgetTracker.Core.Domain;
using BudgetTracker.Core.Interfaces;
using BudgetTracker.Shared.DTOs;
using Microsoft.Extensions.Logging;

namespace BudgetTracker.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TransactionService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<TransactionDto>> GetUserTransactionsAsync(string userId)
        {
            var transactions = await _unitOfWork.Transactions.FindAsync(
                t => t.UserId == userId,
                "Category"
            );

            return _mapper.Map<IEnumerable<TransactionDto>>(transactions);
        }

        public async Task<TransactionDto> CreateTransactionAsync(CreateTransactionDto dto, string userId)
        {
            _logger.LogInformation("Tworzenie nowej transakcji dla użytkownika {UserId}", userId);

            var transactionEntity = _mapper.Map<Transaction>(dto);

            transactionEntity.UserId = userId;

            await _unitOfWork.Transactions.AddAsync(transactionEntity);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<TransactionDto>(transactionEntity);
        }

        public async Task DeleteTransactionAsync(int id, string userId)
        {
            var transaction = await _unitOfWork.Transactions.GetByIdAsync(id);

            if (transaction == null || transaction.UserId != userId)
            {
                throw new KeyNotFoundException($"Nie znaleziono transakcji o ID {id}");
            }

            _unitOfWork.Transactions.Remove(transaction);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Użytkownik {UserId} usunął transakcję {TransactionId}", userId, id);
        }
    }
}

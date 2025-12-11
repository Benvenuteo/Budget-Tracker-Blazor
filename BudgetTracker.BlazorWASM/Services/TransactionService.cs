using BudgetTracker.Shared.DTOs;
using System.Net.Http.Json;

namespace BudgetTracker.BlazorWASM.Services
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetTransactionsAsync();
        Task CreateTransaction(CreateTransactionDto dto);
        Task DeleteTransactionAsync(int id);
    }

    public class TransactionService : ITransactionService
    {
        private readonly HttpClient _http;

        public TransactionService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<TransactionDto>> GetTransactionsAsync()
        {
            var response = await _http.GetFromJsonAsync<List<TransactionDto>>("api/transactions");
            return response ?? [];
        }

        public async Task CreateTransaction(CreateTransactionDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/transactions", dto);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Błąd zapisu: {response.StatusCode}");
            }
        }

        public async Task DeleteTransactionAsync(int id)
        {
            var response = await _http.DeleteAsync($"api/transactions/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Błąd usuwania: {response.StatusCode}");
            }
        }
    }
}
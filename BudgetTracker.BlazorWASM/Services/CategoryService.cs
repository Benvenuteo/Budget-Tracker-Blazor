using BudgetTracker.Shared.DTOs;
using System.Net.Http.Json;

namespace BudgetTracker.BlazorWASM.Services
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto dto);
    }

    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoryDto>> GetCategoriesAsync()
        {
            return await _http.GetFromJsonAsync<List<CategoryDto>>("api/categories")
                   ?? new List<CategoryDto>();
        }

        public async Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            var response = await _http.PostAsJsonAsync("api/categories", dto);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Błąd tworzenia kategorii: {response.StatusCode}");
            }
        }
    }
}

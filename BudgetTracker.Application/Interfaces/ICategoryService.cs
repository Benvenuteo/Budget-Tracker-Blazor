using BudgetTracker.Shared.DTOs;

namespace BudgetTracker.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetUserCategoriesAsync(string userId);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto, string userId);
    }
}

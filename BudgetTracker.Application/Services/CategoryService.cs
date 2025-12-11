using AutoMapper;
using BudgetTracker.Application.Interfaces;
using BudgetTracker.Core.Domain;
using BudgetTracker.Core.Interfaces;
using BudgetTracker.Shared.DTOs;
using Microsoft.Extensions.Logging;

namespace BudgetTracker.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CategoryDto>> GetUserCategoriesAsync(string userId)
        {
            var categories = await _unitOfWork.Categories.FindAsync(c => c.UserId == userId);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto, string userId)
        {
            _logger.LogInformation("Tworzenie kategorii {CategoryName} dla użytkownika {UserId}", dto.Name, userId);

            var category = _mapper.Map<Category>(dto);
            category.UserId = userId;

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<CategoryDto>(category);
        }
    }
}

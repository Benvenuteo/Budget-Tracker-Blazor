using BudgetTracker.Shared.DTOs;
using BudgetTracker.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.API.Controllers
{
    [Authorize] // Wymaga tokena JWT (zalogowania)
    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var result = await _categoryService.GetUserCategoriesAsync(GetUserId());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create(CreateCategoryDto dto)
        {
            var result = await _categoryService.CreateCategoryAsync(dto, GetUserId());

            return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
        }
    }
}

using BudgetTracker.Application.Interfaces;
using BudgetTracker.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracker.API.Controllers
{
    [Authorize] // Wymaga tokena JWT
    public class TransactionsController : BaseApiController
    {
        private readonly ITransactionService _service;

        public TransactionsController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll()
        {
            var result = await _service.GetUserTransactionsAsync(GetUserId());
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionDto>> Create(CreateTransactionDto dto)
        {
            var result = await _service.CreateTransactionAsync(dto, GetUserId());
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteTransactionAsync(id, GetUserId());

            return NoContent();
        }
    }
}

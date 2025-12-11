using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BudgetTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        // Helper: Pobiera ID zalogowanego użytkownika z Tokena
        protected string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}

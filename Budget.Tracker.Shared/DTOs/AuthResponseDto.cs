namespace BudgetTracker.Shared.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
        public bool IsSuccess { get; set; }
    }
}

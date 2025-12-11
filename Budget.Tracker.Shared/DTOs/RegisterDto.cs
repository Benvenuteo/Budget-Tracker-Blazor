using System.ComponentModel.DataAnnotations;

namespace BudgetTracker.Shared.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [StringLength(100, ErrorMessage = "Hasło musi mieć co najmniej {2} znaków.", MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;

        [Compare(nameof(Password), ErrorMessage = "Hasła nie są identyczne.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuggestionApp.DTO
{
    [Keyless]
    public class UserSignupDTO
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 2 - 50 characters")]
        public string? Username { get; set; }

        [StringLength(50, ErrorMessage = "Firstname should not exceed 50 characters")]
        public string? Firstname { get; set; }

        [StringLength(50, ErrorMessage = "Lastname should not exceed 50 characters")]
        public string? Lastname { get; set; }

        [StringLength(100, ErrorMessage = "Email should not exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [PasswordPropertyText]
        [StringLength(32, ErrorMessage = "Password should not exceed 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, pne digit, one special character")]
        public string? Password { get; set; }

        [StringLength(10, ErrorMessage = "Phone number should not exceed 10 characters")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }

        [StringLength(100, ErrorMessage = "Institution should not exceed 100 characters")]
        public string? Institution { get; set; }

        [StringLength(50, ErrorMessage = "User role should not exceed 50 characters")]
        public string? UserRole { get; set; } 
    }
}

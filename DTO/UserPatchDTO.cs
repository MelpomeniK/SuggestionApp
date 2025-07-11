using System.ComponentModel.DataAnnotations;

namespace SuggestionApp.DTO
{
    public class UserPatchDTO
    {

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Username should be between 2 - 50 characters")]
        public string? Username { get; set; }

        [StringLength(100, ErrorMessage = "Email should not exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [StringLength(32, ErrorMessage = "Password should not exceed 32 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, pne digit, one special character")]
        public string? Password { get; set; }

        [StringLength(10, ErrorMessage = "Phone number should not exceed 10 characters")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string? PhoneNumber { get; set; }
    }
}

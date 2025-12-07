using System.ComponentModel.DataAnnotations;

namespace SmartBalanceBlazor.ViewModels
{
    public class AuthViewModels
    {
        public class RegisterModel
        {
            [Required(ErrorMessage = "Username is required.")]
            [RegularExpression(@"^[a-zA-Z0-9@._\-\s]+$", ErrorMessage = "Invalid characters in username.")]
            public string UserName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is required.")]
            [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
            [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one uppercase letter and one number.")]
            public string Password { get; set; } = string.Empty;

            [Required(ErrorMessage = "Monthly income is required.")]
            [Range(0, double.MaxValue, ErrorMessage = "Monthly income cannot be negative.")]
            public decimal MonthlyIncome { get; set; }

            [RegularExpression(@"^[a-zA-Z0-9@._\-\s]+$", ErrorMessage = "Invalid characters in first name.")]
            public string FirstName { get; set; } = string.Empty;

            [RegularExpression(@"^[a-zA-Z0-9@._\-\s]+$", ErrorMessage = "Invalid characters in last name.")]
            public string LastName { get; set; } = string.Empty;
        }
        public class LoginModel
        {
            [Required(ErrorMessage = "Username is required.")]
            [RegularExpression(@"^[a-zA-Z0-9@._\-\s]+$", ErrorMessage = "Invalid characters in username.")]
            public string UserName { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is required.")]
            [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
            [RegularExpression(@"^(?=.*[A-Z])(?=.*\d).+$", ErrorMessage = "Password must contain at least one uppercase letter and one number.")]
            public string Password { get; set; } = string.Empty;
        }

        public class RegisterResponseModel
        {
            public string Message { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;

        }

        public class RegisterErrorResponseModel
        {
            public string Message { get; set; } = string.Empty;
            public Dictionary<string, string[]>? Errors { get; set; }
        }

        public class LoginResponseModel
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
            public string AccessToken { get; set; } = string.Empty;
            public string UserName { get; set; } = string.Empty;
            public string RefreshToken { get; set; } = string.Empty;
            public string UserId { get; set; } = string.Empty;
            public string TokenType { get; set; } = string.Empty;
        }

        public class LoginErrorResponseModel
        {
            public string Message { get; set; } = string.Empty;
        }
    }
}

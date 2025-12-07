namespace SmartBalanceBlazor.ViewModels
{
    public class AccountViewModels
    {
        public class BaseResponse
        {
            public bool Success { get; set; }
            public string? ErrorMessage { get; set; }
            public string? SuccessMessage { get; set; }
        }

        public class AccountInfo
        {
            public decimal MonthlyIncome { get; set; }
            public string? Bio { get; set; }
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public string ContactNumber { get; set; } = string.Empty;
        }

        public class AccountResponse : BaseResponse
        {
            public AccountInfo? UserAccount { get; set; }
        }

       
    }
}

using System.ComponentModel.DataAnnotations;

namespace SmartBalanceBlazor.ViewModels
{
    public class ExpenseViewModels
    {
        public class Expenses
        {
            public int Id { get; set; }
            public string UserId { get; set; } = string.Empty;
            public decimal Amount { get; set; }
            public string Description { get; set; } = string.Empty;
            public DateTime Date { get; set; }
        }
        public class AddExpense
        {
            public int Id { get; set; }
            [Required(ErrorMessage = "User ID is required")]
            public string UserId { get; set; } = string.Empty;
            [Required(ErrorMessage = "Amount is required")]
            [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
            public decimal Amount { get; set; }
            [Required(ErrorMessage = "Description is required")]
            public string Description { get; set; } = string.Empty;
            [Required(ErrorMessage = "Date is required")]
            public DateTime CreatedAt { get; set; }
        }
    }
}

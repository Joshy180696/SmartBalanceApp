using System.Globalization;
using static SmartBalanceBlazor.ViewModels.AccountViewModels;

namespace SmartBalanceBlazor.ViewModels.Dashboard
{
    public class DashboardResponse : BaseResponse
    {
        public List<MonthlyExpensePoint>? MonthlyExpenses { get; set; }
        public List<AnnualExpensePoint>? AnnualExpenses { get; set; }
    }

    public class MonthlyExpensePoint
    {
        public int Month { get; set; }  
        public decimal Total { get; set; }
        public string MonthName =>
        CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Month);
    }

    public class AnnualExpensePoint
    {
        public int Year { get; set; }
        public decimal Total { get; set; }
    }

}

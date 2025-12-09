using System.Globalization;
using static SmartBalanceBlazor.ViewModels.AccountViewModels;

namespace SmartBalanceBlazor.ViewModels.Dashboard
{

    #region Financial Overview
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

    #endregion

    #region Expenses Overview

    public class TotalExpenses
    {
        public string Description { get; set; } = string.Empty;
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Total { get; set; }
        public string MonthName =>
            CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Month);
    }

    public class DashboardExpensesResponse : BaseResponse
    {
        public bool HasData { get; set; }

        public List<TotalExpenses>? Expenses { get; set; }

    }

    #endregion

}

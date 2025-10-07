namespace DailyExpenseTracker.Core.Models.DTOS.Expenses
{
    public class UpdateExpenseRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? CategoryId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? ExpenseDate { get; set; }
        public string? Notes { get; set; } = string.Empty;
    }
}

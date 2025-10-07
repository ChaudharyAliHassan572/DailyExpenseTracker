namespace DailyExpenseTracker.Core.Models.DTOS.Expenses
{
    public class CreateExpenseRequestDto
    {
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime ExpenseDate { get; set; } = DateTime.UtcNow;
    }
}

namespace DailyExpenseTracker.Core.Models.DTOS.ExpenseTags
{
    public class ExpenseTagResponseDto
    {
        public Guid Id { get; set; }
        public Guid ExpenseId { get; set; }
        public Guid TagId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

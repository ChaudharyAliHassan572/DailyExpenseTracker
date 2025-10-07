namespace DailyExpenseTracker.Core.Models.DTOS.ExpenseTags
{
    public class CreateExpenseTagRequestDto
    {
        public Guid ExpenseId { get; set; }
        public Guid TagId { get; set; }
    }
}

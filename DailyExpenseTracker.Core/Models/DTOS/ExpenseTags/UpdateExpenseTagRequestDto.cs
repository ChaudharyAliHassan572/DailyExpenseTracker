namespace DailyExpenseTracker.Core.Models.DTOS.ExpenseTags
{
    public class UpdateExpenseTagRequestDto
    {
        public Guid? ExpenseId { get; set; }
        public Guid? TagId { get; set; }
    }
}

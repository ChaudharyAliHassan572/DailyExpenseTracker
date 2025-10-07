namespace DailyExpenseTracker.Core.Models.DTOS.Budgets
{
    public class CreateBudgetRequestDto
    {
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public decimal LimitAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

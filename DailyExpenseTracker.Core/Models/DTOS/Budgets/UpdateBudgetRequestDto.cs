namespace DailyExpenseTracker.Core.Models.DTOS.Budgets
{
    public class UpdateBudgetRequestDto
    {
        public Guid? UserId { get; set; }
        public Guid? CategoryId { get; set; }
        public decimal? LimitAmount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}

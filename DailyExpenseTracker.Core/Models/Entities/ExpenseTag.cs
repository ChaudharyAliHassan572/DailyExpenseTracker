using DailyExpenseTracker.Core.Common;
namespace DailyExpenseTracker.Core.Models.Entities
{
    public class ExpenseTag
    {
        public Guid ExpenseId { get; private set; }
        public Guid TagId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Expense Expense { get; private set; } = null!;
        public Tag Tag { get; private set; } = null!;
        private ExpenseTag() { }
        public ExpenseTag(Guid expenseId, Guid tagId)
        {
            ExpenseId = CustomValidations.GuidNotEmpty(expenseId, nameof(expenseId));
            TagId = CustomValidations.GuidNotEmpty(tagId, nameof(tagId));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public void UpdateTagId(Guid tagId)
        {
            TagId = CustomValidations.GuidNotEmpty(tagId, nameof(tagId));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateExpenseId(Guid expenseId)
        {
            ExpenseId = CustomValidations.GuidNotEmpty(expenseId, nameof(expenseId));
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

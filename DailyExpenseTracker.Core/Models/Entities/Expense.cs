using DailyExpenseTracker.Core.Common;
namespace DailyExpenseTracker.Core.Models.Entities
{
    public class Expense
    {
        public Guid Id { get; private set; }
        public Guid CategoryId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime ExpenseDate { get; private set; }
        public string Notes { get; private set; }=String.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Category Category { get; private set; } = null!;
        private readonly List<ExpenseTag> _expenseTags = new();
        public IReadOnlyCollection<ExpenseTag> ExpenseTags => _expenseTags.AsReadOnly();
        private Expense() { }
        public Expense(Guid categoryId, decimal amount, DateTime expenseDate, string notes)
        {
            Id = Guid.NewGuid();
            CategoryId = CustomValidations.GuidNotEmpty(categoryId, nameof(categoryId));
            Notes = CustomValidations.CleanAndNotEmpty(notes, nameof(notes));
            Amount = CustomValidations.PositiveDecimal(amount, nameof(amount));
            ExpenseDate = CustomValidations.ValidateDate(expenseDate, nameof(expenseDate));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public void UpdateAmount(decimal amount)
        {
            Amount = CustomValidations.PositiveDecimal(amount, nameof(amount));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateExpenseDate(DateTime expenseDate)
        {
            ExpenseDate = CustomValidations.ValidateDate(expenseDate, nameof(expenseDate));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateNotes(string notes)
        {
            Notes = CustomValidations.CleanAndNotEmpty(notes, nameof(notes));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateCategoryId(Guid categoryId)
        {
            CategoryId = CustomValidations.GuidNotEmpty(categoryId, nameof(categoryId));
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

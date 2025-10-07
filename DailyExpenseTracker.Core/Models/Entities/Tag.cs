using DailyExpenseTracker.Core.Common;
namespace DailyExpenseTracker.Core.Models.Entities
{
    public class Tag
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = String.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        private readonly List<ExpenseTag> _expenseTags = new();
        public IReadOnlyCollection<ExpenseTag> ExpenseTags => _expenseTags.AsReadOnly();
        private Tag() { }
        public Tag(string name)
        {
            Id = Guid.NewGuid();
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public void UpdateName(string name)
        {
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

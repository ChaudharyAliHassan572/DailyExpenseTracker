using DailyExpenseTracker.Core.Common;
namespace DailyExpenseTracker.Core.Models.Entities
{
    public class Category
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public User User { get; private set; } = null!;
        private readonly List<Expense> _expenses = new();
        public IReadOnlyCollection<Expense> Expenses => _expenses.AsReadOnly();
        private readonly List<Budget> _budgets = new();
        public IReadOnlyCollection<Budget> Budgets => _budgets.AsReadOnly();

        private Category() { }
        public Category(Guid userId, string name, string description)
        {
            Id = Guid.NewGuid();
            UserId = CustomValidations.GuidNotEmpty(userId, nameof(userId));
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            Description = CustomValidations.CleanAndNotEmpty(description, nameof(description));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public void UpdateName(string name)
        {
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateDescription(string description)
        {
            Description = CustomValidations.CleanAndNotEmpty(description, nameof(description));
            UpdatedAt = DateTime.UtcNow;
        }
        public Expense AddExpense(decimal amount, DateTime date, string notes)
        {
            if (_expenses.Any(e => e.ExpenseDate.Date == date.Date && e.Notes.Equals(notes, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Duplicate expense for the same date and notes.");
            var expense = new Expense(Id, amount, date, notes);
            _expenses.Add(expense);
            return expense;
        }
        public Budget AddBudget(decimal limitAmount, DateTime startDate, DateTime endDate)
        {
            var budget = new Budget(Id, limitAmount, startDate, endDate);
            _budgets.Add(budget);
            return budget;
        }
    }
}

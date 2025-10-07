using DailyExpenseTracker.Core.Common;

namespace DailyExpenseTracker.Core.Models.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string? UserName { get; private set; }
        public string? Email { get; private set; }
        public string PasswordHash { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public UserProfile? UserProfile { get; private set; }

        private readonly List<Category> _categories = new();
        public IReadOnlyCollection<Category> Categories => _categories.AsReadOnly();

        private User() { }

        public User(string userName, string email, string password)
        {
            Id = Guid.NewGuid();
            UserName = CustomValidations.CleanAndNotEmpty(userName, nameof(userName));
            Email = CustomValidations.ValidateEmail(email, nameof(email));
            PasswordHash = CustomValidations.PasswordMinLength(password, 8, nameof(password));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }

        public void UpdateUserName(string userName)
        {
            UserName = CustomValidations.CleanAndNotEmpty(userName, nameof(userName));
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateEmail(string email)
        {
            Email = CustomValidations.ValidateEmail(email, nameof(email));
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePassword(string password)
        {
            PasswordHash = CustomValidations.PasswordMinLength(password, 8, nameof(password));
            UpdatedAt = DateTime.UtcNow;
        }

        public Category AddCategory(string name, string description)
        {
            if (_categories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Category with this name already exists.");
            var category = new Category(Id, name, description);
            _categories.Add(category);
            return category;
        }
    }
}

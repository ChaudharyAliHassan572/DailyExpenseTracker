using DailyExpenseTracker.Core.Common;
namespace DailyExpenseTracker.Core.Models.Entities
{
    public class Currency
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public string Symbol { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        private readonly List<UserProfile> _userProfiles = new();
        public IReadOnlyCollection<UserProfile> UserProfiles => _userProfiles.AsReadOnly();

        private Currency() { }
        public Currency(string code, string name, string symbol)
        {
            Id = Guid.NewGuid();
            Code = CustomValidations.CleanAndNotEmpty(code, nameof(code));
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            Symbol = CustomValidations.CleanAndNotEmpty(symbol, nameof(symbol));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public void UpdateName(string name)
        {
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateSymbol(string symbol)
        {
            Symbol = CustomValidations.CleanAndNotEmpty(symbol, nameof(symbol));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateCode(string code)
        {
            Code = CustomValidations.CleanAndNotEmpty(code, nameof(code));
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

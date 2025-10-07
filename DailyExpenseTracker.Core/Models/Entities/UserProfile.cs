using DailyExpenseTracker.Core.Common;
namespace DailyExpenseTracker.Core.Models.Entities
{
    public class UserProfile
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid CurrencyId { get; private set; }
        public string Name { get; private set; }=string.Empty;
        public string RegionCode { get; private set; }=string.Empty;
        public string ContactNumber { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public User User { get; private set; } = null!;
        public Currency Currency { get; private set; } = null!;
        private UserProfile(){}
        public UserProfile(Guid userId, Guid currencyId, string name, string regionCode, string contactNumber)
        {
            Id = Guid.NewGuid();
            UserId = CustomValidations.GuidNotEmpty(userId, nameof(userId));
            CurrencyId = CustomValidations.GuidNotEmpty(currencyId, nameof(currencyId));
            RegionCode = CustomValidations.CleanAndNotEmpty(regionCode, nameof(regionCode));
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            ContactNumber = CustomValidations.ValidatePhoneNumber(contactNumber, regionCode, nameof(contactNumber));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public void UpdateName(string name)
        {
            Name = CustomValidations.CleanAndNotEmpty(name, nameof(name));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateContactNumber(string contactNumber, string regionCode)
        {
            RegionCode = CustomValidations.CleanAndNotEmpty(regionCode, nameof(regionCode));
            ContactNumber = CustomValidations.ValidatePhoneNumber(contactNumber, regionCode, nameof(contactNumber));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateCurrencyId(Guid currencyId)
        {
            CurrencyId = CustomValidations.GuidNotEmpty(currencyId, nameof(currencyId));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateRegionCode(string regionCode)
        {
            RegionCode = CustomValidations.CleanAndNotEmpty(regionCode, nameof(regionCode));
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

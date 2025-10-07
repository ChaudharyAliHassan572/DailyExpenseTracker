using DailyExpenseTracker.Core.Models.DTOS.Currencies;
using DailyExpenseTracker.Core.Models.DTOS.Users;

namespace DailyExpenseTracker.Core.Models.DTOS.UserProfiles
{
    public class UserProfileResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PreferredCurrencyId { get; set; }

        public UserResponseDto? User { get; set; }
        public CurrencyResponseDto? PreferredCurrency { get; set; }

        public string Name { get; set; } = string.Empty;
        public string RegionCode { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

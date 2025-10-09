using DailyExpenseTracker.Core.Models.DTOS.Categories;
using DailyExpenseTracker.Core.Models.DTOS.Currencies;

namespace DailyExpenseTracker.Core.Models.DTOS.Users
{
    public class UserProfileResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string UserName { get; set; } = string.Empty;
        public string RegionCode { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;

        public Guid PreferredCurrencyId { get; set; }
        public CurrencyResponseDto PreferredCurrency { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
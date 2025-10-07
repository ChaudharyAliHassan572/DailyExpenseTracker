using DailyExpenseTracker.Core.Models.Entities;
namespace DailyExpenseTracker.Core.Models.DTOS.Currencies
{
    public class CurrencyResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<UserProfile>? UserProfiles { get; set; }
    }
}

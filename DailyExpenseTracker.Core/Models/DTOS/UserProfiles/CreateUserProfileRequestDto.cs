namespace DailyExpenseTracker.Core.Models.DTOS.UserProfiles
{
    public class CreateUserProfileRequestDto
    {
        public Guid UserId { get; set; }
        public Guid PreferredCurrencyId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string RegionCode { get; set; } = string.Empty;
        public string ContactNumber { get; set; } = string.Empty;
    }
}

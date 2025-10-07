namespace DailyExpenseTracker.Core.Models.DTOS.Users
{
    public class UpdateUserRequestDto
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
}

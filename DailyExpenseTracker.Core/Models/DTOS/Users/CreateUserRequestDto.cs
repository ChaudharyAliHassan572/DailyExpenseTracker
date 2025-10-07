namespace DailyExpenseTracker.Core.Models.DTOS.Users
{
    public class CreateUserRequestDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

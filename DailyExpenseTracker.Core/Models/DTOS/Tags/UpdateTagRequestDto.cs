namespace DailyExpenseTracker.Core.Models.DTOS.Tags
{
    public class UpdateTagRequestDto
    {
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}

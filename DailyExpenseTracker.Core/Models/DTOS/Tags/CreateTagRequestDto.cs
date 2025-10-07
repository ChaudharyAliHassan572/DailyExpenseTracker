namespace DailyExpenseTracker.Core.Models.DTOS.Tags
{
    public class CreateTagRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

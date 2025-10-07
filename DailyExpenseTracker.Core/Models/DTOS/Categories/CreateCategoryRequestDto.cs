namespace DailyExpenseTracker.Core.Models.DTOS.Categories
{
    public class CreateCategoryRequestDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

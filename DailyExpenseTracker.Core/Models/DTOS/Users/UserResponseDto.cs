using DailyExpenseTracker.Core.Models.DTOS.Categories;

namespace DailyExpenseTracker.Core.Models.DTOS.Users
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public IList<CategoryResponseDto> Categories { get; set; } = new List<CategoryResponseDto>();
        public UserProfileResponseDto? UserProfile { get; set; }
    }
}


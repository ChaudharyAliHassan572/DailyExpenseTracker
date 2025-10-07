using DailyExpenseTracker.Core.Models.DTOS.Budgets;
using DailyExpenseTracker.Core.Models.DTOS.Expenses;
using DailyExpenseTracker.Core.Models.DTOS.Users;

namespace DailyExpenseTracker.Core.Models.DTOS.Categories
{
    public class CategoryResponseDto
    {
        public Guid Id { get; set; }    
        public Guid UserId { get; set; }                     
        public UserResponseDto? User { get; set; }         

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<ExpenseResponseDto>? Expenses { get; set; }
        public List<BudgetResponseDto>? Budgets { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

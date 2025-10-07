using DailyExpenseTracker.Core.Models.DTOS.Categories;

namespace DailyExpenseTracker.Core.Models.DTOS.Expenses
{
    public class ExpenseResponseDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryResponseDto? Category { get; set; }
        public string Notes { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        //public List<ExpenseTagResponseDto> Expenses { get; set; }
    }
}

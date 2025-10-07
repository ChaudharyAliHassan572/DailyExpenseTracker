using DailyExpenseTracker.Core.Common;
namespace DailyExpenseTracker.Core.Models.Entities
{
    public class Budget
    {
        public Guid Id { get; private set; }
        public Guid CategoryId { get; private set; }
        public decimal LimitAmount { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public Category Category { get; private set; } = null!;
        public Budget(Guid categoryId, decimal limitAmount, DateTime startDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            CategoryId = CustomValidations.GuidNotEmpty(categoryId, nameof(categoryId));
            LimitAmount = CustomValidations.PositiveDecimal(limitAmount, nameof(limitAmount));
            StartDate = CustomValidations.ValidateDate(startDate, nameof(startDate));
            EndDate = CustomValidations.ValidateDate(endDate, nameof(endDate), allowFuture: true);
            CustomValidations.ValidateDateRange(startDate, endDate, nameof(startDate), nameof(endDate));
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = CreatedAt;
        }
        public void UpdateLimitAmount(decimal limitAmount)
        {
            LimitAmount = CustomValidations.PositiveDecimal(limitAmount, nameof(limitAmount));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateDateRange(DateTime startDate, DateTime endDate)
        {
            StartDate = CustomValidations.ValidateDate(startDate, nameof(startDate));
            EndDate = CustomValidations.ValidateDate(endDate, nameof(endDate), allowFuture: true);
            CustomValidations.ValidateDateRange(startDate, endDate, nameof(startDate), nameof(endDate));
            UpdatedAt = DateTime.UtcNow;
        }
        public void UpdateCategoryId(Guid categoryId)
        {
            CategoryId = CustomValidations.GuidNotEmpty(categoryId, nameof(categoryId));
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

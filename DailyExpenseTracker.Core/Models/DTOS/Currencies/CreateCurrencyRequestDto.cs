namespace DailyExpenseTracker.Core.Models.DTOS.Currencies
{
    public class CreateCurrencyRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
    }
}

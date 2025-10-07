namespace DailyExpenseTracker.Core.Common
{
    public static class CustomValidations
    {
        const int MAXYEARS_IN_PAST = -5;
        public static string CleanAndNotEmpty(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{paramName} cannot be null or empty.", paramName);
            return value.Trim();
        }

        public static Guid GuidNotEmpty(Guid value, String paramName)
        {
            if (value == Guid.Empty)
                throw new ArgumentException($"{paramName} GUID cannot be null or empty.", paramName);
            return value;
        }

        public static string ValidateEmail(string email, string paramName)
        {
            CleanAndNotEmpty(email, paramName);
            email = email.Trim();

            var parts = email.Split('@');
            if (parts.Length != 2)
                throw new ArgumentException("Email must contain a single '@' symbol.", paramName);

            var localPart = parts[0];
            var domainPart = parts[1];

            if (string.IsNullOrWhiteSpace(localPart))
                throw new ArgumentException("Email Before @ cannot be empty.", paramName);

            if (string.IsNullOrWhiteSpace(domainPart) || !domainPart.Contains('.'))
                throw new ArgumentException("Email domain must contain a '.' symbol.", paramName);

            if (domainPart.StartsWith(".") || domainPart.EndsWith("."))
                throw new ArgumentException("Email domain cannot start or end with '.' ", paramName);

            return email;
        }

        public static string PasswordMinLength(string value, int length, string paramName)
        {
            value = CleanAndNotEmpty(value, paramName);
            if (value.Length < length)
                throw new ArgumentException($"{paramName} must be at least {length} characters long.", paramName);
            return value;
        }

        public static string ValidatePhoneNumber(string phoneNumber, string regionCode, string paramName)
        {
            CleanAndNotEmpty(phoneNumber, paramName);
            if (phoneNumber.Length < 10 || phoneNumber.Length > 15)
                throw new ArgumentException("Phone number must be between 10 and 15 digits.", paramName);
            return phoneNumber;
        }

        public static decimal PositiveDecimal(decimal value, string paramName)
        {
            if (value < 0 || value == 0)
                throw new ArgumentException($"{paramName} cannot be negative or Zero", paramName);
            return value;
        }

        public static DateTime ValidateDate(DateTime value, string paramName, bool allowFuture = false)
        {
            if (value == default)
                throw new ArgumentException($"{paramName} cannot be default.", paramName);

            if (!allowFuture && value > DateTime.UtcNow)
                throw new ArgumentException($"{paramName} cannot be in the future.", paramName);

            if (value < DateTime.UtcNow.AddYears(MAXYEARS_IN_PAST))
                throw new ArgumentException($"{paramName} is too old.", paramName);

            return value;
        }
        public static void ValidateDateRange(DateTime startDate, DateTime endDate, string startParamName, string endParamName)
        {
            if (startDate > endDate)
                throw new ArgumentException($"{startParamName} cannot be later than {endParamName}.", startParamName);
        }
    }
}

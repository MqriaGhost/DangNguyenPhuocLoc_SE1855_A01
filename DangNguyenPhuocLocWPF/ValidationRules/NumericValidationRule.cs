using System.Globalization;
using System.Windows.Controls;

namespace DangNguyenPhuocLocWPF.ValidationRules
{
    public class NumericValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if (string.IsNullOrWhiteSpace(input))
            {
                // This can be considered valid if the field is optional,
                // but our DAO validation will catch it if it's required.
                return ValidationResult.ValidResult;
            }

            if (double.TryParse(input, out _))
            {
                return ValidationResult.ValidResult;
            }

            return new ValidationResult(false, "Value must be a number.");
        }
    }
}
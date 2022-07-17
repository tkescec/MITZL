using System.ComponentModel.DataAnnotations;

namespace Knjižara.Helpers
{
    public class Oib : ValidationAttribute
    {
        private string? _oib;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var errorMessage = FormatErrorMessage(validationContext.DisplayName);

            if (value != null)
            {
                long b;
                int a = 10;
                _oib = value.ToString();
                
                if (_oib.Length != 11) 
                    return new ValidationResult(errorMessage);

                if (!long.TryParse(_oib, out b)) 
                    return new ValidationResult(errorMessage);

                for (int i = 0; i < 10; i++)
                {
                    a = a + Convert.ToInt32(_oib.Substring(i, 1));
                    a = a % 10;
                    if (a == 0) a = 10;
                    a *= 2;
                    a = a % 11;
                }
                int control = 11 - a;
                if (control == 10) control = 0;

                if (control == Convert.ToInt32(_oib.Substring(10, 1)))
                    return ValidationResult.Success;
            }

            return new ValidationResult(errorMessage);
        }
    }
}

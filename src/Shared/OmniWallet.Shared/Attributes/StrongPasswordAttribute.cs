using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using OmniWallet.Shared.Constants;

namespace OmniWallet.Shared.Attributes
{
    public class StrongPasswordAttribute : ValidationAttribute
    {
        private static readonly Regex Regex = new Regex(RegexConstants.StrongPassword);
        public const string DefaultMessage = "A senha deve possuir pelo menos oito caracteres, contendo letras maiúsculas, minúsculas e números.";

        public override bool IsValid(object value)
        {
            var password = value?.ToString() ?? string.Empty;
            return Regex.IsMatch(password);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var password = value?.ToString() ?? string.Empty;
            return Regex.IsMatch(password) ? ValidationResult.Success : new ValidationResult(ErrorMessage ?? DefaultMessage);
        }
    }
}
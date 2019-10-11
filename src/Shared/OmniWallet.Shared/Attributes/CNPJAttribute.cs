using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using OmniWallet.Shared.Constants;

namespace OmniWallet.Shared.Attributes
{
    public class CNPJAttribute : ValidationAttribute
    {
        private static readonly Regex Regex = new Regex(RegexConstants.ValidCNPJ); 
        public const string DefaultMessage = "O CNPJ informado não é válido.";
        
        public override bool IsValid(object value)
        {
            var cnpj = value?.ToString() ?? string.Empty;
            return IsValidCNPJ(cnpj);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cnpj = value?.ToString() ?? string.Empty;
            return IsValidCNPJ(cnpj) ? ValidationResult.Success : new ValidationResult(ErrorMessage ?? DefaultMessage);
        }

        private static bool IsValidCNPJ(string cnpj)
        {
            cnpj = cnpj
                .Trim()
                .Replace("/", "")
                .Replace(".", "")
                .Replace("-", "");
            
            return Regex.IsMatch(cnpj);
        }
    }
}
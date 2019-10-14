using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using OmniWallet.Shared.Constants;

namespace OmniWallet.Shared.Utils
{
    public static class Validations
    {
        private static readonly Regex OnlyLettersRegex = new Regex(RegexConstants.OnlyLetters);
        private static readonly Regex OnlyNumbersRegex = new Regex(RegexConstants.OnlyNumbers);

        public static bool IsValidEmail(string email) 
            => !string.IsNullOrWhiteSpace(email) && new EmailAddressAttribute().IsValid(email);

        public static bool IsOnlyLetters(string value) =>
            string.IsNullOrWhiteSpace(value) || OnlyLettersRegex.IsMatch(value);
        
        public static bool IsOnlyNumbers(string value) =>
            string.IsNullOrWhiteSpace(value) || OnlyNumbersRegex.IsMatch(value);
    }
}
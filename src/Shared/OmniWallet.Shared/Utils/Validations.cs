using System.ComponentModel.DataAnnotations;
using OmniWallet.Shared.Attributes;

namespace OmniWallet.Shared.Utils
{
    public static class Validations
    {
        public static bool IsValidEmail(string email) => !string.IsNullOrWhiteSpace(email) && new EmailAddressAttribute().IsValid(email);
    }
}
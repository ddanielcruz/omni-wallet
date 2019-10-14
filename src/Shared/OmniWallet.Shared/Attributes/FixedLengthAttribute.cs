using System;
using System.ComponentModel.DataAnnotations;

namespace OmniWallet.Shared.Attributes
{
    public class FixedLengthAttribute : ValidationAttribute
    {
        private readonly int _fixedLength;
        
        public FixedLengthAttribute(int fixedLength) : base("O campo \"{0}\" deve possuir exatamente {1} {2}.")
        {
            if (fixedLength <= 0) 
                throw new ArgumentOutOfRangeException(nameof(fixedLength));
            
            _fixedLength = fixedLength;
        }
        
        public override bool IsValid(object value)
        {
            var strVal = value?.ToString() ?? string.Empty;
            return strVal.Length == _fixedLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var strVal = value?.ToString() ?? string.Empty;
            return strVal.Length == _fixedLength
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessage);
        }

        public override string FormatErrorMessage(string name)
        {
            var amount = _fixedLength == 1 ? "letra" : "letras";
            return string.Format(ErrorMessageString, name, _fixedLength, amount);
        }
    }
}
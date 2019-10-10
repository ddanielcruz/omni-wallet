using System.ComponentModel.DataAnnotations;

namespace OmniWallet.Shared.Attributes
{
    public class CNPJAttribute : ValidationAttribute
    {
        private const string DefaultMessage = "Lorem ipsum dolor sit amet";
        
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

        private bool IsValidCNPJ(string cnpj)
        {
            // TODO: Separar configurações do banco para evitar dependências circulares
            // TODO: Validar comprimento e número de caracteres. 
            return false;
        }
    }
}
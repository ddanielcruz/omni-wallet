using System.ComponentModel.DataAnnotations;
using OmniWallet.Api.Resources.Messages;
using OmniWallet.Database.Persistence.EntityConfigurations;

namespace OmniWallet.Api.Dtos
{
    public class UsuarioDto
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(UsuarioConfiguration.EmailMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        [EmailAddress(ErrorMessageResourceName = nameof(ErrorMessages.Email), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Email { get; set; }

        // TODO: Adicionar validação de senha forte
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MinLength(UsuarioConfiguration.SenhaMinLength, ErrorMessageResourceName = nameof(ErrorMessages.MinLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Senha { get; set; }
    }
}
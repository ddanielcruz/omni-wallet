using System.ComponentModel.DataAnnotations;
using OmniWallet.Api.Resources.Messages;
using OmniWallet.Database.Persistence.EntityConfigurations;
using OmniWallet.Shared.Attributes;

namespace OmniWallet.Api.Dtos.Usuarios
{
    public class UsuarioCadastroDto
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(UsuarioConfiguration.EmailMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        [EmailAddress(ErrorMessageResourceName = nameof(ErrorMessages.Email), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Email { get; set; }

        [StrongPassword]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Senha { get; set; }

        public UsuarioPessoaFisicaCadastroDto PessoaFisica { get; set; }
        
        public UsuarioPessoaJuridicaCadastroDto PessoaJuridica { get; set; }
    }
}
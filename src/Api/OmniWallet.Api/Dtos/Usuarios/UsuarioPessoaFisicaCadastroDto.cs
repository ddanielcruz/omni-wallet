using System.ComponentModel.DataAnnotations;
using OmniWallet.Api.Resources.Messages;
using OmniWallet.Database.Persistence.EntityConfigurations;

namespace OmniWallet.Api.Dtos.Usuarios
{
    public class UsuarioPessoaFisicaCadastroDto
    {
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(PessoaFisicaConfiguration.NomeMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Nome { get; set; }
        
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(PessoaFisicaConfiguration.SobrenomeMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Sobrenome { get; set; }
    }
}
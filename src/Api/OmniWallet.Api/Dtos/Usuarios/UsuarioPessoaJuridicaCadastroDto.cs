using System.ComponentModel.DataAnnotations;
using OmniWallet.Api.Resources.Messages;
using OmniWallet.Database.Persistence.EntityConfigurations;
using OmniWallet.Shared.Attributes;

namespace OmniWallet.Api.Dtos.Usuarios
{
    public class UsuarioPessoaJuridicaCadastroDto
    {
        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(PessoaJuridicaConfiguration.NomeFantasiaMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string NomeFantasia { get; set; }
        
        [Display(Name = "Razão Social")]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(PessoaJuridicaConfiguration.RazaoSocialMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string RazaoSocial { get; set; }
        
        [CNPJ]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string CNPJ { get; set; }
        
        [Display(Name = "Domínio")]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(PessoaJuridicaConfiguration.DominioMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Dominio { get; set; }
    }
}
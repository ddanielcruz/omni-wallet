using System.ComponentModel.DataAnnotations;
using OmniWallet.Api.Resources.Messages;

namespace OmniWallet.Api.Dtos.Usuarios
{
    public class UsuarioAutenticacaoDto
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [EmailAddress(ErrorMessageResourceName = nameof(ErrorMessages.Email), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Email { get; set; }
        
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Senha { get; set; }
    }
}
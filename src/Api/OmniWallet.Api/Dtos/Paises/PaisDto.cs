using System.ComponentModel.DataAnnotations;
using OmniWallet.Api.Resources.Messages;
using OmniWallet.Database.Persistence.EntityConfigurations;
using OmniWallet.Shared.Attributes;

namespace OmniWallet.Api.Dtos.Paises
{
    public class PaisDto
    {
        public short Id { get; set; }
        
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(PaisConfiguration.NomeMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string Nome { get; set; }

        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [FixedLength(PaisConfiguration.ISO2FixedLength)]
        public string ISO2 { get; set; }
        
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [FixedLength(PaisConfiguration.ISO3FixedLength)]
        public string ISO3 { get; set; }
        
        [Required(ErrorMessageResourceName = nameof(ErrorMessages.Required), ErrorMessageResourceType = typeof(ErrorMessages))]
        [MaxLength(PaisConfiguration.DDIMaxLength, ErrorMessageResourceName = nameof(ErrorMessages.MaxLength), ErrorMessageResourceType = typeof(ErrorMessages))]
        public string DDI { get; set; }
    }
}
using System.ComponentModel;

namespace OmniWallet.Database.Contracts.Persistence.Enumerations
{
    public enum EstadoCivil : byte
    {
        [Description("Solteiro")]
        Solteiro = 0,
        
        [Description("Casado")]
        Casado = 1,

        [Description("Separado")]
        Separado = 2,
        
        [Description("Divorciado")]
        Divorciado = 3,
        
        [Description("Viúvo")]
        Viuvo = 4
    }
}
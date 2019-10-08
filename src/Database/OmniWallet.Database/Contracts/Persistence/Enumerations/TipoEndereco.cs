using System;
using System.ComponentModel;

namespace OmniWallet.Database.Contracts.Persistence.Enumerations
{
    [Flags]
    public enum TipoEndereco : byte
    {
        [Description("Residencial")]
        Residencial = 1,
        
        [Description("Comercial")]
        Comercial = 2,
        
        [Description("Entrega")]
        Entrega = 4,
        
        [Description("Cobrança")]
        Cobranca = 8,
        
        [Description("Trabalho")]
        Trabalho = 16,
        
        [Description("Outro")]
        Outro = 32
    }
}
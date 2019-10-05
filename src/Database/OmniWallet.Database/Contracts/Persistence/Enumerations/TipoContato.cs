using System;

namespace OmniWallet.Database.Contracts.Persistence.Enumerations
{
    [Flags]
    public enum TipoContato : byte
    {
        Pessoal = 1,
        Comercial = 2,
        Suporte = 4,
        Outro = 8
    }
}
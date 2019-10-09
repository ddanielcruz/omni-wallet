namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class OperadorPermissao
    {
        public int IdOperador { get; set; }
        public short IdPermissao { get; set; }

        public virtual Operador Operador { get; set; }
        public virtual Permissao Permissao { get; set; }
    }
}
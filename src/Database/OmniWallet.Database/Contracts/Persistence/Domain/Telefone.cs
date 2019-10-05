namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Telefone : Contato
    {
        public short IdPais { get; set; }
        public string Numero { get; set; }

        public virtual Pais Pais { get; set; }
    }
}
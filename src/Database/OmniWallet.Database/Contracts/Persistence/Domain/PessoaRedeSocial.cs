namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class PessoaRedeSocial
    {
        public int IdPessoa { get; set; }
        public byte IdRedeSocial { get; set; }
        public string Perfil { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual RedeSocial RedeSocial { get; set; }
    }
}
namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public int? IdPessoaFisica { get; set; }
        public int? IdPessoaJuridica { get; set; }

        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
    }
}
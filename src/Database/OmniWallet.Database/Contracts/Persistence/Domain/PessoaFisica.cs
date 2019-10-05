using System;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
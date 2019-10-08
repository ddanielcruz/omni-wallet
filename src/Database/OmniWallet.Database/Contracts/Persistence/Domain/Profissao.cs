using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Profissao
    {
        public short Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<PessoaFisicaFiscal> PessoasFisicasFiscal { get; set; }
    }
}
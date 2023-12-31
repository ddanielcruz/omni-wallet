using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Profissao
    {
        public Profissao()
        {
            PessoasFisicasFiscal = new HashSet<PessoaFisicaFiscal>();
        }
        
        public short Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<PessoaFisicaFiscal> PessoasFisicasFiscal { get; set; }
    }
}
using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class RedeSocial
    {
        public RedeSocial()
        {
            PessoasRedeSociais = new HashSet<PessoaRedeSocial>();
        }
        
        public byte Id { get; set; }
        public string Nome { get; set; }
        public bool Integrado { get; set; }

        public ICollection<PessoaRedeSocial> PessoasRedeSociais { get; set; }
    }
}
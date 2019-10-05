using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Pais
    {
        public Pais()
        {
            Estados = new HashSet<Estado>();
            Telefones = new HashSet<Telefone>();
        }
        
        public short Id { get; set; }
        public string Nome { get; set; }
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
        public string DDI { get; set; }

        public ICollection<Estado> Estados { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
    }
}
using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }
        
        public int Id { get; set; }
        public short IdPais { get; set; }
        public string Nome { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Cidade
    {
        public int Id { get; set; }
        public int IdEstado { get; set; }
        public string Nome { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
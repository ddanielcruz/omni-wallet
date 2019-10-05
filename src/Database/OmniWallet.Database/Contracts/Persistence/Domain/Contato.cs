using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public abstract class Contato
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string Descricao { get; set; }
        public TipoContato Tipo { get; set; } 
        
        public virtual Pessoa Pessoa { get; set; }
    }
}
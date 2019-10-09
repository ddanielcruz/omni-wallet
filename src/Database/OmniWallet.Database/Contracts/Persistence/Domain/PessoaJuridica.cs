using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class PessoaJuridica
    {
        public PessoaJuridica()
        {
            Operadores = new HashSet<Operador>();
        }
        
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Dominio { get; set; }
        public string CNPJ { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Operador> Operadores { get; set; }
    }
}
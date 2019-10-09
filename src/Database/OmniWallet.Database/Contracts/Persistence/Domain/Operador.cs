using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Operador
    {
        public Operador()
        {
            Permissoes = new HashSet<OperadorPermissao>();
        }
        
        public int Id { get; set; }
        public int IdPessoaJuridica { get; set; }
        public string Login { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }

        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual ICollection<OperadorPermissao> Permissoes { get; set; }
    }
}
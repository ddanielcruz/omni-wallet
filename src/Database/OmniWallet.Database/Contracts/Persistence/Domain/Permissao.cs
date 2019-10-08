using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Permissao
    {
        public Permissao()
        {
            Usuarios = new HashSet<UsuarioPermissao>();;
        }
        
        public short Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<UsuarioPermissao> Usuarios { get; set; }
    }
}
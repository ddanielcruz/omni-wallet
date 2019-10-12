using System;
using System.Collections.Generic;
using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Usuario
    {
        public Usuario()
        {
            Permissoes = new HashSet<UsuarioPermissao>();
        }
        
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmado { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public bool Ativo { get; set; }
        public UsuarioPapel Papel { get; set; }
        public DateTime MembroDesde { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<UsuarioPermissao> Permissoes { get; set; }
    }
}
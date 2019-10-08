using System;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmado { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public bool Ativo { get; set; }
        public DateTime MembroDesde { get; set; }
    }
}
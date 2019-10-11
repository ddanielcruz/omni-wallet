using System;

namespace OmniWallet.Api.Dtos.Usuarios
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmado { get; set; }
        public bool Ativo { get; set; }
        public DateTime MembroDesde { get; set; }
    }
}
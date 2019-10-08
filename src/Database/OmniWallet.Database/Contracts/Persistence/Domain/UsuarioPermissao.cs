namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class UsuarioPermissao
    {
        public int IdUsuario { get; set; }
        public short IdPermissao { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Permissao Permissao { get; set; }
    }
}
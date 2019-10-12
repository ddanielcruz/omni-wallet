using System.ComponentModel;

namespace OmniWallet.Database.Contracts.Persistence.Enumerations
{
    /// <summary>
    /// Papel do usuário dentro do sistema. Serve como um delimitador das permissões, para evitar chamadas múltiplas
    /// ao banco de dados para validar as permissões do usuário.
    /// </summary>
    public enum UsuarioPapel : byte
    {
        [Description("Usuário")]
        Usuario = 0,
        
        [Description("Cliente")]
        Cliente = 1,
        
        [Description("Administrador")]
        Admin = 2
    }
}
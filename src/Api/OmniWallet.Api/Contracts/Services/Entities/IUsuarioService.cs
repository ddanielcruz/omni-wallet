using System.Threading.Tasks;
using OmniWallet.Api.Dtos.Usuarios;

namespace OmniWallet.Api.Contracts.Services.Entities
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AutenticarAsync(string email, string senha);
        Task<UsuarioDto> CadastrarAsync(UsuarioCadastroDto usuarioCadastro);
    }
}
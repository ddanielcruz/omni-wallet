using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Contracts.Persistence.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<bool> IsEmailUsadoAsync(string email);
        Task<Usuario> FindByEmailAsync(string email);
    }
}
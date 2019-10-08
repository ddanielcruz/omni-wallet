using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class UsuarioPermissaoRepository : Repository<UsuarioPermissao>, IUsuarioPermissaoRepository
    {
        public UsuarioPermissaoRepository(DataContext context) : base(context)
        {
        }
    }
}
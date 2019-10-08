using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class PermissaoRepository : Repository<Permissao>, IPermissaoRepository
    {
        public PermissaoRepository(DataContext context) : base(context)
        {
        }
    }
}
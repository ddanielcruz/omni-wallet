using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class OperadorPermissaoRepository : Repository<OperadorPermissao>, IOperadorPermissaoRepository
    {
        public OperadorPermissaoRepository(DataContext context) : base(context)
        {
        }
    }
}
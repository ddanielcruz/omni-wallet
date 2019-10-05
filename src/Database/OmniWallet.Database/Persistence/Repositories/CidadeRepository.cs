using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(DataContext context) : base(context)
        {
        }
    }
}
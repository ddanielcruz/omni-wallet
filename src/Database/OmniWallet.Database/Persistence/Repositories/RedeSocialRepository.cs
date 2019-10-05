using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class RedeSocialRepository : Repository<RedeSocial>, IRedeSocialRepository
    {
        public RedeSocialRepository(DataContext context) : base(context)
        {
        }
    }
}
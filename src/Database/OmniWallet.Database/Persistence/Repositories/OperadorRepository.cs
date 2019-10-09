using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class OperadorRepository : Repository<Operador>, IOperadorRepository
    {
        public OperadorRepository(DataContext context) : base(context)
        {
            
        }
    }
}
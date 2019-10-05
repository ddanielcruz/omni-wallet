using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class PaisRepository : Repository<Pais>, IPaisRepository
    {
        public PaisRepository(DataContext context) : base(context)
        {
            
        }
    }
}
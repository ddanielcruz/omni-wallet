using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class EstadoRepository : Repository<Estado>, IEstadoRepository
    {
        public EstadoRepository(DataContext context) : base(context)
        {
        }
    }
}
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(DataContext context) : base(context)
        {
            
        }
    }
}
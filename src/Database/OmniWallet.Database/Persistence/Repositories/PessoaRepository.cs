using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(DataContext context) : base(context)
        {
            
        }
    }
}
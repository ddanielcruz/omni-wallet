using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class ProfissaoRepository : Repository<Profissao>, IProfissaoRepository
    {
        public ProfissaoRepository(DataContext context) : base(context)
        {
        }
    }
}
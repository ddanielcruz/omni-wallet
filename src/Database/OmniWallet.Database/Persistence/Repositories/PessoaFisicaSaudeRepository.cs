using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class PessoaFisicaSaudeRepository : Repository<PessoaFisicaSaude>, IPessoaFisicaSaudeRepository
    {
        public PessoaFisicaSaudeRepository(DataContext context) : base(context)
        {
            
        }
    }
}
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class PessoaFisicaFiscalRepository : Repository<PessoaFisicaFiscal>, IPessoaFisicaFiscalRepository
    {
        public PessoaFisicaFiscalRepository(DataContext context) : base(context)
        {
            
        }
    }
}
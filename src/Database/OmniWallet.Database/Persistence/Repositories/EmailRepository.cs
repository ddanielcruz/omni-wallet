using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(DataContext context) : base(context)
        {
        }
    }
}
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence;

namespace OmniWallet.Database.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(string connectionString)
        {
            _context = new DataContext();
        }
        
        public void Dispose() => _context.Dispose();

        public int Complete() => _context.SaveChanges();

        public Task<int> CompleteAsync() => _context.SaveChangesAsync();
    }
}
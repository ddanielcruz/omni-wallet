using System;
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence;

namespace OmniWallet.Database.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        
        public UnitOfWork(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(connectionString));
            
            _context = new DataContext(connectionString);
        }
        
        public void Dispose() => _context.Dispose();

        public int Complete() => _context.SaveChanges();

        public Task<int> CompleteAsync() => _context.SaveChangesAsync();
    }
}
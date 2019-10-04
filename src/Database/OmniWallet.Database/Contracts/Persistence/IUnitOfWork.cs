using System;
using System.Threading.Tasks;

namespace OmniWallet.Database.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task<int> CompleteAsync();
    }
}
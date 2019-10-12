using System;
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext context) : base(context)
        {
            
        }

        public Task<bool> IsEmailUsadoAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail não pode ser nulo.", nameof(email));

            email = email.Trim().ToLower();
            return AnyAsync(x => x.Email.ToLower() == email);
        }

        public Task<Usuario> FindByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("O e-mail não pode ser nulo.", nameof(email));
            
            email = email.Trim().ToLower();
            return SingleAsync(x => x.Email.ToLower() == email);
        }
    }
}
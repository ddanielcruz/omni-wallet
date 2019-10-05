using System;
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence;
using OmniWallet.Database.Contracts.Persistence.Repositories;
using OmniWallet.Database.Persistence.Repositories;

namespace OmniWallet.Database.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IPessoaRepository _pessoas;
        private IPessoaFisicaRepository _pessoasFisicas;
        private IPessoaJuridicaRepository _pessoasJuridicas;
        private IUsuarioRepository _usuarios;
        
        public UnitOfWork(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(connectionString));
            
            _context = new DataContext(connectionString);
        }

        public IPessoaRepository Pessoas => _pessoas ?? (_pessoas = new PessoaRepository(_context));
        public IPessoaFisicaRepository PessoasFisicas => _pessoasFisicas ?? (_pessoasFisicas = new PessoaFisicaRepository(_context));
        public IPessoaJuridicaRepository PessoasJuridicas => _pessoasJuridicas ?? (_pessoasJuridicas = new PessoaJuridicaRepository(_context));
        public IUsuarioRepository Usuarios => _usuarios ?? (_usuarios = new UsuarioRepository(_context));

        public void Dispose() => _context.Dispose();
        
        public int Complete() => _context.SaveChanges();

        public Task<int> CompleteAsync() => _context.SaveChangesAsync();
    }
}
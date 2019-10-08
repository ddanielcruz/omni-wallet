using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Principal;
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence;
using OmniWallet.Database.Contracts.Persistence.Repositories;
using OmniWallet.Database.Persistence.Repositories;

namespace OmniWallet.Database.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private ICidadeRepository _cidades;
        private IEmailRepository _emails;
        private IEnderecoRepository _enderecos;
        private IEstadoRepository _estados;
        private IPaisRepository _paises;
        private IPessoaRepository _pessoas;
        private IPessoaFisicaRepository _pessoasFisicas;
        private IPessoaFisicaFiscalRepository _pessoasFisicasFiscal;
        private IPessoaFisicaSaudeRepository _pessoasFisicasSaudes;
        private IPessoaJuridicaRepository _pessoasJuridicas;
        private IProfissaoRepository _profissoes;
        private IRedeSocialRepository _redesSociais;
        private ITelefoneRepository _telefones;
        private IUsuarioRepository _usuarios;
        
        public UnitOfWork(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(connectionString));
            
            _context = new DataContext(connectionString);
        }

        public ICidadeRepository Cidades => _cidades ?? (_cidades = new CidadeRepository(_context));
        public IEmailRepository Emails => _emails ?? (_emails = new EmailRepository(_context));
        public IEnderecoRepository Enderecos => _enderecos ?? (_enderecos = new EnderecoRepository(_context));
        public IEstadoRepository Estados => _estados ?? (_estados = new EstadoRepository(_context));
        public IPaisRepository Paises => _paises ?? (_paises = new PaisRepository(_context));
        public IPessoaRepository Pessoas => _pessoas ?? (_pessoas = new PessoaRepository(_context));
        public IPessoaFisicaRepository PessoasFisicas => _pessoasFisicas ?? (_pessoasFisicas = new PessoaFisicaRepository(_context));
        public IPessoaFisicaFiscalRepository PessoasFisicasFiscal => _pessoasFisicasFiscal ?? (_pessoasFisicasFiscal = new PessoaFisicaFiscalRepository(_context));
        public IPessoaFisicaSaudeRepository PessoasFisicasSaudes => _pessoasFisicasSaudes ?? (_pessoasFisicasSaudes = new PessoaFisicaSaudeRepository(_context));
        public IPessoaJuridicaRepository PessoasJuridicas => _pessoasJuridicas ?? (_pessoasJuridicas = new PessoaJuridicaRepository(_context));
        public IProfissaoRepository Profissoes => _profissoes ?? (_profissoes = new ProfissaoRepository(_context));
        public IRedeSocialRepository RedesSociais => _redesSociais ?? (_redesSociais = new RedeSocialRepository(_context));
        public ITelefoneRepository Telefones => _telefones ?? (_telefones = new TelefoneRepository(_context));
        public IUsuarioRepository Usuarios => _usuarios ?? (_usuarios = new UsuarioRepository(_context));

        public void Dispose() => _context.Dispose();
        
        public int Complete() => _context.SaveChanges();

        public Task<int> CompleteAsync() => _context.SaveChangesAsync();
    }
}
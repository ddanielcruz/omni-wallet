using System;
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICidadeRepository Cidades { get; }
        IEstadoRepository Estados { get; }
        IPaisRepository Paises { get; }
        IPessoaRepository Pessoas { get; }
        IPessoaFisicaRepository PessoasFisicas { get; }
        IPessoaJuridicaRepository PessoasJuridicas { get; }
        IUsuarioRepository Usuarios { get; }
        
        int Complete();
        Task<int> CompleteAsync();
    }
}
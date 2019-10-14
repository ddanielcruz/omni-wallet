using System;
using System.Threading.Tasks;
using OmniWallet.Api.Dtos.Paises;

namespace OmniWallet.Api.Contracts.Services.Entities
{
    public interface IPaisService : IDisposable
    {
        Task<PaisDto> CriarAsync(PaisDto paisDto);
        Task<PaisDto> AtualizarAsync(short id, PaisDto paisDto);
        Task<PaisDto> ExcluirAsync(short id);
    }
}
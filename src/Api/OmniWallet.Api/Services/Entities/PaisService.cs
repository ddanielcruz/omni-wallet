using System.Threading.Tasks;
using AutoMapper;
using OmniWallet.Api.Contracts.Services.Entities;
using OmniWallet.Api.Dtos.Paises;
using OmniWallet.Database.Contracts.Persistence;
using OmniWallet.Shared.Attributes;

namespace OmniWallet.Api.Services.Entities
{
    [MappedService]
    public class PaisService : IPaisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<PaisDto> CriarAsync(PaisDto paisDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaisDto> AtualizarAsync(PaisDto paisDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaisDto> ExcluirAsync(short id)
        {
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
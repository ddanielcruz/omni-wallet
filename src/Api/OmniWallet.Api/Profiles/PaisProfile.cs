using AutoMapper;
using OmniWallet.Api.Dtos.Paises;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Api.Profiles
{
    public class PaisProfile : Profile
    {
        public PaisProfile()
        {
            CreateMap<Pais, PaisDto>();
            CreateMap<PaisDto, Pais>();
        }
    }
}
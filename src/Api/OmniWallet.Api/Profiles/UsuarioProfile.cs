using AutoMapper;
using OmniWallet.Api.Dtos.Usuarios;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Api.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
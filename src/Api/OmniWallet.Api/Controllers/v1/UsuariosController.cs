using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniWallet.Api.Constants;
using OmniWallet.Api.Contracts.Services.Data;
using OmniWallet.Api.Dtos;
using OmniWallet.Api.Dtos.Usuarios;
using OmniWallet.Api.Exceptions;

namespace OmniWallet.Api.Controllers.v1
{
    [Authorize]
    [ApiController]
    [ApiVersion(VersionConstants.V1)]
    [Route(RouteConstants.RouteTemplate)]
    public class UsuariosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        // POST: api/v1/Usuarios/Cadastrar
        [AllowAnonymous]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarAsync(UsuarioCadastroDto usuarioCadastroDto)
        {
            await Task.CompletedTask;

            try
            {
                return Ok(usuarioCadastroDto);
            }
            catch (AppException e)
            {
                return BadRequest(new ResponseDto(e.Message));
            }
        }

        // POST: api/v1/Usuarios/Login
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(UsuarioCadastroDto usuarioCadastroDto)
        {
            await Task.CompletedTask;
            return Ok();
        }
    }
}
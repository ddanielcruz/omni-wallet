using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniWallet.Api.Constants;
using OmniWallet.Api.Contracts.Services.Entities;
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
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // POST: api/v1/Usuarios/Autenticar
        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarAsync(UsuarioAutenticacaoDto usuarioAutenticacao)
        {
            try
            {
                var usuarioDto = await _usuarioService.AutenticarAsync(usuarioAutenticacao);
                if (usuarioDto == null)
                    return BadRequest(new ResponseDto("E-mail e/ou senha incorretos!"));

                return Ok(usuarioDto);
            }
            catch (AppException e)
            {
                return BadRequest(new ResponseDto(e.Message));
            }
        }

        // POST: api/v1/Usuarios/Cadastrar
        [AllowAnonymous]
        [HttpPost("Cadastrar")]
        public async Task<IActionResult> CadastrarAsync(UsuarioCadastroDto usuarioCadastroDto)
        {
            try
            {
                var usuarioDto = await _usuarioService.CadastrarAsync(usuarioCadastroDto);
                return Ok(usuarioDto);
            }
            catch (AppException e)
            {
                return BadRequest(new ResponseDto(e.Message));
            }
        }
    }
}
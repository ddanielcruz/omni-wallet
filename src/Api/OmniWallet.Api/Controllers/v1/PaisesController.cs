using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniWallet.Api.Attributes;
using OmniWallet.Api.Constants;
using OmniWallet.Api.Contracts.Services.Entities;
using OmniWallet.Api.Dtos.Paises;
using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Api.Controllers.v1
{
    [Authorize]
    [ApiController]
    [ApiVersion(VersionConstants.V1)]
    [Route(RouteConstants.RouteTemplate)]
    public class PaisesController : ControllerBase
    {
        private readonly IPaisService _paisService;

        public PaisesController(IPaisService paisService)
        {
            _paisService = paisService ?? throw new ArgumentNullException(nameof(paisService));
        }

        [HttpPost]
        [AuthorizeRoles(UsuarioPapel.Admin)]
        public async Task<IActionResult> CriarAsync(PaisDto pais)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
        
        [HttpPut]
        [AuthorizeRoles(UsuarioPapel.Admin)]
        public async Task<IActionResult> AtualizarAsync(PaisDto pais)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
        
        [HttpDelete]
        [AuthorizeRoles(UsuarioPapel.Admin)]
        public async Task<IActionResult> ExcluirAsync(short id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAsync(short id)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
        
        [HttpGet]
        public async Task<IActionResult> BuscarTodosAsync()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OmniWallet.Api.Attributes;
using OmniWallet.Api.Constants;
using OmniWallet.Api.Contracts.Services.Entities;
using OmniWallet.Api.Dtos;
using OmniWallet.Api.Dtos.Paises;
using OmniWallet.Api.Exceptions;
using OmniWallet.Database.Contracts.Persistence;
using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Api.Controllers.v1
{
    [Authorize]
    [ApiController]
    [ApiVersion(VersionConstants.V1)]
    [Route(RouteConstants.RouteTemplate)]
    public class PaisesController : Controller
    {
        private readonly IPaisService _paisService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaisesController(IPaisService paisService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _paisService = paisService ?? throw new ArgumentNullException(nameof(paisService));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }

        [HttpPost]
        [AuthorizeRoles(UsuarioPapel.Admin)]
        public async Task<IActionResult> CriarAsync(PaisDto paisDto)
        {
            try
            {
                paisDto = await _paisService.CriarAsync(paisDto);
                return Ok(paisDto);
            }
            catch (AppException e)
            {
                return BadRequest(new ResponseDto(e.Message));
            }
        }
        
        [HttpPut("{id}")]
        [AuthorizeRoles(UsuarioPapel.Admin)]
        public async Task<IActionResult> AtualizarAsync(short id, [FromBody] PaisDto paisDto)
        {
            try
            {
                paisDto = await _paisService.AtualizarAsync(id, paisDto);
                return Ok(paisDto);
            }
            catch (AppException e)
            {
                return BadRequest(new ResponseDto(e.Message));
            }
        }
        
        [HttpDelete("{id}")]
        [AuthorizeRoles(UsuarioPapel.Admin)]
        public async Task<IActionResult> ExcluirAsync(short id)
        {
            try
            {
                var paisDto = await _paisService.ExcluirAsync(id);
                return Ok(paisDto);
            }
            catch (AppException e)
            {
                return BadRequest(e.Response);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarAsync(short id)
        {
            if (!(await _unitOfWork.Paises.GetAsync(id) is { } pais))
                return BadRequest(new ResponseDto($"Não existe país de código {id}."));

            var paisDto = _mapper.Map<PaisDto>(pais);
            return Ok(paisDto);
        }
        
        [HttpGet]
        public async Task<IActionResult> BuscarTodosAsync()
        {
            var paises = await _unitOfWork.Paises.GetAllAsync();
            var paisesDto = _mapper.Map<IEnumerable<PaisDto>>(paises);

            return Ok(paisesDto);
        }

        protected override void Dispose(bool disposing)
        {
            _paisService?.Dispose();
            base.Dispose(disposing);
        }
    }
}
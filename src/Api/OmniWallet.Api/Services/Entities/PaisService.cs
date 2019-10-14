using System;
using System.Threading.Tasks;
using AutoMapper;
using OmniWallet.Api.Contracts.Services.Entities;
using OmniWallet.Api.Dtos.Paises;
using OmniWallet.Api.Exceptions;
using OmniWallet.Database.Contracts.Persistence;
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Persistence.EntityConfigurations;
using OmniWallet.Shared.Attributes;
using OmniWallet.Shared.Utils;

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

        public async Task<PaisDto> CriarAsync(PaisDto paisDto)
        {
            if (paisDto == null) throw new ArgumentNullException(nameof(paisDto));

            // Valida os campos do país
            await ValidarNomeAsync(paisDto.Nome);
            await ValidarISO2Async(paisDto.ISO2);
            await ValidarISO3Async(paisDto.ISO3);
            await ValidarDDIAsync(paisDto.DDI);

            // Cria um novo país, formatando os dados
            var pais = new Pais
            {
                Nome = paisDto.Nome.Trim(),
                ISO2 = paisDto.ISO2.Trim().ToUpper(),
                ISO3 = paisDto.ISO3.Trim().ToUpper(),
                DDI =  paisDto.DDI.Trim().Replace(" ", "")
            };

            // Adiciona o país no banco de dados
            _unitOfWork.Paises.Add(pais);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<PaisDto>(pais);
        }

        public async Task<PaisDto> AtualizarAsync(short id, PaisDto paisDto)
        {
            if (paisDto == null) throw new ArgumentNullException(nameof(paisDto));
            
            if (id <= 0)
                throw new AppException("O código do país deve ser maior que zero.");
            
            if (!(await _unitOfWork.Paises.GetAsync(id) is { } pais))
                throw new AppException($"Não existe um país de código {id}.");
            
            // Valida os campos atualizados
            await ValidarAtualizacaoAsync(paisDto, pais);
            
            // Atualiza as propriedades
            pais.Nome = paisDto.Nome.Trim();
            pais.ISO2 = paisDto.ISO2.Trim().ToUpper();
            pais.ISO3 = paisDto.ISO3.Trim().ToUpper();
            pais.DDI = paisDto.DDI.Trim().Replace(" ", "");

            await _unitOfWork.CompleteAsync();
            
            return _mapper.Map<PaisDto>(pais);
        }

        private async Task ValidarAtualizacaoAsync(PaisDto paisDto, Pais paisAtualmente)
        {
            if (!string.Equals(paisDto.Nome.Trim(), paisAtualmente.Nome, StringComparison.CurrentCultureIgnoreCase))
                await ValidarNomeAsync(paisDto.Nome);

            if (!string.Equals(paisDto.ISO2.Trim(), paisAtualmente.ISO2, StringComparison.CurrentCultureIgnoreCase))
                await ValidarISO2Async(paisDto.ISO2);
            
            if (!string.Equals(paisDto.ISO3.Trim(), paisAtualmente.ISO3, StringComparison.CurrentCultureIgnoreCase))
                await ValidarISO3Async(paisDto.ISO3);
            
            if (!string.Equals(paisDto.DDI.Trim().Replace(" ", ""), paisAtualmente.DDI, StringComparison.CurrentCultureIgnoreCase))
                await ValidarDDIAsync(paisDto.DDI);
        }

        public async Task<PaisDto> ExcluirAsync(short id)
        {
            if (id <= 0) throw new AppException("O código do país deve ser maior que zero.");
            
            if (!(await _unitOfWork.Paises.GetAsync(id) is { } pais))
                throw new AppException($"Não existe um país de código {id}.");
            
            if (await _unitOfWork.Paises.PossuiDependentesAsync(id))
                throw new AppException("O país informado possuí dependentes, portante não é permitido excluí-lo.");

            _unitOfWork.Paises.Remove(pais);
            await _unitOfWork.CompleteAsync();

            return _mapper.Map<PaisDto>(pais);
        }

        #region Validations

        private async Task ValidarNomeAsync(string nome)
        {
            nome = nome?.Trim();
            if (string.IsNullOrWhiteSpace(nome))
                throw new AppException("Informe o nome do país.");
            
            if (nome.Length > PaisConfiguration.NomeMaxLength)
                throw new AppException($"O campo \"Nome\" deve possuir no máximo {PaisConfiguration.NomeMaxLength} letras.");

            if (!Validations.IsOnlyLetters(nome))
                throw new AppException($"O campo \"Nome\" deve possuir apenas letras.");
            
            if (await _unitOfWork.Paises.IsNomeUsadoAsync(nome))
                throw new AppException("O nome informado já foi usado.");
        }
        
        private async Task ValidarISO2Async(string iso2)
        {
            iso2 = iso2?.Trim();
            if (string.IsNullOrWhiteSpace(iso2))
                throw new AppException("Informe o ISO2 do país.");
            
            if (iso2.Length != PaisConfiguration.ISO2FixedLength)
                throw new AppException($"O campo \"ISO2\" deve possuir exatamente {PaisConfiguration.ISO2FixedLength} letras.");

            if (!Validations.IsOnlyLetters(iso2))
                throw new AppException($"O campo \"ISO2\" deve possuir apenas letras.");
            
            if (await _unitOfWork.Paises.IsISO2UsadoAsync(iso2))
                throw new AppException("O ISO2 informado já foi usado.");
        }
        
        private async Task ValidarISO3Async(string iso3)
        {
            iso3 = iso3?.Trim();
            if (string.IsNullOrWhiteSpace(iso3))
                throw new AppException("Informe o ISO3 do país.");
            
            if (iso3.Length != PaisConfiguration.ISO3FixedLength)
                throw new AppException($"O campo \"ISO3\" deve possuir exatamente {PaisConfiguration.ISO3FixedLength} letras.");

            if (!Validations.IsOnlyLetters(iso3))
                throw new AppException($"O campo \"ISO3\" deve possuir apenas letras.");
            
            if (await _unitOfWork.Paises.IsISO3UsadoAsync(iso3))
                throw new AppException("O ISO3 informado já foi usado.");
        }
        
        private async Task ValidarDDIAsync(string ddi)
        {
            ddi = ddi?.Trim().Replace(" ", "");
            if (string.IsNullOrWhiteSpace(ddi))
                throw new AppException("Informe o DDI do país.");

            if (ddi.Length > PaisConfiguration.DDIMaxLength)
                throw new AppException($"O campo \"DDI\" deve possuir no máximo {PaisConfiguration.DDIMaxLength} letras.");

            if (!Validations.IsOnlyNumbers(ddi))
                throw new AppException($"O campo \"DDI\" deve possuir apenas números.");
            
            if (await _unitOfWork.Paises.IsDDIUsadoAsync(ddi))
                throw new AppException("O DDI informado já foi usado.");
        }

        #endregion
        
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using OmniWallet.Api.Contracts.Services.Entities;
using OmniWallet.Api.Dtos.Usuarios;
using OmniWallet.Api.Exceptions;
using OmniWallet.Database.Contracts.Persistence;
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Persistence.EntityConfigurations;
using OmniWallet.Shared.Attributes;
using OmniWallet.Shared.Constants;
using OmniWallet.Shared.Utils;

namespace OmniWallet.Api.Services.Entities
{
    internal class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsuarioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UsuarioDto> CadastrarAsync(UsuarioCadastroDto usuarioCadastro)
        {
            if (usuarioCadastro == null) throw new ArgumentNullException(nameof(usuarioCadastro));
            if (usuarioCadastro.PessoaFisica == null && usuarioCadastro.PessoaJuridica == null) 
                throw new AppException("É obrigatório informar uma pessoa física ou uma pessoa jurídica.");

            // Valida os campos do cadastro
            ValidarSenha(usuarioCadastro.Senha);
            await ValidarEmailAsync(usuarioCadastro.Email);

            // Valida o usuário de acordo com o tipo de pessoa informada
            if (usuarioCadastro.PessoaFisica != null)
                ValidarPessoaFisica(usuarioCadastro.PessoaFisica);
            else
                await ValidarPessoaJuridicaAsync(usuarioCadastro.PessoaJuridica);

            var usuario = await CadastrarUsuarioAsync(usuarioCadastro);
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            
            return usuarioDto;
        }

        private async Task<Usuario> CadastrarUsuarioAsync(UsuarioCadastroDto usuarioCadastro)
        {
            // Cria o usuário e criptografa sua senha
            var usuario = new Usuario { Email = usuarioCadastro.Email.Trim().ToLower() };
            CriaSenhaCriptografada(usuarioCadastro.Senha, out var senhaHash, out var senhaSalt);
            
            usuario.SenhaHash = senhaHash;
            usuario.SenhaSalt = senhaSalt;
            
            // Cria a pessoa do usuário
            CriaPessoaUsuario(usuario, usuarioCadastro);
            
            // Adiciona e persiste o usuário no banco
            _unitOfWork.Usuarios.Add(usuario);
            await _unitOfWork.CompleteAsync();

            return usuario;
        }
        
        private static void CriaSenhaCriptografada(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException(@"Informe uma senha.", nameof(senha));

            using var hmac = new System.Security.Cryptography.HMACSHA512();
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }

        private static void CriaPessoaUsuario(Usuario usuario, UsuarioCadastroDto usuarioCadastro)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));
            if (usuarioCadastro == null) throw new ArgumentNullException(nameof(usuarioCadastro));
            
            // Cria a pessoa de acordo com a pessoa informada no cadastro
            usuario.Pessoa = new Pessoa();

            if (usuarioCadastro.PessoaFisica != null)
                usuario.Pessoa.PessoaFisica = new PessoaFisica
                {
                    Nome = usuarioCadastro.PessoaFisica.Nome.Trim(),
                    Sobrenome = usuarioCadastro.PessoaFisica.Sobrenome.Trim(),
                };
            else
            {
                usuarioCadastro.PessoaJuridica.CNPJ = usuarioCadastro.PessoaJuridica.CNPJ
                    .Replace(".", "")
                    .Replace("/", "")
                    .Replace("-", "");
                
                usuario.Pessoa.PessoaJuridica = new PessoaJuridica
                {
                    NomeFantasia = usuarioCadastro.PessoaJuridica.NomeFantasia.Trim(),
                    RazaoSocial = usuarioCadastro.PessoaJuridica.RazaoSocial.Trim(),
                    Dominio = usuarioCadastro.PessoaJuridica.Dominio.Trim(),
                    CNPJ = usuarioCadastro.PessoaJuridica.CNPJ
                };
            }
        }
        
        #region Validations

        private static void ValidarSenha(string senha)
        {
            if (!new StrongPasswordAttribute().IsValid(senha))
                throw new AppException(StrongPasswordAttribute.DefaultMessage); 
        }

        private async Task ValidarEmailAsync(string email)
        {
            if (!Validations.IsValidEmail(email))
                throw new AppException("O e-mail informado não é válido.");

            email = email.Trim();
            if (email.Length > UsuarioConfiguration.EmailMaxLength)
                throw new AppException($"O campo \"E-mail\" deve possuir no máximo {UsuarioConfiguration.EmailMaxLength}.");
            
            if (await _unitOfWork.Usuarios.IsEmailUsadoAsync(email)) 
                throw new AppException("O e-mail informado já foi usado.");
        }

        private static void ValidarPessoaFisica(UsuarioPessoaFisicaCadastroDto pessoaFisica)
        {
            if (pessoaFisica == null) throw new ArgumentNullException(nameof(pessoaFisica));
            
            ValidarNome(pessoaFisica.Nome);
            ValidarSobrenome(pessoaFisica.Sobrenome);
        }

        private static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new AppException("Informe seu nome.");

            nome = nome.Trim();
            if (nome.Length > PessoaFisicaConfiguration.NomeMaxLength)
                throw new AppException($"O campo \"Nome\" deve possuir no máximo {PessoaFisicaConfiguration.NomeMaxLength} letras.");
        }

        private static void ValidarSobrenome(string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new AppException("Informe seu sobrenome.");

            sobrenome = sobrenome.Trim();
            if (sobrenome.Length > PessoaFisicaConfiguration.SobrenomeMaxLength)
                throw new AppException($"O campo \"Sobrenome\" deve possuir no máximo {PessoaFisicaConfiguration.SobrenomeMaxLength} letras.");
        }
        
        private async Task ValidarPessoaJuridicaAsync(UsuarioPessoaJuridicaCadastroDto pessoaJuridica)
        {
            if (pessoaJuridica == null) throw new ArgumentNullException(nameof(pessoaJuridica));

            await ValidarNomeFantasiaAsync(pessoaJuridica.NomeFantasia);
            await ValidarRazaoSocialAsync(pessoaJuridica.RazaoSocial);
            await ValidarDominioAsync(pessoaJuridica.Dominio);
            await ValidarCNPJAsync(pessoaJuridica.CNPJ);
        }

        private async Task ValidarNomeFantasiaAsync(string nomeFantasia)
        {
            if (string.IsNullOrWhiteSpace(nomeFantasia))
                throw new AppException("Informe seu nome fantasia.");

            nomeFantasia = nomeFantasia.Trim();
            if (nomeFantasia.Length > PessoaJuridicaConfiguration.NomeFantasiaMaxLength)
                throw new AppException($"O campo \"Nome Fantasia\" deve possuir no máximo {PessoaJuridicaConfiguration.NomeFantasiaMaxLength} letras.");
            
            if (await _unitOfWork.PessoasJuridicas.IsNomeFantasiaUsadoAsync(nomeFantasia))
                throw new AppException("O nome fantasia informado já foi usado.");
        }
        
        private async Task ValidarRazaoSocialAsync(string razaoSocial)
        {
            if (string.IsNullOrWhiteSpace(razaoSocial))
                throw new AppException("Informe sua razão social.");

            razaoSocial = razaoSocial.Trim();
            if (razaoSocial.Length > PessoaJuridicaConfiguration.RazaoSocialMaxLength)
                throw new AppException($"O campo \"Razão Social\" deve possuir no máximo {PessoaJuridicaConfiguration.RazaoSocialMaxLength} letras.");
            
            if (await _unitOfWork.PessoasJuridicas.IsRazaoSocialUsadoAsync(razaoSocial))
                throw new AppException("A razão social informada já foi usada.");
        }
        
        private async Task ValidarDominioAsync(string dominio)
        {
            if (string.IsNullOrWhiteSpace(dominio))
                throw new AppException("Informe um domínio.");

            var regex = new Regex(RegexConstants.OnlyNumbersAndLetters);
            if (!regex.IsMatch(dominio))
                throw new AppException("O domínio deve possuir apenas letras (maiusculas e minúsculas) e números.");
            
            if (dominio.Length > PessoaJuridicaConfiguration.DominioMaxLength)
                throw new AppException($"O campo \"Domínio\" deve possuir no máximo {PessoaJuridicaConfiguration.DominioMaxLength} letras.");

            if (await _unitOfWork.PessoasJuridicas.IsDominioUsadoAsync(dominio))
                throw new AppException("O domínio informado já foi usado.");
        }
        
        private async Task ValidarCNPJAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                throw new AppException("Informe seu CNPJ.");
            
            if (!new CNPJAttribute().IsValid(cnpj))
                throw new AppException(CNPJAttribute.DefaultMessage);
            
            if (await _unitOfWork.PessoasJuridicas.IsCNPJUsadoAsync(cnpj))
                throw new AppException("O CNPJ informado já foi usado.");
        }

        #endregion
    }
}
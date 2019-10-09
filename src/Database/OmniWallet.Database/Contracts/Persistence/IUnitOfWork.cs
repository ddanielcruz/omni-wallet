using System;
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ICidadeRepository Cidades { get; }
        IEmailRepository Emails { get; }
        IEnderecoRepository Enderecos { get; }
        IEstadoRepository Estados { get; }
        IOperadorRepository Operadores { get; }
        IOperadorPermissaoRepository OperadoresPermissoes { get; }
        IPaisRepository Paises { get; }
        IPermissaoRepository Permissoes { get; }
        IPessoaRepository Pessoas { get; }
        IPessoaFisicaRepository PessoasFisicas { get; }
        IPessoaFisicaFiscalRepository PessoasFisicasFiscal { get; }
        IPessoaFisicaSaudeRepository PessoasFisicasSaudes { get; }
        IPessoaJuridicaRepository PessoasJuridicas { get; }
        IProfissaoRepository Profissoes { get; }
        IRedeSocialRepository RedesSociais { get; }
        ITelefoneRepository Telefones { get; }
        IUsuarioRepository Usuarios { get; }
        IUsuarioPermissaoRepository UsuariosPermissoes { get; }
        
        int Complete();
        Task<int> CompleteAsync();
    }
}
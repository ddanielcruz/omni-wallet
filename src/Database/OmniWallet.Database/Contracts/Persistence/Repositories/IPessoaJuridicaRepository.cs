using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Contracts.Persistence.Repositories
{
    public interface IPessoaJuridicaRepository : IRepository<PessoaJuridica>
    {
        Task<bool> IsNomeFantasiaUsadoAsync(string nomeFantasia);
        Task<bool> IsRazaoSocialUsadoAsync(string razaoSocial);
        Task<bool> IsDominioUsadoAsync(string dominio);
        Task<bool> IsCNPJUsadoAsync(string cnpj);
    }
}
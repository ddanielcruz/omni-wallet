using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Contracts.Persistence.Repositories
{
    public interface IPaisRepository : IRepository<Pais>
    {
        Task<bool> IsNomeUsadoAsync(string nome);
        Task<bool> IsISO2UsadoAsync(string iso2);
        Task<bool> IsISO3UsadoAsync(string iso3);
        Task<bool> IsDDIUsadoAsync(string ddi);
        
        /// <summary>
        /// Valida se um país possuí dependentes (estados ou telefones).
        /// </summary>
        /// <param name="id">Código do país</param>
        /// <returns>Se o país possuí dependentes</returns>
        Task<bool> PossuiDependentesAsync(short id);
    }
}
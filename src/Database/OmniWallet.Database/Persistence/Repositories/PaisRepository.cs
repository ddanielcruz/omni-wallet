using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    internal class PaisRepository : Repository<Pais>, IPaisRepository
    {
        public PaisRepository(DataContext context) : base(context)
        {
            
        }

        public Task<bool> IsNomeUsadoAsync(string nome)
        {
            return IsCampoUsadoAsync(ref nome, x => string.Equals(x.Nome, nome, StringComparison.CurrentCultureIgnoreCase));
        }

        public Task<bool> IsISO2UsadoAsync(string iso2)
        {
            return IsCampoUsadoAsync(ref iso2, x => string.Equals(x.ISO2, iso2, StringComparison.CurrentCultureIgnoreCase));
        }

        public Task<bool> IsISO3UsadoAsync(string iso3)
        {
            return IsCampoUsadoAsync(ref iso3, x => string.Equals(x.ISO3, iso3, StringComparison.CurrentCultureIgnoreCase));
        }

        public Task<bool> IsDDIUsadoAsync(string ddi)
        {
            return IsCampoUsadoAsync(ref ddi, x => string.Equals(x.DDI, ddi, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<bool> PossuiDependentesAsync(short id)
        {
            if (await Context.Estados.AnyAsync(x => x.IdPais == id))
                return true;

            return await Context.Telefones.AnyAsync(x => x.IdPais == id);
        }

        private Task<bool> IsCampoUsadoAsync(ref string valor, Expression<Func<Pais, bool>> validaCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("O valor não pode ser nulo.", nameof(valor));

            valor = valor.Trim();
            
            return AnyAsync(validaCampo);
        }
    }
}
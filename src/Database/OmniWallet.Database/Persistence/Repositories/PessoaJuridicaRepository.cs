using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Repositories;

namespace OmniWallet.Database.Persistence.Repositories
{
    [SuppressMessage("ReSharper", "AccessToModifiedClosure")]
    internal class PessoaJuridicaRepository : Repository<PessoaJuridica>, IPessoaJuridicaRepository
    {
        public PessoaJuridicaRepository(DataContext context) : base(context)
        {
            
        }

        public Task<bool> IsNomeFantasiaUsadoAsync(string nomeFantasia)
        {
            return IsCampoUsadoAsync(ref nomeFantasia, x => string.Equals(x.NomeFantasia, nomeFantasia, StringComparison.CurrentCultureIgnoreCase));
        }

        public Task<bool> IsRazaoSocialUsadoAsync(string razaoSocial)
        {
            return IsCampoUsadoAsync(ref razaoSocial, x => string.Equals(x.RazaoSocial, razaoSocial, StringComparison.CurrentCultureIgnoreCase));
        }

        public Task<bool> IsDominioUsadoAsync(string dominio)
        {
            return IsCampoUsadoAsync(ref dominio, x => x.Dominio == dominio);
        }

        public Task<bool> IsCNPJUsadoAsync(string cnpj)
        {
            return IsCampoUsadoAsync(ref cnpj, x => string.Equals(x.CNPJ, cnpj, StringComparison.CurrentCultureIgnoreCase));
        }

        private Task<bool> IsCampoUsadoAsync(ref string valor, Expression<Func<PessoaJuridica, bool>> validaCampo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("O valor não pode ser nulo.", nameof(valor));

            valor = valor.Trim();
            
            return AnyAsync(validaCampo);
        }
    }
}
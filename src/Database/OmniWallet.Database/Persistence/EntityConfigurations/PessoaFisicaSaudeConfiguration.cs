using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PessoaFisicaSaudeConfiguration : IEntityTypeConfiguration<PessoaFisicaSaude>
    {
        public void Configure(EntityTypeBuilder<PessoaFisicaSaude> builder)
        {
            builder.ToTable("pessoas_fisicas_saudes");
        }
    }
}
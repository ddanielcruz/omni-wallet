using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class ProfissaoConfiguration : IEntityTypeConfiguration<Profissao>
    {
        public const int NomeMaxLength = 50;
        
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder.ToTable("profissoes");
            
            // Properties
            builder
                .Property(x => x.Nome)
                .HasMaxLength(NomeMaxLength)
                .IsRequired();
        }
    }
}
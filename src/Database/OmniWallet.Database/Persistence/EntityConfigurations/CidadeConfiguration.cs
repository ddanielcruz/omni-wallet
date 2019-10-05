using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class CidadeConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public const int NomeMaxLength = 200;
        
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("cidades");
            
            // Properties
            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(NomeMaxLength);
            
            // Indexes
            builder
                .HasIndex(c => c.Nome)
                .IsUnique();
        }
    }
}
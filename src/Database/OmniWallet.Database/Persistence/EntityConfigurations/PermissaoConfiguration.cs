using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PermissaoConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public const int NomeMaxLength = 64;
        
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.ToTable("permissoes");
            
            // Properties
            builder
                .Property(x => x.Nome)
                .HasMaxLength(NomeMaxLength)
                .IsRequired();
            
            // Indexes
            builder
                .HasIndex(x => x.Nome)
                .IsUnique();
        }
    }
}
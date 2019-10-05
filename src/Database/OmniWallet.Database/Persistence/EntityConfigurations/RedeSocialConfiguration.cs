using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class RedeSocialConfiguration : IEntityTypeConfiguration<RedeSocial>
    {
        public const int NomeMaxLength = 32;

        public void Configure(EntityTypeBuilder<RedeSocial> builder)
        {
            builder.ToTable("redes_sociais");
            
            // Properties
            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(NomeMaxLength);
            
            // Indexes
            builder
                .HasIndex(x => x.Nome)
                .IsUnique();
        }
    }
}
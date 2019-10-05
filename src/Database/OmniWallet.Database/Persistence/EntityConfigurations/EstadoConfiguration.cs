using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public const int NomeMaxLength = 100;
        
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estados");
            
            // Properties
            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(NomeMaxLength);
            
            // Indexes
            builder
                .HasIndex(s => s.Nome)
                .IsUnique();
            
            // Relationships
            builder
                .HasMany(x => x.Cidades)
                .WithOne(x => x.Estado)
                .HasForeignKey(x => x.IdEstado)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
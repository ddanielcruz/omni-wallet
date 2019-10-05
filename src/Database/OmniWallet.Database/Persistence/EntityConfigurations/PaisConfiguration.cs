using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public const int NomeMaxLength = 100;
        public const int ISO2FixedLength = 2;
        public const int ISO3FixedLength = 3;
        public const int DDIMaxLength = 4;
        
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("paises");
            
            // Properties
            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(NomeMaxLength);

            builder
                .Property(x => x.ISO2)
                .HasMaxLength(ISO2FixedLength)
                .IsFixedLength();

            builder
                .Property(x => x.ISO3)
                .HasMaxLength(ISO3FixedLength)
                .IsFixedLength();

            builder
                .Property(x => x.DDI)
                .IsRequired()
                .HasMaxLength(DDIMaxLength);

            // Indexes
            builder
                .HasIndex(x => x.Nome)
                .IsUnique();
            
            builder
                .HasIndex(c => c.ISO2)
                .IsUnique();

            builder
                .HasIndex(c => c.ISO3)
                .IsUnique();
            
            builder
                .HasIndex(c => c.DDI)
                .IsUnique();
            
            // Relationships
            builder
                .HasMany(c => c.Estados)
                .WithOne(s => s.Pais)
                .HasForeignKey(s => s.IdPais)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Telefones)
                .WithOne(x => x.Pais)
                .HasForeignKey(x => x.IdPais)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
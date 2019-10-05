using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class EmailConfiguration : ContatoConfiguration<Email>
    {
        public const int ValorMaxLength = 255;

        public override void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("emails");
            
            // Properties
            builder
                .Property(x => x.Valor)
                .IsRequired()
                .HasMaxLength(ValorMaxLength);
            
            // Indexes
            builder
                .HasIndex(x => x.Valor)
                .IsUnique();
        }
    }
}